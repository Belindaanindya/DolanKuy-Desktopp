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
using Velacro.UIElements.Basic;

namespace DolanKuyDesktopPalingbaru.Dashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Dashboard : MyWindow
    {

        private MyPage listWisataPage;
        private MyPage akomodasiPage;
        private MyPage kategoriPage;
        private MyPage createPage;

        public Dashboard()
        {
            //listWisataPage = new ListWisata.ListWisata();
            //akomodasiPage = new Akomodasi.Akomodasi();
            //kategoriPage = new Kategori.Kategori();
            createPage = new CreateLokasi.CreatePage();
            InitializeComponent();
        }

        private void wisata_click(object sender, RoutedEventArgs e)
        {
            listWisataPage = new ListWisata.ListWisata();
            mainFrame.Navigate(listWisataPage);
        }

        private void akomodasi_click(object sender, RoutedEventArgs e)
        {
            akomodasiPage = new Akomodasi.Akomodasi();
            mainFrame.Navigate(akomodasiPage);
        }

        private void kategori_click(object sender, RoutedEventArgs e)
        {
            kategoriPage = new Kategori.Kategori();
            mainFrame.Navigate(kategoriPage);
        }

        private void create_lokasi_click(object sender, RoutedEventArgs e)
        {
            
            mainFrame.Navigate(createPage);
        }
    }
}
