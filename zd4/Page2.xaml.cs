using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zd4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 :ContentPage
    {
        private Label usdLabel;
        private Label eurLabel;
        private Entry usd;
        private Label date;
        public Page2 ()
        {
            InitializeComponent( );
            
            usdLabel = new Label
            {
                Text = "USD 80.000"
                
            };

            eurLabel = new Label
            {
                Text = "EUR 86.000"

            };


            date = new Label
            {
                Text = DateTime.Today.ToString(),
                HorizontalTextAlignment = TextAlignment.End,
                FontAttributes = FontAttributes.Bold,
                TextDecorations=TextDecorations.Underline,
                Margin = new Thickness(30,0,10,0)
                
            };

            
            Content = new StackLayout
            {
                Children =
                {
                    new Label { Text = "Центробанк РФ: " },
                    new Label { Text = "Текущая дата: ",HorizontalTextAlignment=TextAlignment.End,Margin=new Thickness(0,0,10,0) },
                    date,
                    usdLabel,
                    eurLabel
                }
            };
        }
    }
}