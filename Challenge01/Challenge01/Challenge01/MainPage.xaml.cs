using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Challenge01
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Value> _valueList = new ObservableCollection<Value>();
        public MainPage()
        {
            InitializeComponent();
            ResultsView.ItemsSource = _valueList;
        }

        private void SubmitButton_OnClicked(object sender, EventArgs e)
        {
            _valueList.Add(new Value(InputEntry.Text));
            InputEntry.Text = string.Empty;
        }

        private void SortButton_OnClicked(object sender, EventArgs e)
        {
            var sortedList = _valueList.OrderBy(x => x).ToList();
            _valueList.Clear();
            foreach (var value in sortedList)
                _valueList.Add(value);
        }
    }
}
