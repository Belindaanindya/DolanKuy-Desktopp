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
        private String token;

        public Dashboard(string token)
        {
            this.token = token;
            //listWisataPage = new ListWisata.ListWisata();
            //akomodasiPage = new Akomodasi.Akomodasi();
            //kategoriPage = new Kategori.Kategori();
            InitializeComponent();
        }

        private void wisata_click(object sender, RoutedEventArgs e)
        {
            listWisataPage = new ListWisata.ListWisata(this.token);
            mainFrame.Navigate(listWisataPage);
        }

        private void akomodasi_click(object sender, RoutedEventArgs e)
        {
            akomodasiPage = new Akomodasi.Akomodasi(this.token);
            mainFrame.Navigate(akomodasiPage);
        }

        private void kategori_click(object sender, RoutedEventArgs e)
        {
            kategoriPage = new Kategori.Kategori(this.token);
            mainFrame.Navigate(kategoriPage);
        }

        private void create_lokasi_click(object sender, RoutedEventArgs e)
        {
            createPage = new CreateLokasi.CreatePage(this.token);
            mainFrame.Navigate(createPage);
        }
    }
}
