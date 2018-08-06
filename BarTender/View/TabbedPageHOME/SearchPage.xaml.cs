using BarTender.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarTender.View.TabbedPageHOME
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchPage : ContentPage
	{
        public List<string> categories = new List<string>();
        public List<string> glasses = new List<string>();
        public SearchPage ()
		{
			InitializeComponent ();
            getCategories();
            getGlasses();
        }
        private void btnGoToList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CocktailListTP());
        }
        public async void getCategories()
        {
            List<Drink> drinkList = await CocktailManager.GetCategory();
            for(var i = 0; i < drinkList.Count; i++)
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

        private async void pickCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblLoading.IsVisible = true;
                btnGoToList.Margin = new Thickness(30, 30, 30, 0);
                string selectedCategory = pickCategory.SelectedItem as string;
                List<Drink> drinks = await CocktailManager.getCocktailByCategory(selectedCategory);
                string filterdString = "Category: " + selectedCategory;
                string categoryPar = "Category";
                await Navigation.PushAsync(new FilterdListPage(drinks, filterdString, categoryPar));
                btnGoToList.Margin = new Thickness(30, 30, 30, 30);
                lblLoading.IsVisible = false;
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
                btnGoToList.Margin = new Thickness(30, 30, 30, 0);
                string selectedGlass = pickGlass.SelectedItem as string;
                List<Drink> drinks = await CocktailManager.getCocktailByGlass(selectedGlass);
                string filterdString = "Glass: " + selectedGlass;
                string glassPar = "Glass";
                await Navigation.PushAsync(new FilterdListPage(drinks, filterdString, glassPar));
                btnGoToList.Margin = new Thickness(30, 30, 30, 30);
                lblLoading.IsVisible = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex);
            }
        }

        private async void searchDrinks_SearchButtonPressed(object sender, EventArgs e)
        {
            lblLoading.IsVisible = true;
            btnGoToList.Margin = new Thickness(30,30,30,0); 
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
                btnGoToList.Margin = new Thickness(30, 30, 30, 30);
                string searchPar = "Search";
                await Navigation.PushAsync(new FilterdListPage(drinks, filterdString, searchPar));
            }
        }

    }
}