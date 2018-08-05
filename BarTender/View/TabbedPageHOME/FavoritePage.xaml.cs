using BarTender.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarTender.View.TabbedPageHOME
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FavoritePage : ContentPage
	{
		public FavoritePage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            lblLoading.IsVisible = true;
            ((App)App.Current).ResumeAtDrinkId = -1;
            lvwFavorites.ItemsSource = await App.Database.GetItemsAsync();
            lblLoading.IsVisible = false;
        }

        async void lvwFavorites_Itemseleceted(object sender, SelectedItemChangedEventArgs e)
        {
            DrinkLocal selectedCocktail = e.SelectedItem as DrinkLocal;
            RootObjectDrinks Cocktail = await CocktailManager.GetCocktailsById(selectedCocktail.idDrink);
            Navigation.PushAsync(new DetailPage(Cocktail));
        }
    }
}