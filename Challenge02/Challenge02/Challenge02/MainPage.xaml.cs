using System;
using System.Globalization;
using Xamarin.Forms;

namespace Challenge02
{
    public partial class MainPage : ContentPage
    {
        private ChangeMaker _changeMaker = new ChangeMaker();

        public MainPage()
        {
            Inflector.Inflector.SetDefaultCultureFunc = () => CultureInfo.CurrentUICulture;
            InitializeComponent();
        }

        private void MakeChange_OnClicked(object sender, EventArgs e)
        {
            _changeMaker.Reset();
            OutputLabel.Text = string.Empty;

            decimal changeToMake;
            if (!decimal.TryParse(MoneyEntry.Text, out changeToMake))
                DisplayAlert("Whoops!", "I can only make change on numbers.", "My Bad.");
            else
            {
                _changeMaker.MakeChange(changeToMake);
                OutputLabel.Text = _changeMaker.ToString();
            }
        }
    }
}
