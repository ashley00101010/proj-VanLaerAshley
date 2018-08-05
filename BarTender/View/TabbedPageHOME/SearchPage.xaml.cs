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
    }
}