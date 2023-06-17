using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using zd4;

namespace zd4
{
    public partial class MainPage :ContentPage
    {
        public MainPage ()
        {
            InitializeComponent( ); var welcomeLabel = new Label
            {
                StyleId = "header",
                Text = "Добро пожаловать",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            var usernameEntry = new Entry
            {
                Placeholder = "Username",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                StyleId = "stylefordroro"
            };
            var passwordEntry = new Entry
            {
                Placeholder = "Password",
                IsPassword = true,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                StyleId = "stylefordroro"
            };
            var rememberMeRadioButton = new RadioButton
            {
                Content = "Remember me",
                HorizontalOptions = LayoutOptions.Start,
                BackgroundColor = Color.White,

            };
            var signInButton = new Button
            {
                Text = "Log",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            var signInLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {                    rememberMeRadioButton,
                    signInButton,                    new Label{ Text = "I forgot!", HorizontalOptions = LayoutOptions.End }
                }
            };
            var errorMessageLabel = new Label
            {
                TextColor = Color.Red,
                HorizontalOptions = LayoutOptions.Center
            };
            var moneyBut = new Button
            {
                Text = "Деньги",
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            moneyBut.Clicked += (sender, e) =>
            {
                string username = usernameEntry.Text;
                Navigation.PushAsync(new Page2(username));
            };
            signInButton.Clicked += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(usernameEntry.Text) || string.IsNullOrWhiteSpace(passwordEntry.Text))
                {
                    errorMessageLabel.Text = "Write your password and login";
                }
                else
                {
                    string username = usernameEntry.Text;
                    string password = passwordEntry.Text;
                    Navigation.PushAsync(new Page1(username));
                }
            };

            var stackLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(30),
                Children =                {
                    welcomeLabel,                    usernameEntry,
                    passwordEntry,                    signInButton,
                    errorMessageLabel,                    rememberMeRadioButton,
                    signInLayout,                    moneyBut

                }
            };

            Content = stackLayout;

        }
    }
}