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
        public SearchPage ()
		{
			InitializeComponent ();
            getCategories();

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

        private async void pickCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblLoading.IsVisible = true;
                string selectedCategory = pickCategory.SelectedItem as string;
                List<Drink> drinks = await CocktailManager.getEventByCategory(selectedCategory);
                string filterdString = "Category: " + selectedCategory;
                await Navigation.PushAsync(new FilterdListPage(drinks, filterdString));
                lblLoading.IsVisible = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex);
            }
        }

        
    }
}