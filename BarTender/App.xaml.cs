using BarTender.View;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BarTender
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(CrossConnectivity.Current.IsConnected ? (Page)new MainPage() : new NoNetworkPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            base.OnStart();
            CrossConnectivity.Current.ConnectivityChanged += HandleConnectivityChanged;
        }

        void HandleConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            try
            {
                Type currentPage = MainPage.GetType();
                if (e.IsConnected && currentPage != typeof(MainPage))
                {
                    MainPage = new NavigationPage(new MainPage());
                }
                   
                else if (!e.IsConnected && currentPage != typeof(NoNetworkPage))
                {
                    MainPage = new NoNetworkPage();
                }
                   
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
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
