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
            lvwDrinks.ItemsSource = drinks;
        }

        private async void lvwCocktails_Itemseleceted(object sender, SelectedItemChangedEventArgs e)
        {
            Drink selectedCocktail = lvwDrinks.SelectedItem as Drink;
            RootObjectDrinks Cocktail = await CocktailManager.GetCocktailsById(selectedCocktail.idDrink);
            Navigation.PushAsync(new DetailPage(Cocktail));
        }
    }
}