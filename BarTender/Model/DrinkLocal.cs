using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarTender.Model
{
    public class DrinkLocal
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string idDrink { get; set; }

        public string strDrink { get; set; }

        public string strDrinkThumb { get; set; }
    }
}
