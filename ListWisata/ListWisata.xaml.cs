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
using Velacro.UIElements.Button;

namespace DolanKuyDesktopPalingbaru.ListWisata
{
    /// <summary>
    /// Interaction logic for ListWisata.xaml
    /// </summary>
    public partial class ListWisata : MyPage
    {
        private BuilderButton buttonBuilder;
        private List<ModelListWisata> listServices;
        private List<int> actualId = new List<int>();
        private String token;

        public ListWisata(string token)
        {
            this.token = token;
            InitializeComponent();
            setController(new ListWisataController(this));
            initUIBuilders();
            getData();
        }

       

        private void initUIBuilders()
        {
            buttonBuilder = new BuilderButton();
        }

        public void getData()
        {
            getController().callMethod("getLocation");
        }

        public void setLocation(List<ModelListWisata> locationList)
        {
            this.listServices = locationList;

            this.Dispatcher.Invoke((Action)(() => {
                serviceList.ItemsSource = locationList;
            }));
        }

        public void setDelete(String response)
        {

            this.Dispatcher.Invoke((Action)(() => {
                
                this.NavigationService.Navigate(new ListWisata(this.token));
            }));
        }

        private void editBtnWisata_Click(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;
            ModelListWisata dataObject = button.DataContext as ModelListWisata;
            this.NavigationService.Navigate(new EditLokasi.EditPage(this.token, dataObject));

        }

        private void deleteBtnWisata_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ModelListWisata dataObject = button.DataContext as ModelListWisata;
            MessageBoxResult result = MessageBox.Show("Are you sure want to perform this action?", "Delete Service", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    getController().callMethod("deleteWisata", dataObject.id.ToString(), this.token);

                    break;
            }
            
        }
    }
}
