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
using Microsoft.Web.WebView2.Core;

namespace WPFTest
{
    /// <summary>
    /// Interaction logic for SubWindow.xaml
    /// </summary>
    public partial class SubWindow2 : Window
    {
        public SubWindow2()
        {
            InitializeComponent();
        /*    
            var axIWebBrowser2 = typeof(WebBrowser).GetProperty("AxIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            var comObj = axIWebBrowser2.GetValue(webBrowser1, null);
            comObj.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, comObj, new object[] { true });
        */
        /*
            string uri = String.Format( "file://localhost/{0}Contents/html/slot.html", AppDomain.CurrentDomain.BaseDirectory );
            this.WebView21.Source = uri != null ? new Uri( uri ) : null;
        */
        //    string uri = $"{Environment.CurrentDirectory}/Contents/html/test2.html" ;
            string uri = String.Format( "file://localhost/{0}Contents/html/slot_audio.html", AppDomain.CurrentDomain.BaseDirectory );
            this.WebView21.Source = uri != null ? new Uri( uri ) : null;

            InitializeAsync();
        }


        public int PrizeNum { get; set; }
        public int SlotDuration { get; set; }

        async void InitializeAsync()
        {
            await this.WebView21.EnsureCoreWebView2Async(null);
        //    this.WebView21.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;

        //    webView.CoreWebView2.Navigate(new Uri($"{Environment.CurrentDirectory}/AppData/index.html").AbsoluteUri);
            this.WebView21.CoreWebView2.WebMessageReceived += this.WebView21_WebMessageReceived ;
        }

        private void WebView21_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
        //    this.WebView21.CoreWebView2.ExecuteScriptAsync( "setNumWinning( " + this.PrizeNum.ToString() +" );" );

        //    this.webBrowser1.Refresh() ;
        //    Task.Delay(1000).Wait();
            this.WebView21.CoreWebView2.ExecuteScriptAsync(
                "slotStartOnWebView( " +
                    this.PrizeNum.ToString() + " , " +
                    this.SlotDuration.ToString() + " );" );
        }

        /*
        private void webBrowser1_StatusTextChanged(object sender, EventArgs e)
        {
            MessageBox.Show( this.webBrowser1.DDocument..StatusText );
        }
        */
        /*
        private void WebView21_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
        //    MessageBox.Show( e.Uri.ToString() );
        
            if ( e.Uri.ToString() == "about:blank" ) {
                this.Close();
            }
        
        }
        */
        private void WebView21_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            string text = e.TryGetWebMessageAsString();
        //    MessageBox.Show(text);
            if ( text == "closeWindow" ) {
                this.Close();
            }
        }

    }
}
