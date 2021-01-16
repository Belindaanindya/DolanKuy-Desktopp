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

namespace DolanKuyDesktopPalingbaru.Akomodasi
{
    /// <summary>
    /// Interaction logic for Akomodasi.xaml
    /// </summary>
    public partial class Akomodasi : MyPage
    {
        private BuilderButton buttonBuilder;
        private List<ModelListAkomodasi> listServices;
        private String token;

        public Akomodasi(string token)
        {
            this.token = token;
            InitializeComponent();
            setController(new ListAkomodasiController(this));
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

        public void setLocation(List<ModelListAkomodasi> acomodationList)
        {
            this.listServices = acomodationList;

            this.Dispatcher.Invoke((Action)(() => {
                serviceList.ItemsSource = acomodationList;
            }));
        }

        public void setDelete(String response)
        {

            this.Dispatcher.Invoke((Action)(() => {

                this.NavigationService.Navigate(new Akomodasi(this.token));
            }));
        }

        private void deleteBtnAkomodasi_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ModelListAkomodasi dataObject = button.DataContext as ModelListAkomodasi;
            MessageBoxResult result = MessageBox.Show("Are you sure want to perform this action?", "Delete Service", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    getController().callMethod("deleteAkomodasi", dataObject.id.ToString(), this.token);

                    break;
            }
        }

        private void editBtnAkomodasi_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ModelListAkomodasi dataObject = button.DataContext as ModelListAkomodasi;
            this.NavigationService.Navigate(new EditLokasi.EditPage(this.token, dataObject));
        }
    }
}
