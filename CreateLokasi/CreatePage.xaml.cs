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

namespace DolanKuyDesktopPalingbaru.CreateLokasi
{
    /// <summary>
    /// Interaction logic for CreatePage.xaml
    /// </summary>
    public partial class CreatePage : MyPage
    {
        public CreatePage()
        {
            InitializeComponent();
            this.KeepAlive = true;
            setController(new CreateController(this));
            initUIBuilders();
            initUIElements();
        }

        private BuilderButton buttonBuilder;
        private BuilderTextBox txtBoxBuilder;
        private BuilderTextBlock txtBlockBuilder;
        //private int id = 8;

        private void initUIBuilders()
        {
            buttonBuilder = new BuilderButton();
            txtBoxBuilder = new BuilderTextBox();
            txtBlockBuilder = new BuilderTextBlock();
        }

        private IMyButton createButton;
        private IMyTextBox name_tb1;
        private IMyTextBox description_tb1;
        private IMyTextBox address_tb1;
        private IMyTextBox contact_tb1;
        private IMyTextBox longitude_tb1;
        private IMyTextBox latitude_tb1;
        private IMyTextBox image_tb1;
        private IMyTextBox category_tb1;

        private IMyTextBlock createStatusTxtBlock;

        private void initUIElements()
        {
            createButton = buttonBuilder.activate(this, "create_btn")
                .addOnClick(this, "onCreateButtonClick");

            name_tb1 = txtBoxBuilder.activate(this, "name_tb");
            description_tb1 = txtBoxBuilder.activate(this, "description_tb");
            address_tb1 = txtBoxBuilder.activate(this, "address_tb");
            contact_tb1 = txtBoxBuilder.activate(this, "contact_tb");
            latitude_tb1 = txtBoxBuilder.activate(this, "latitude_tb");
            longitude_tb1 = txtBoxBuilder.activate(this, "longitude_tb");
            image_tb1 = txtBoxBuilder.activate(this, "image_tb");
            category_tb1 = txtBoxBuilder.activate(this, "category_tb");
            //createStatusTxtBlock = txtBlockBuilder.activate(this, "registerStatus");
        }

        public void onCreateButtonClick()
        {
            getController().callMethod("create",

                name_tb1.getText(),
                description_tb1.getText(),
                address_tb1.getText(),
                contact_tb1.getText().ToString(),
                latitude_tb1.getText(),
                longitude_tb1.getText(),
                image_tb1.getText(),
                category_tb1.getText()
            );
        }

        public void setRegisterStatus(string _status)
        {
            this.Dispatcher.Invoke(() => {
                createButton.setText(_status);
            });

        }
    }
}
