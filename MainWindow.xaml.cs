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
        }

        private void B_open_Click(object sender, RoutedEventArgs e)
        {
            SubWindow subwin1 = new SubWindow();
            int prizeNum = this.ComboBox1.SelectedIndex - 1;

            if ( prizeNum < 0 ) prizeNum = m_Lotter.getPrizeNum() ;

            subwin1.PrizeNum = prizeNum ;
            subwin1.ShowDialog();
        //    this.Close();

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
