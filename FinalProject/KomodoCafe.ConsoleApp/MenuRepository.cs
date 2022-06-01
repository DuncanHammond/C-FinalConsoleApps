using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KomodoCafe.Repository
{
    public class MenuRepository
    {
        private List<Menu> _menuList = new List<Menu>();
        public List<Menu> GetAllMenusFromList()
        {
            return _menuList;
        }

        public Menu GetMenuFromListByMealName(string userInputMenuNameSearch)
        {
            foreach (Menu menu in _menuList)
            {
                if (menu.MealName.ToUpper() == userInputMenuNameSearch.ToUpper())
                {
                    return menu;
                }
            }
            return null;
        }

        public void AddFoodToMenu(Menu menu)
        {
            _menuList.Add(menu);
        }

        public bool UpdateMenu(Menu menu)
        {
            foreach (Menu existingMenu in _menuList)
            {
                if (existingMenu.MealName.ToUpper() == menu.MealName.ToUpper())
                {
                    existingMenu.MealNumber = menu.MealNumber;
                    existingMenu.MealName = menu.MealName;
                    existingMenu.FoodDescription = menu.FoodDescription;
                    existingMenu.Ingredients = menu.Ingredients;
                    existingMenu.Price = menu.Price;

                    return true;
                }
            }
            return false;
        }

        public bool UpdateMenu(Menu menu, string title)
        {
            foreach (Menu existingMenu in _menuList)
            {
                if (existingMenu.MealName.ToUpper() == title.ToUpper())
                {
                    existingMenu.MealNumber = menu.MealNumber;
                    existingMenu.MealName = menu.MealName;
                    existingMenu.FoodDescription = menu.FoodDescription;
                    existingMenu.Ingredients = menu.Ingredients;
                    existingMenu.Price = menu.Price;

                    return true;
                }
            }
            return false;
        }

        public bool DeleteMenuByMealName(string title)
        {
            foreach (Menu menu in _menuList)
            {
                if (menu.MealName.ToUpper() == title.ToUpper())
                {
                    _menuList.Remove(menu);
                    return true;
                }
            }
            return false;
        }


        public void BaseMenuItems()
        {
            Menu CheeseBurger = new Menu( 1, "Cheese Burger", "Classic American burger between to buns", new List<string> { "Beef", "Pepper Jack Cheese", "Mayo", "Tomato"}, 7.99m );
            Menu Burrito = new Menu( 2, "Burrito", "Authentic Mexican Cuisine",  new List<string> { "Tortilla", "Shredded Cheese", "Shredded Chicken", "Fajita Veggies"} , 8.99m );
            Menu Taco = new Menu( 3, "Taco", "Perfect for Taco Tuesday!",  new List<string> { "Beef", "Shredded Cheese", "Lettuce", "Pico"}, 6.99m );
            Menu Pasta = new Menu( 4, "Pasta", "Name brand Mac and Cheese",  new List<string> { "Mac", "Cheese"}, 5.99m );
            Menu Pizza = new Menu( 5, "Pizza", "Italian platter from the gods",  new List<string> { "Pepperoni", "Salami", "Sausage", "Cheese"}, 11.99m );

            // int mealNumber, string mealName, string foodDescription, string ingredients, int price

            Menu[] menusArr = { CheeseBurger, Burrito, Taco, Pasta, Pizza };

            foreach (Menu menu in menusArr)
            {
                AddFoodToMenu(menu);
            }
        }
    }
}