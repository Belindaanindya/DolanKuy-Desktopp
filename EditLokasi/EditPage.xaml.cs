using DolanKuyDesktopPalingbaru.Akomodasi;
using DolanKuyDesktopPalingbaru.ListWisata;
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
using Velacro.Basic;
using Velacro.LocalFile;
using Velacro.UIElements.Basic;
using Velacro.UIElements.Button;
using Velacro.UIElements.TextBlock;
using Velacro.UIElements.TextBox;

namespace DolanKuyDesktopPalingbaru.EditLokasi
{
    /// <summary>
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : MyPage
    {
        private String token;
        private ModelListAkomodasi modelListAkomodasi;
        private ModelListWisata modelListWisata;
        private BuilderTextBox txtBoxBuilder;
        private IMyTextBox editName_tb1;
        private IMyTextBox editDescription_tb1;
        private IMyTextBox editAddress_tb1;
        private IMyTextBox editContact_tb1;
        private IMyTextBox editLongitude_tb1;
        private IMyTextBox editLatitude_tb1;
        private MyPage currentPage;
        private MyList<MyFile> newImage;
        private int currentId;


        public EditPage(string token, ModelListWisata modelListWisata)
        {
            this.token = token;
            this.modelListWisata = modelListWisata;
            InitializeComponent();

            setController(new EditController(this));
            initUIBuilders();
            initUIElements();
            setWisata();

        }

        public EditPage(string token, ModelListAkomodasi modelListAkomodasi)
        {
            this.token = token;
            this.modelListAkomodasi = modelListAkomodasi;
            InitializeComponent();

            setController(new EditController(this));
            initUIBuilders();
            initUIElements();
            setAkomodasi();

        }

        private void setWisata()
        {
            currentPage = new ListWisata.ListWisata(this.token);
            currentId = modelListWisata.id;
            editName_tb1.setText(modelListWisata.name);
            editDescription_tb1.setText(modelListWisata.description);
            editContact_tb1.setText(modelListWisata.contact.ToString());
            editAddress_tb1.setText(modelListWisata.address);
            editLatitude_tb1.setText(modelListWisata.latitude.ToString());
            editLongitude_tb1.setText(modelListWisata.longitude.ToString());
        }


        private void setAkomodasi()
        {
            currentPage = new Akomodasi.Akomodasi(this.token);
            currentId = modelListAkomodasi.id;
            editName_tb1.setText(modelListAkomodasi.name);
            editDescription_tb1.setText(modelListAkomodasi.description);
            editContact_tb1.setText(modelListAkomodasi.contact.ToString());
            editAddress_tb1.setText(modelListAkomodasi.address);
            editLatitude_tb1.setText(modelListAkomodasi.latitude.ToString());
            editLongitude_tb1.setText(modelListAkomodasi.longitude.ToString());
        }

        private void initUIBuilders()
        {
            txtBoxBuilder = new BuilderTextBox();
        }

        private void initUIElements()
        {
            newImage = new MyList<MyFile>();
            newImage.Add(null);

            editName_tb1 = txtBoxBuilder.activate(this, "name_tb");
            editDescription_tb1 = txtBoxBuilder.activate(this, "description_tb");
            editAddress_tb1 = txtBoxBuilder.activate(this, "address_tb");
            editContact_tb1 = txtBoxBuilder.activate(this, "contact_tb");
            editLatitude_tb1 = txtBoxBuilder.activate(this, "latitude_tb");
            editLongitude_tb1 = txtBoxBuilder.activate(this, "longitude_tb");

        }

        public void setEditStatus(string _status)
        {
            this.Dispatcher.Invoke(() =>
            {
                if (modelListAkomodasi == null)
                {
                    this.NavigationService.Navigate(new ListWisata.ListWisata(_status));
                } else if (modelListWisata == null)
                {
                    this.NavigationService.Navigate(new Akomodasi.Akomodasi(_status));
                }
                
            });

        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
            getController().callMethod("editLocation",

                editName_tb1.getText(),
                editDescription_tb1.getText(),
                editAddress_tb1.getText(),
                editContact_tb1.getText().ToString(),
                editLatitude_tb1.getText(),
                editLongitude_tb1.getText(),
                currentId.ToString(),
                this.token,
                newImage[0]
            );
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(currentPage);
        }

        private void image_btn_Click(object sender, RoutedEventArgs e)
        {
            MyList<MyFile> chosenImage = new OpenFile().openFile(false);

            if (chosenImage[0] != null)
            {
                string size = chosenImage[0].fileSize;
                if ((chosenImage[0].extension.ToUpper().Equals(".PNG") ||
                     chosenImage[0].extension.ToUpper().Equals(".JPEG") ||
                     chosenImage[0].extension.ToUpper().Equals(".JPG")))
                {
                    newImage.Clear();
                    newImage.Add(chosenImage[0]);

                    //Uri newImageUri = new Uri(newImage[0].fullPath);

                    //image.Source = new BitmapImage(newImageUri);
                }
                else
                {
                    //showErrorMessage("Image must be in .jpg, .jpeg, or .png and less than 1 MB!");
                }
            }
        }





    }
}
