using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace zd4
{
    public partial class MainPage :TabbedPage
    {
        private Entry loanAmountEnrty;
        private Entry loanTermEnrty;
        private Picker paymentTypePicker;
        private Slider interestRateSlider;
        private Label monthlyPaymentLabel;
        private Label totalAmountLabel;
        private Label overpaymentLabel;
        public MainPage ()
        {
            InitializeComponent( );
            
        }
        public class App :Application
        {
            public App ()
            {
                MainPage = new TabbedPage
                {
                    Children =
                    {
                        new Page1 {Title = "Кридитный калькулятор"},
                        new Page2{Title = "Курсы валют"}
                    }
                };
            }
        }
    }
}
