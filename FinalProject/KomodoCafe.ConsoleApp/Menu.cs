using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KomodoCafe.Repository
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string FoodDescription { get; set; }
        public List<string> Ingredients { get; set; } // Does it want all of them as 1 string, or an array?
        public decimal Price { get; set; }


        public Menu( int mealNumber, string mealName, string foodDescription, List<string> ingredients, decimal price )
        {
            MealNumber = mealNumber;
            MealName = mealName;
            FoodDescription = foodDescription;
            Ingredients = ingredients;
            Price = price;

        }
    }

}