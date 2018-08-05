using BarTender.Data;
using BarTender.View;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BarTender
{
    public partial class App : Application
    {

        static BarTenderLocalDatabase database;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(CrossConnectivity.Current.IsConnected ? (Page)new MainPage() : new NoNetworkPage());
        }

        public static BarTenderLocalDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new BarTenderLocalDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BarTenderAppsSQLite.db3"));
                }
                return database;
            }
        }

        public int ResumeAtDrinkId { get; set; }

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
