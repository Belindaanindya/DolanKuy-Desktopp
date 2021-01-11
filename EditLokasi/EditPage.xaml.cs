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

namespace DolanKuyDesktopPalingbaru.EditLokasi
{
    /// <summary>
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : MyPage
    {
        int id;

        public EditPage(int id)
        {
            InitializeComponent();
            this.KeepAlive = true;
            setController(new EditController(this));
            initUIBuilders();
            initUIElements();
            this.id = id;
        }

        private void setController(EditController editController)
        {
            // throw new NotImplementedException();
        }

        /*public static implicit operator MyPage(EditPage v)
        {
            throw new NotImplementedException();
        }*/

        private BuilderButton buttonBuilder;
        private BuilderTextBox txtBoxBuilder;
        private BuilderTextBlock txtBlockBuilder;
        private IMyButton editButton;
        private IMyTextBox editName_tb1;
        private IMyTextBox editDescription_tb1;
        private IMyTextBox editAddress_tb1;
        private IMyTextBox editContact_tb1;
        private IMyTextBox editLongitude_tb1;
        private IMyTextBox editLatitude_tb1;
        private IMyTextBox editImage_tb1;
        private IMyTextBox editCategory_tb1;

        private void initUIBuilders()
        {
            buttonBuilder = new BuilderButton();
            txtBoxBuilder = new BuilderTextBox();
            txtBlockBuilder = new BuilderTextBlock();
        }

        private void initUIElements()
        {
            editButton = buttonBuilder.activate(this, "edit_btn")
                .addOnClick(this, "onEditButtonClick");

            editName_tb1 = txtBoxBuilder.activate(this, "name_tb");
            editDescription_tb1 = txtBoxBuilder.activate(this, "description_tb");
            editAddress_tb1 = txtBoxBuilder.activate(this, "address_tb");
            editContact_tb1 = txtBoxBuilder.activate(this, "contact_tb");
            editLatitude_tb1 = txtBoxBuilder.activate(this, "latitude_tb");
            editLongitude_tb1 = txtBoxBuilder.activate(this, "longitude_tb");
            editImage_tb1 = txtBoxBuilder.activate(this, "image_tb");
            editCategory_tb1 = txtBoxBuilder.activate(this, "category_tb");
            //createStatusTxtBlock = txtBlockBuilder.activate(this, "registerStatus");
        }

        public void onEditButtonClick()
        {
            getController().callMethod("edit",

                editName_tb1.getText(),
                editDescription_tb1.getText(),
                editAddress_tb1.getText(),
                editContact_tb1.getText().ToString(),
                editLatitude_tb1.getText(),
                editLongitude_tb1.getText(),
                editImage_tb1.getText(),
                editCategory_tb1.getText()
            );
        }

        public void setRegisterStatus(string _status)
        {
            this.Dispatcher.Invoke(() => {
                editButton.setText(_status);
            });

        }


    }
}
