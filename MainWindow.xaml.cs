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

namespace WPFTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Lotter m_Lotter ;
        public MainWindow()
        {
            InitializeComponent();

            m_Lotter = new Lotter();
        //    m_Lotter.printLotterTable();

            for (int i=1; i<31 ; i++ ) {
                this.ComboBox2.Items.Add(i);
            }

            this.ComboBox2.SelectedIndex = 2 ;

        }

        private void B_open_Click(object sender, RoutedEventArgs e)
        {
            this.B_open.IsEnabled = false ;

            SubWindow subwin1 = new SubWindow();
            int prizeNum = this.ComboBox1.SelectedIndex - 1;

            if ( prizeNum < 0 ) prizeNum = m_Lotter.getPrizeNum() ;

            subwin1.PrizeNum = prizeNum ;
            subwin1.ShowDialog();
        //    this.Close();

            ResultMessage( prizeNum ) ;

            this.B_open.IsEnabled = true ;
        }

        private void B_open2_Click(object sender, RoutedEventArgs e)
        {
            this.B_open2.IsEnabled = false ;

            SubWindow2 subwin2 = new SubWindow2();
            int prizeNum = this.ComboBox1.SelectedIndex - 1;

            if ( prizeNum < 0 ) prizeNum = m_Lotter.getPrizeNum() ;

            subwin2.PrizeNum = prizeNum ;
            subwin2.SlotDuration = this.ComboBox2.SelectedIndex + 1 ;
            subwin2.ShowDialog();
        //    this.Close();
            ResultMessage( prizeNum ) ;

            this.B_open2.IsEnabled = true ;
        }

        private void ResultMessage(int prizeNum)
        {
            string[] strMsgs = {
                "ハズレでした" ,
                "1等「7」が当たりました" ,
                "2等「スイカ」が当たりました" ,
                "3等「ベル」が当たりました" ,
                "4等「チェリー」が当たりました" ,
                "5等「プラム」が当たりました" };

            MessageBox.Show( strMsgs[ prizeNum ] );
        }

    }

}
