using BarTender.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTender.Data
{
    public class BarTenderLocalDatabase
    {
        readonly SQLiteAsyncConnection database;

        public BarTenderLocalDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<DrinkLocal>().Wait();
        }

        public Task<List<DrinkLocal>> GetItemsAsync()
        {
            return database.Table<DrinkLocal>().ToListAsync();
        }

        public Task<List<DrinkLocal>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<DrinkLocal>("SELECT * FROM [DrinkLocal] ");
        }

        public Task<DrinkLocal> GetItemAsync(int id)
        {
            return database.Table<DrinkLocal>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(DrinkLocal item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(DrinkLocal item)
        {
            var drink = database.Table<DrinkLocal>().Where(i => i.idDrink == item.idDrink).FirstOrDefaultAsync();
            //if(drink.Result.idDrink == item.idDrink)
            var result = drink.Result;
            return database.DeleteAsync(result);
        }

        public Task<DrinkLocal> GetDrink(string drink)
        {
            try
            {
                return database.Table<DrinkLocal>().Where(i => i.idDrink == drink).FirstOrDefaultAsync();
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e);
                throw(e);
            }
           
        }
    }
}
