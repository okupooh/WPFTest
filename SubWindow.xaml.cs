using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using Microsoft.Win32;
using System.Diagnostics;
using System.Threading;

namespace WPFTest
{
    /// <summary>
    /// Interaction logic for SubWindow.xaml
    /// </summary>
    public partial class SubWindow : Window
    {
        public SubWindow()
        {
            InitializeComponent();
        /*    
            var axIWebBrowser2 = typeof(WebBrowser).GetProperty("AxIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            var comObj = axIWebBrowser2.GetValue(webBrowser1, null);
            comObj.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, comObj, new object[] { true });
        */
            string uri = String.Format( "file://localhost/{0}Contents/html/slot.html", AppDomain.CurrentDomain.BaseDirectory );
            this.webBrowser1.Source = uri != null ? new Uri( uri ) : null;
        }

        public int PrizeNum { get; set; }


        private void webBrowser1_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            int numWin = this.PrizeNum ;
            if ( numWin == 0 ) numWin = 128 ;
        //    MessageBox.Show("Webページの読み込みが完了しました！");
            this.webBrowser1.InvokeScript( "setNumWinning" , numWin-1 );

        //    this.webBrowser1.Refresh() ;
            Task.Delay(1000).Wait();
            this.webBrowser1.InvokeScript( "slotStart" );
        }

        /*
        private void webBrowser1_StatusTextChanged(object sender, EventArgs e)
        {
            MessageBox.Show( this.webBrowser1.DDocument..StatusText );
        }
        */
        private void webBrowser1_Navigated(object sender, NavigationEventArgs e)
        {
        //    MessageBox.Show( e.Uri.ToString() );
        
            if ( e.Uri.ToString() == "about:blank" ) {
                this.Close();
            }
        
        }
    }
}
