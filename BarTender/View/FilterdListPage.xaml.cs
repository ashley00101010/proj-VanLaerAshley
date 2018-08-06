using BarTender.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarTender.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FilterdListPage : ContentPage
	{
		public FilterdListPage (List<Drink> drinks, string filterd)
		{
			InitializeComponent ();
            Title = filterd;
            showCocktails(drinks);
        }

        public void showCocktails(List<Drink> drinks)
        {
            if(drinks == null)
            {
                NoCocktails.IsVisible = true;
            }
            else
            {
                NoCocktails.IsVisible = false;
                lvwDrinks.ItemsSource = drinks;
            }
        }

        private async void lvwCocktails_Itemseleceted(object sender, SelectedItemChangedEventArgs e)
        {
            Drink selectedCocktail = lvwDrinks.SelectedItem as Drink;
            RootObjectDrinks Cocktail = await CocktailManager.GetCocktailsById(selectedCocktail.idDrink);
            Navigation.PushAsync(new DetailPage(Cocktail));
        }

        private async void searchDrinks_SearchButtonPressed(object sender, EventArgs e)
        {
            lblLoading.IsVisible = true;
            string searchInput = searchDrinks.Text;
            if (searchInput != "")
            {
                List<Drink> drinks = await CocktailManager.getCocktailBySearch(searchInput);
                string filterdString = null;
                if (drinks == null)
                {
                    filterdString = "Nothing found for: " + searchInput;
                }
                else
                {
                    filterdString = "Search Results: " + searchInput;
                }
                lblLoading.IsVisible = false;
                showCocktails(drinks);
                Title = filterdString;
            }
        }
    }
}