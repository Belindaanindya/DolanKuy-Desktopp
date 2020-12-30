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
        private IMyButton buttonGet;
        private List<ModelListWisata> listServices;
        private List<int> actualId = new List<int>();
        String token;

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
            /*actualId.Clear();
            int id = 1;
            foreach (ModelCategory category in categoryList)
            {
                actualId.Add(category.id);
                category.id = id;
                id++;
            }*/

            this.Dispatcher.Invoke((Action)(() => {
                serviceList.ItemsSource = locationList;
            }));
        }
    }
}
