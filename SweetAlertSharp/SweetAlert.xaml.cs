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
        public SweetAlert()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
