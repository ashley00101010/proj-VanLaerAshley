using System;
using System.Collections.Generic;
using System.Text;

namespace BarTender.Model
{

    public class RootobjectCategory
    {
        public Category[] categories { get; set; }
    }

    public class Category
    {
        public string strDrink { get; set; }
        public string strDrinkThumb { get; set; }
        public string idDrink { get; set; }
    }

}
