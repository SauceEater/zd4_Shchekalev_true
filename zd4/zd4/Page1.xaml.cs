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


        public Page1 (string username)
        {
            InitializeComponent( );


        }


        private void picker_SelectedIndexChanged (object sender, EventArgs e)
        {
        }

        private void percentSlider_ValueChanged (object sender, ValueChangedEventArgs e)
        {
            try
            {
                double newValue = e.NewValue / 100;
                if (Convert.ToDouble(sum.Text) > 0 && Convert.ToInt32(srok.Text) > 0)
                {
                    myLabelOne.Text = $"Ежемесячный платеж: {Convert.ToString((Convert.ToDouble(sum.Text) + Convert.ToDouble(sum.Text) * newValue) / Convert.ToDouble(srok.Text))} Р";
                    myLabelTwo.Text = $"Общая сумма: {Convert.ToString((Convert.ToDouble(sum.Text) + Convert.ToDouble(sum.Text) * newValue))} Р";
                    myLabelThree.Text = $"Переплата:{Convert.ToDouble(sum.Text) * newValue} Р";
                }
                else
                {
                    myLabelOne.Text = $"Ежемесячный платеж: Error";
                    myLabelTwo.Text = $"Общая сумма: Error";
                    myLabelThree.Text = $"Переплата: Error";
                }
            }
            catch
            {
                myLabelOne.Text = $"Ежемесячный платеж: Error";
                myLabelTwo.Text = $"Общая сумма: Error";
                myLabelThree.Text = $"Переплата: Error";
            }

        }
    }
}