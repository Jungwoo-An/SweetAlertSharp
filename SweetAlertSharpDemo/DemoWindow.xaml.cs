using SweetAlertSharp;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SweetAlertSharpDemo
{
    /// <summary>
    /// DemoWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DemoWindow : Window
    {
        public DemoWindow()
        {
            InitializeComponent();
        }

        private void Event_Click(object sender, RoutedEventArgs e)
        {
            SweetAlert.Show("Caption", "Content");
        }

        private void Event_Information(object sender, RoutedEventArgs e)
        {
            SweetAlert.Show("Caption", "Content", msgImage: SweetAlertImage.INFORMATION);
        }

        private void Event_YesNo(object sender, RoutedEventArgs e)
        {
            SweetAlert.Show("Caption", "Content", SweetAlertButton.YesNo, SweetAlertImage.INFORMATION);
        }

        private void Event_Custom(object sender, RoutedEventArgs e)
        {
            var alert = new SweetAlert();
            alert.Caption = "Custom Alert";
            alert.Message = "Content";
            alert.MsgButton = SweetAlertButton.YesNo;
            alert.OkText = "Yes.";
            alert.CancelText = "No!";

            var reuslt = alert.ShowDialog();
        }

        private void Event_Delay(object sender, RoutedEventArgs e)
        {
            var canClose = false;

            var alert = new SweetAlert();
            alert.Caption = "Delay";
            alert.Message = "Wait!";
            alert.ButtonContent = "Loading ...";
            alert.PreClose += (object window, CancelEventArgs cancelEvent) =>
            {
                cancelEvent.Cancel = !canClose;
            };

            Task.Run(async () =>
            {
                await Task.Delay(3000);
                await Dispatcher.BeginInvoke(new Action(() =>
                {
                    canClose = true;

                    alert.ButtonContent = "Ok!";
                }));
            });

            var reuslt = alert.ShowDialog();
        }
    }
}
