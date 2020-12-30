using DolanKuyDesktopPalingbaru.Login;
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
using Velacro.UIElements.PasswordBox;

namespace DolanKuyDesktopPalingbaru
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MyWindow
    {

        private BuilderButton buttonBuilder;
        private BuilderTextBox txtBoxBuilder;
        private BuilderPasswordBox passBoxBuilder;
        private BuilderTextBlock txtBlockBuilder;
        private IMyButton loginButton;
        private IMyTextBox emailTxtBox;
        private IMyPasswordBox passwordTxtBox;
        private IMyTextBlock loginStatusTxtBlock;
        private MyWindow dashboard;
        //private MyPage dashboard = new Dashboard.Dashboard();

        public MainWindow()
        {
            InitializeComponent();
            //this.KeepAlive = true;
            setController(new LoginController(this));
            initUIBuilders();
            initUIElements();
        }

        private void initUIBuilders()
        {
            buttonBuilder = new BuilderButton();
            txtBoxBuilder = new BuilderTextBox();
            txtBlockBuilder = new BuilderTextBlock();
            passBoxBuilder = new BuilderPasswordBox();
        }

        private void initUIElements()
        {
            
            loginButton = buttonBuilder
                .activate(this, "loginButton_btn")
                .addOnClick(this, "onLoginButtonClick");
            emailTxtBox = txtBoxBuilder.activate(this, "email_txt");
            passwordTxtBox = passBoxBuilder.activate(this, "password_txt");
            loginStatusTxtBlock = txtBlockBuilder.activate(this, "loginStatus");
        }

        public void onLoginButtonClick()
        {
            getController().callMethod("login", emailTxtBox.getText(), passwordTxtBox.getPassword());
            

        }


        public void setLoginStatus(string _status)
        {
            this.Dispatcher.Invoke(() =>
            {
                dashboard = new Dashboard.Dashboard(_status);
                loginButton.setText(_status);
                dashboard.Show();
            });
            
        }

    }
}
