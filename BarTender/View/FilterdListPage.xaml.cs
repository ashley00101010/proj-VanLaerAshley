using BarTender.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public List<string> categories = new List<string>();
        public List<string> glasses = new List<string>();
        public FilterdListPage (List<Drink> drinks, string filterd, string specifyFilter)
		{
			InitializeComponent ();
            Title = filterd;
            getCategories();
            getGlasses();
            showCocktails(drinks);
            if(specifyFilter == "Category")
            {
                pickCategory.IsVisible = true;
                searchDrinks.IsVisible = false;
                pickGlass.IsVisible = false;
            }
            else if(specifyFilter == "Search")
            {
                pickCategory.IsVisible = false;
                searchDrinks.IsVisible = true;
                pickGlass.IsVisible = false;
            }
            else
            {
                pickCategory.IsVisible = false;
                searchDrinks.IsVisible = false;
                pickGlass.IsVisible = true;
            }
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

        private async void pickCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblLoading.IsVisible = true;
                string selectedCategory = pickCategory.SelectedItem as string;
                List<Drink> drinks = await CocktailManager.getCocktailByCategory(selectedCategory);
                string filterdString = "Category: " + selectedCategory;
                lblLoading.IsVisible = false;
                showCocktails(drinks);
                Title = filterdString;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex);
            }
        }

        private async void pickGlass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblLoading.IsVisible = true;
                string selectedGlass = pickGlass.SelectedItem as string;
                List<Drink> drinks = await CocktailManager.getCocktailByGlass(selectedGlass);
                string filterdString = "Glass: " + selectedGlass;
                lblLoading.IsVisible = false;
                showCocktails(drinks);
                Title = filterdString;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex);
            }
        }

        public async void getCategories()
        {
            List<Drink> drinkList = await CocktailManager.GetCategory();
            for (var i = 0; i < drinkList.Count; i++)
            {
                categories.Add(drinkList[i].strCategory);
            }
            pickCategory.ItemsSource = categories;
        }
        public async void getGlasses()
        {
            List<Drink> drinkList = await CocktailManager.GetGlass();
            for (var i = 0; i < drinkList.Count; i++)
            {
                glasses.Add(drinkList[i].strGlass);
            }
            pickGlass.ItemsSource = glasses;
        }
    }
}