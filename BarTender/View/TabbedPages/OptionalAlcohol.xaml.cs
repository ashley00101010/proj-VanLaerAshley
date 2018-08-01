using BarTender.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarTender.View.TabbedPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OptionalAlcohol : ContentPage
	{
		public OptionalAlcohol ()
		{
			InitializeComponent ();
            showListCocktails();

        }

        private async void showListCocktails()
        {
            lblLoading.IsVisible = true;
            List<Drink> AllCocktails = await CocktailManager.GetCocktailsOptionalAlcoholic();
            lvwCocktails.ItemsSource = AllCocktails;
            lblLoading.IsVisible = false;
        }

        private async void lvwCocktails_Itemseleceted(object sender, SelectedItemChangedEventArgs e)
        {
            Drink selectedCocktail = lvwCocktails.SelectedItem as Drink;
            RootObjectDrinks Cocktail = await CocktailManager.GetCocktailsById(selectedCocktail.idDrink);
            Navigation.PushAsync(new DetailPage(Cocktail));
        }
    }
}