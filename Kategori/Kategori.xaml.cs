using DolanKuyDesktopPalingbaru.EditLokasi;
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
using Velacro.UIElements.TextBlock;
using Velacro.UIElements.TextBox;

namespace DolanKuyDesktopPalingbaru.Kategori
{
    /// <summary>
    /// Interaction logic for Kategori.xaml
    /// </summary>
    public partial class Kategori : MyPage
    {
        private List<ModelCategory> listServices;
        private List<int> actualId = new List<int>();
        private String token;

        public Kategori(string token)
        {
            this.token = token;
            InitializeComponent();
            //this.KeepAlive = true;
            setController(new CategoryController(this));
            initUIBuilders();
            initUIElements();
            getData();
        }

        private BuilderButton buttonBuilder;
        private BuilderTextBox txtBoxBuilder;
        private BuilderTextBlock txtBlockBuilder;
        

        private void initUIBuilders()
        {
            buttonBuilder = new BuilderButton();
            txtBoxBuilder = new BuilderTextBox();
            txtBlockBuilder = new BuilderTextBlock();
        }

        private IMyButton categoryButton;
        private IMyTextBox categoryTxtBox;
        private IMyTextBlock categoryStatusTxtBlock;



        private void initUIElements()
        {
            categoryButton = buttonBuilder.activate(this, "category_btn")
                .addOnClick(this, "onCategoryButtonClick");
            categoryTxtBox = txtBoxBuilder.activate(this, "category_txt");
            categoryStatusTxtBlock = txtBlockBuilder.activate(this, "categoryStatus");
        }

        public void onCategoryButtonClick()
        {
            getController().callMethod("postCategory",
                categoryTxtBox.getText(), this.token);
        }

        public void setCategoryStatus(string _status)
        {
            this.Dispatcher.Invoke(() => {
                categoryButton.setText(_status);
                this.NavigationService.Navigate(new Kategori(_status));
            });

        }

        public void setDelete(String response)
        {

            this.Dispatcher.Invoke((Action)(() => {

                this.NavigationService.Navigate(new Kategori(this.token));
            }));
        }

        public void getData()
        {
            getController().callMethod("getCategory");
        }

        public void setCategory(List<ModelCategory> categoryList)
        {
            this.listServices = categoryList;

            this.Dispatcher.Invoke((Action)(() => {
                serviceList.ItemsSource = categoryList;
            }));
        }

        private void deleteBtnCategory_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ModelCategory dataObject = button.DataContext as ModelCategory;
            Console.WriteLine(dataObject.id);
            MessageBoxResult result = MessageBox.Show("Are you sure want to perform this action?", "Delete Service", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    getController().callMethod("deleteCategory", dataObject.id.ToString(), this.token);

                    break;
            }
        }

        private void editBtnCategory_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ModelCategory dataObject = button.DataContext as ModelCategory;
            this.NavigationService.Navigate(new EditKategori.EditKategoriPage(this.token, dataObject));
        }
    }
}
