using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Paperboy.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage1 : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public ListViewPage1()
        {
            InitializeComponent();

            Items = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };

            Analytics.TrackEvent("Loading list view page...");

            BindingContext = this;
        }

        async void Handle_ItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                Analytics.TrackEvent("A list view item was clicked... " + e.SelectedItem.ToString());
                bool didAppCrash = await Crashes.HasCrashedInLastSessionAsync();

                if(!didAppCrash)
                {
                    throw new Exception("Some test crashes...");
                }

                //if (e.SelectedItem == null)
                //    return;

                //await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

                ////Deselect Item
                //((ListView)sender).SelectedItem = null;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Just Crashed", ex.Message, "OK");
                Crashes.GenerateTestCrash();
            }
            
        }
    }
}