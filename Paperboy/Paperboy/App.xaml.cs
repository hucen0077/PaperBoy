using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;


using Xamarin.Forms;

namespace Paperboy
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Paperboy.Pages.ListViewPage1();
        }

        protected override void OnStart()
        {
            // Handle when your app starts

            //App Center
            AppCenter.Start("android=163a132e-f7ab-4b25-9f1b-ca11fb3ae36d", typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
