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
        private MyPage aboutPage;
        private String token;

        public Dashboard(string token)
        {
            this.token = token;
            listWisataPage = new ListWisata.ListWisata(this.token);
            createPage = new CreateLokasi.CreatePage(this.token);
            akomodasiPage = new Akomodasi.Akomodasi(this.token);
            kategoriPage = new Kategori.Kategori(this.token);
            aboutPage = new About();
            InitializeComponent();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    mainFrame.Navigate(listWisataPage);
                    break;
                case 1:
                    mainFrame.Navigate(akomodasiPage);
                    break;
                case 2:
                    mainFrame.Navigate(createPage);
                    break;
                case 3:
                    mainFrame.Navigate(kategoriPage);
                    break;
                case 4:
                    mainFrame.Navigate(aboutPage);
                    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TransitioningContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (60 * index), 0, 0);
        }
    }
}
