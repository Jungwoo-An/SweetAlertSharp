using SweetAlertSharp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SweetAlertSharp
{
    /// <summary>
    /// SweetAlert.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SweetAlert : Window, INotifyPropertyChanged
    {
        #region Private Fields
        private List<CancelEventHandler> _preCloseEvents = new List<CancelEventHandler>();

        private object _buttonContent = null;

        private bool _isCloseable = true;

        private string _caption;
        private string _message;
        private string _okText = "OK";
        private string _cancelText = "Cancel";

        private SweetAlertButton _boxButton = SweetAlertButton.OK;
        private SweetAlertImage _boxImage = SweetAlertImage.NONE;
        #endregion

        #region Private Methods
        private bool RaiseCloseEvent()
        {
            var args = new CancelEventArgs();
            foreach (var preCloseEvent in _preCloseEvents)
            {
                preCloseEvent(this, args);

                if (args.Cancel)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region Private Events
        private void Event_HideAnimation_Completed(object sender, EventArgs e)
        {
            if (_isCloseable)
            {
                return;
            }

            Close();
        }

        private void Event_Click_Button(object sender, RoutedEventArgs e)
        {
            if (!_isCloseable)
            {
                return;
            }

            if (sender == _OkButton)
            {
                Result = SweetAlertResult.OK;
            }

            Close();
        }

        private void Event_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void Event_Closing(object sender, CancelEventArgs e)
        {
            var hideAnimation = this.FindResource("HideAnimation") as Storyboard;
            if (hideAnimation == null || !_isCloseable)
            {
                return;
            }

            e.Cancel = true;

            if (!RaiseCloseEvent())
            {
                _isCloseable = true;
                return;
            }

            _isCloseable = false;

            hideAnimation.Completed += Event_HideAnimation_Completed;
            hideAnimation.Begin(_Dialog);
        }
        #endregion

        public SweetAlert()
        {
            InitializeComponent();

            _OkButton.Focus();
        }

        #region Public Properties
        public string Caption
        {
            get => _caption;
            set
            {
                _caption = value;

                Title = _caption;

                NotifyPropertyChanged("Caption");
            }
        }

        public string Message
        {
            get => _message;
            set
            {
                _message = value;

                NotifyPropertyChanged("Message");
            }
        }

        public SweetAlertButton MsgButton
        {
            get => _boxButton;
            set
            {
                _boxButton = value;

                NotifyPropertyChanged("MsgButton");
            }
        }

        public SweetAlertImage MsgImage
        {
            get => _boxImage;
            set
            {
                _boxImage = value;

                NotifyPropertyChanged("MsgImage");
            }
        }

        public SweetAlertResult Result { get; private set; } = SweetAlertResult.CANCEL;

        public string OkText
        {
            get => _okText;
            set
            {
                _okText = value;

                NotifyPropertyChanged("OkText");
            }
        }

        public string CancelText
        {
            get => _cancelText;
            set
            {
                _cancelText = value;

                NotifyPropertyChanged("CancelText");
            }
        }

        public object ButtonContent
        {
            get => _buttonContent;
            set
            {
                _buttonContent = value;

                NotifyPropertyChanged("ButtonContent");
            }
        }

        public event CancelEventHandler PreClose
        {
            add => _preCloseEvents.Add(value);
            remove => _preCloseEvents.Remove(value);
        }
        #endregion

        #region Public Methods
        public static SweetAlertResult Show(string caption, string content, SweetAlertButton msgButton = SweetAlertButton.OK, SweetAlertImage msgImage = SweetAlertImage.NONE)
        {
            var alert = new SweetAlert
            {
                Caption = caption,
                Message = content,
                MsgButton = msgButton,
                MsgImage = msgImage,
            };

            return alert.ShowDialog();
        }

        public new SweetAlertResult ShowDialog()
        {
            base.ShowDialog();

            return Result;
        }
        #endregion

        #region Public Events
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
