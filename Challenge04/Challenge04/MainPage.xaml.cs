using System;
using Xamarin.Forms;

namespace Challenge04
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void CalculateButton_OnClicked(object sender, EventArgs e)
        {
            Result.Text = FormulaEntry.Text.ToPostfix().Calculate().ToString();
        }
    }
}
