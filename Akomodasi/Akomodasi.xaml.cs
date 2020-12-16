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
        private IMyButton buttonGet;
        private List<ModelListAkomodasi> listServices;

        public Akomodasi()
        {
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

        public void setLocation(List<ModelListAkomodasi> locationList)
        {
            this.listServices = locationList;

            this.Dispatcher.Invoke((Action)(() => {
                serviceList.ItemsSource = locationList;
            }));
        }
    }
}
