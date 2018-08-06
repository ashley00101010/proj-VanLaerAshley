using BarTender.Model;
using SQLite;
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
    public partial class DetailPage : ContentPage
    {
        readonly SQLiteAsyncConnection database;
        public DetailPage(RootObjectDrinks item)
        {
            InitializeComponent();
            showCocktail(item);
            ShowButtons(item);
        }



        private async void showCocktail(RootObjectDrinks item)
        {
            RootObjectDrinks Cocktail = await CocktailManager.GetCocktailsById(item.drinks[0].idDrink);
            imgCocktail.Source = Cocktail.drinks[0].strDrinkThumb;
            lblId.Text = Cocktail.drinks[0].idDrink;
            lblName.Text = Cocktail.drinks[0].strDrink;
            lblCategory.Text = Cocktail.drinks[0].strCategory;
            lblDescription.Text = Cocktail.drinks[0].strInstructions;

            string Ingredients1 = Cocktail.drinks[0].strMeasure1 + Cocktail.drinks[0].strIngredient1
                        + "\n " + Cocktail.drinks[0].strMeasure2 + Cocktail.drinks[0].strIngredient2
                        + "\n " + Cocktail.drinks[0].strMeasure3 + Cocktail.drinks[0].strIngredient3
                        + "\n " + Cocktail.drinks[0].strMeasure4 + Cocktail.drinks[0].strIngredient4
                        + "\n " + Cocktail.drinks[0].strMeasure5 + Cocktail.drinks[0].strIngredient5
                        + "\n " + Cocktail.drinks[0].strMeasure6 + Cocktail.drinks[0].strIngredient6
                        + "\n " + Cocktail.drinks[0].strMeasure7 + Cocktail.drinks[0].strIngredient7;

            string Ingredients2 = "\n " + Cocktail.drinks[0].strMeasure8 + Cocktail.drinks[0].strIngredient8
                        + "\n " + Cocktail.drinks[0].strMeasure9 + Cocktail.drinks[0].strIngredient9
                        + "\n " + Cocktail.drinks[0].strMeasure10 + Cocktail.drinks[0].strIngredient10
                        + "\n " + Cocktail.drinks[0].strMeasure11 + Cocktail.drinks[0].strIngredient11
                        + "\n " + Cocktail.drinks[0].strMeasure12 + Cocktail.drinks[0].strIngredient12
                        + "\n " + Cocktail.drinks[0].strMeasure13 + Cocktail.drinks[0].strIngredient13
                        + "\n " + Cocktail.drinks[0].strMeasure14 + Cocktail.drinks[0].strIngredient14
                        + "\n " + Cocktail.drinks[0].strMeasure15 + Cocktail.drinks[0].strIngredient15;

          

            lblIngredients1.Text = Ingredients1;
            lblIngredients2.Text = Ingredients2;




        }

        async void OnSaveClicked(object sender, EventArgs e, RootObjectDrinks item)
        {

            await App.Database.SaveItemAsync(new DrinkLocal
            {
                idDrink = lblId.Text,
                strDrink = lblName.Text,
                strDrinkThumb = imgCocktail.Source.ToString().Replace("Uri: ", "")
            });
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            await App.Database.DeleteItemAsync(new DrinkLocal()
            {
                idDrink = lblId.Text,
                strDrink = lblName.Text,
                strDrinkThumb = imgCocktail.Source.ToString()
            });
            await Navigation.PopAsync();
        }
        private void ShowButtons(RootObjectDrinks item)
        {
            base.OnAppearing();
            var drink = item.drinks[0].idDrink;
            string drinkId = "";
            try
            {
                drinkId = App.Database.GetDrink(drink).Result.idDrink.ToString();
            }
            catch
            {
                drinkId = "";
            }
            if (drinkId != item.drinks[0].idDrink || drinkId == null)
            {
                btnDelete.IsVisible = false;
                btnSave.IsVisible = true;
            }
            else
            {
                btnDelete.IsVisible = true;
                btnSave.IsVisible = false;
            }

        }
    }
}