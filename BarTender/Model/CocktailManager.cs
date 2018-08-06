using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BarTender.Model
{
    class CocktailManager
    {
        public const string APIKEY = "1";

        

        public async static Task<List<Drink>> GetCocktailsAlcoholic()
        {
            try
            {
                String url = String.Format("https://www.thecocktaildb.com/api/json/v1/{0}/filter.php?a=Alcoholic", APIKEY);

                string result;
                using (HttpClient client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    result = await client.GetStringAsync(url);
                }

                RootObjectDrinks rootObject = JsonConvert.DeserializeObject<RootObjectDrinks>(result);
                List<Drink> drinks = rootObject.drinks.ToList();

                return drinks;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e);
            }
            return null;
        }

        public async static Task<List<Drink>> GetCocktailsNONAlcoholic()
        {
            try
            {
                String url = String.Format("https://www.thecocktaildb.com/api/json/v1/{0}/filter.php?a=Non_Alcoholic", APIKEY);

                string result;
                using (HttpClient client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    result = await client.GetStringAsync(url);
                }

                RootObjectDrinks rootObject = JsonConvert.DeserializeObject<RootObjectDrinks>(result);
                List<Drink> drinks = rootObject.drinks.ToList();

                return drinks;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e);
            }
            return null;
        }

        public async static Task<List<Drink>> GetCocktailsOptionalAlcoholic()
        {
            try
            {
                String url = String.Format("https://www.thecocktaildb.com/api/json/v1/{0}/filter.php?a=Optional_alcohol", APIKEY);

                string result;
                using (HttpClient client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    result = await client.GetStringAsync(url);
                }

                RootObjectDrinks rootObject = JsonConvert.DeserializeObject<RootObjectDrinks>(result);
                List<Drink> drinks = rootObject.drinks.ToList();

                return drinks;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e);
            }
            return null;
        }

        public async static Task<RootObjectDrinks> GetCocktailsById(string Id)
        {
            try
            {
                String url = String.Format("https://www.thecocktaildb.com/api/json/v1/{0}/lookup.php?i={1}", APIKEY, Id);

                string result;
                using (HttpClient client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    result = await client.GetStringAsync(url);
                }
                RootObjectDrinks rootObject = JsonConvert.DeserializeObject<RootObjectDrinks>(result);
                
                return rootObject;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e);
            }
            return null;
        }
        public async static Task<List<Drink>> GetCategory()
        {
            try
            {
                String url = String.Format("https://www.thecocktaildb.com/api/json/v1/{0}/list.php?c=list", APIKEY);

                string result;
                using (HttpClient client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    result = await client.GetStringAsync(url);
                }

                RootObjectDrinks rootObject = JsonConvert.DeserializeObject<RootObjectDrinks>(result);
                List<Drink> drinks = rootObject.drinks.ToList();

                return drinks;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e);
            }
            return null;
        }

        public async static Task<List<Drink>> GetGlass()
        {
            try
            {
                String url = String.Format("https://www.thecocktaildb.com/api/json/v1/{0}/list.php?g=list", APIKEY);

                string result;
                using (HttpClient client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    result = await client.GetStringAsync(url);
                }

                RootObjectDrinks rootObject = JsonConvert.DeserializeObject<RootObjectDrinks>(result);
                List<Drink> drinks = rootObject.drinks.ToList();

                return drinks;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e);
            }
            return null;
        }
    

        public async static Task<List<Drink>> getCocktailByCategory(string category)
        {
            String url = String.Format("https://www.thecocktaildb.com/api/json/v1/{0}/filter.php?c={1}", APIKEY, category);
            string result;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                result = await client.GetStringAsync(url);
            }

            RootObjectDrinks rootobject = JsonConvert.DeserializeObject<RootObjectDrinks>(result);
            List<Drink> drinks = rootobject.drinks.ToList();

            return drinks;

        }

        public async static Task<List<Drink>> getCocktailByGlass(string glass)
        {
            String url = String.Format("https://www.thecocktaildb.com/api/json/v1/{0}/filter.php?g={1}", APIKEY, glass);
            string result;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                result = await client.GetStringAsync(url);
            }

            RootObjectDrinks rootobject = JsonConvert.DeserializeObject<RootObjectDrinks>(result);
            List<Drink> drinks = rootobject.drinks.ToList();

            return drinks;

        }
        public async static Task<List<Drink>> getCocktailBySearch(string search)
        {
            try
            {
                String url = String.Format("https://www.thecocktaildb.com/api/json/v1/{0}/search.php?s={1}", APIKEY, search);
                string result;

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    result = await client.GetStringAsync(url);
                }

                RootObjectDrinks rootobject = JsonConvert.DeserializeObject<RootObjectDrinks>(result);
                List<Drink> drinks = rootobject.drinks.ToList();

                return drinks;
            }
           catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e);
            }
            return null;

        }
    }
}
