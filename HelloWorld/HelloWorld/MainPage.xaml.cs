using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloWorld
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool isEmailEmpty =  string.IsNullOrEmpty(usernameEntry.Text);
            bool isPassowrdEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            if(isEmailEmpty)
            {
                errorLabel.Text = "vul bijde velden in!";
            } 
            else if(isPassowrdEmpty)
            {
                errorLabel.Text = "vul bijde velden in!";
            } 
            else
            {
                errorLabel.Text = "";
                Navigation.PushAsync(new HomaPage());
            }
        }
    }
}
