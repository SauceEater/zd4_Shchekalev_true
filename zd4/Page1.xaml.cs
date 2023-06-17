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
    public partial class Page1 :ContentPage
    {
        private Entry loanAmountEnrty;
        private Entry loanTermEnrty;
        private Picker paymentTypePicker;
        private Slider interestRateSlider;
        private Label monthlyPaymentLabel;
        private Label totalAmountLabel;
        private Label overpaymentLabel;
        public Page1 ()
        {
            InitializeComponent( );
            loanAmountEnrty = new Entry
            {
                Placeholder = "Сумма кредита"
            };
            loanTermEnrty = new Entry
            {
                Placeholder = "Срок (месяцев)"
            };
            paymentTypePicker = new Picker
            {
                Title = "Вид платежа"
            };
            paymentTypePicker.Items.Add("Аннуитетный");
            interestRateSlider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = 5
            };
            monthlyPaymentLabel = new Label
            {
                Text = "Ежемесячный платеж: "
            };
            totalAmountLabel = new Label
            {
                Text = "Общая сумма: "
            };
            overpaymentLabel = new Label
            {
                Text = "Переплата: "
            };
            loanAmountEnrty.TextChanged += UpdateCalculation;
            loanTermEnrty.TextChanged += UpdateCalculation;
            paymentTypePicker.SelectedIndexChanged += UpdateCalculation;
            interestRateSlider.ValueChanged += UpdateCalculation;
            Content = new StackLayout
            {
                Children =
                {
                    loanAmountEnrty,
                    loanTermEnrty,
                    paymentTypePicker,
                    new Label {Text = "Процентная ставка: "},
                    interestRateSlider,
                    monthlyPaymentLabel,
                    totalAmountLabel,
                    overpaymentLabel
                }
            };
        }
        private void UpdateCalculation (object sender, EventArgs e)
        {
            double loanAmount;
            double.TryParse(loanAmountEnrty.Text, out loanAmount);
            int loanTerm;
            int.TryParse(loanAmountEnrty.Text, out loanTerm);
            double interestRate = interestRateSlider.Value;
            double monthlyPayment = 0;
            double totalAmount = 0;
            double overpayment = 0;
            if ( paymentTypePicker.SelectedIndex == 0 )
            {
                double monthlyInterestRate = interestRate / 100 / 12;
                double factor = Math.Pow(1 + monthlyInterestRate, loanTerm);
                monthlyPayment = loanAmount * monthlyInterestRate * factor / (factor - 1);
                totalAmount = monthlyPayment * loanTerm;
                overpayment = totalAmount - loanAmount;
            }
            monthlyPaymentLabel.Text = $"Ежемесячный платеж: {monthlyPayment}$";
            totalAmountLabel.Text = $"Общая сумма: {totalAmount}$";
            overpaymentLabel.Text = $"Переплата: {overpayment}$";
        }
    }
}