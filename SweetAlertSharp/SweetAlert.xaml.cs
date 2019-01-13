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
        private string _caption;
        private string _content;
        #endregion

        private SweetAlert()
        {
            InitializeComponent();
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

        public new string Content
        {
            get => _content;
            set
            {
                _content = value;

                NotifyPropertyChanged("Content");
            }
        }
        #endregion

        #region Public Methods
        public static void Show(string caption, string content)
        {
            var alert = new SweetAlert
            {
                Caption = caption,
                Content = content,
            };

            alert.ShowDialog();
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
