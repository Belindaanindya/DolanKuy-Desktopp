using DolanKuyDesktopPalingbaru.Kategori;
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

namespace DolanKuyDesktopPalingbaru.EditKategori
{
    /// <summary>
    /// Interaction logic for EditKategoriPage.xaml
    /// </summary>
    public partial class EditKategoriPage : MyPage
    {

        private String token;
        private ModelCategory modelCategory;
        private IMyTextBox categoryTxtBox;
        private BuilderButton buttonBuilder;
        private BuilderTextBox txtBoxBuilder;

        public EditKategoriPage(string token, ModelCategory modelCategory)
        {
            this.token = token;
            this.modelCategory = modelCategory;
            InitializeComponent();
            initUIBuilders();
            initUIElements();
            setController(new CategoryController(this));

        }

        private void initUIBuilders()
        {
            buttonBuilder = new BuilderButton();
            txtBoxBuilder = new BuilderTextBox();
        }

        private void initUIElements()
        {
            categoryTxtBox = txtBoxBuilder.activate(this, "category_txt");
            categoryTxtBox.setText(modelCategory.name);
        }

        private void back_btn_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Kategori.Kategori(this.token));
        }

        private void category_btn_Click(object sender, RoutedEventArgs e)
        {
            getController().callMethod("editCategory", categoryTxtBox.getText(), this.token, modelCategory.id.ToString());
        }

        public void setCategoryStatus(string token)
        {
            this.Dispatcher.Invoke((Action)(() => {
                this.NavigationService.Navigate(new Kategori.Kategori(token));
            }));
        }

    }
}
