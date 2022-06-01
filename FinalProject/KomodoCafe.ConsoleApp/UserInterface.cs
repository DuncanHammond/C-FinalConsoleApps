using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KomodoCafe.Repository;

namespace KomodoCafe.ConsoleApp
{
    public class UserInterface
    {
        MenuRepository _menuRepository = new MenuRepository();
        bool isRunning = true;

        public void Run()
        {
            _menuRepository.BaseMenuItems();

            while (isRunning)
            {
                PrintMainMenu();

                string input = GetUserInput();

                UserInputSwitchCase(input);
            }
        }

        private void PrintMainMenu()
        {
            Console.WriteLine("\n1. Add new item to menu.\n" +
                    "2. View all menu items.\n" +
                    "3. Edit menu.\n" +
                    "4. Delete menu item.\n" +
                    "5. Exit.\n"
            );

            Console.WriteLine("Enter number choice: ");
        }

        private string GetUserInput()
        {
            return Console.ReadLine();
        }

        private void UserInputSwitchCase(string input)
        {
            switch (input)
            {
                case "1":
                    CreateNewMenu();
                    break;
                case "2":
                    ViewAllMenus();
                    break;
                case "3":
                    EditMenu();
                    break;
                case "4":
                    DeleteMenu();
                    break;
                case "5":
                    isRunning = false;
                    ExitApplication();
                    break;
                default:
                    break;
            }
        }

        private void CreateNewMenu()
        {
            Console.WriteLine("Create a new menu item.");

            Console.WriteLine("Meal Name: ");
            string mealName = GetUserInput();

            Console.WriteLine("Food Description: ");
            string foodDescription = GetUserInput();

            Console.WriteLine("Enter Meal Number: ");
            int mealNumber = Convert.ToInt32(GetUserInput());

            Console.Write("Enter Price: $");
            decimal price = Convert.ToDecimal(GetUserInput());

            string addIngredient;
            List<string> Ingredients = new List<string>();
            bool addMoreIngrediants = true;

            while (addMoreIngrediants)
            {
                Console.WriteLine("Enter ingredient: ");
                addIngredient = GetUserInput();
                Ingredients.Add(addIngredient);
                Console.WriteLine("Add another ingredient? y/n");
                string ingredientAnswer = Convert.ToString(Console.ReadLine());
                
                if (ingredientAnswer == "n")
                {
                    addMoreIngrediants = false;
                }
            }



            Menu newMenu = new Menu(mealNumber, mealName, foodDescription, Ingredients, price);

            _menuRepository.AddFoodToMenu(newMenu);
        }


        private void PrintMenu(Menu menu)
        {
            Console.WriteLine($"\n{menu.MealName}\n" +
                    $"Meal Number: {menu.MealNumber}\n" +
                    $"Description: {menu.FoodDescription}\n");

            Console.WriteLine("Ingredients: ");
            menu.Ingredients.ForEach(item => 
                Console.WriteLine(item)
            );
            Console.WriteLine($"Price: ${menu.Price}\n");
        }

        private void ViewAllMenus()
        {
            List<Menu> allMenus = _menuRepository.GetAllMenusFromList();

            foreach (Menu tomato in allMenus)
            {
                PrintMenu(tomato);
            }

            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }


        private void EditMenu()
        {
            Console.WriteLine("Please enter the name of the meal you'd like to edit: ");
            string mealName = Console.ReadLine();

            Menu menu = _menuRepository.GetMenuFromListByMealName(mealName);

            if (menu != null)
            {
                PrintMenu(menu);

                Console.WriteLine("New Meal Name: ");
                string newMealName = GetUserInput();

                Console.WriteLine("New Food Description: ");
                string newFoodDescription = GetUserInput();

                Console.WriteLine("New Meal Number: ");
                int newMealNumber= Convert.ToInt32(GetUserInput());

                Console.Write("\nNew Price: $");
                decimal newPrice = Convert.ToDecimal(GetUserInput());

                bool addMoreIngrediants = true;
                List<string> newIngredients = new List<string>();

                while (addMoreIngrediants)
                {
                    Console.WriteLine("New Ingredient: ");
                    string newIngredient = GetUserInput();
                    newIngredients.Add(newIngredient);
                    Console.WriteLine("Add another ingredient? y/n");
                    string ingredientAnswer = Convert.ToString(Console.ReadLine());
                    
                    if (ingredientAnswer == "n")
                    {
                        addMoreIngrediants = false;
                    }
                }

                Menu updatedMenu = new Menu(newMealNumber, newMealName, newFoodDescription, newIngredients, newPrice);

                
                if (updatedMenu.MealName.ToUpper() == menu.MealName.ToUpper())
                {
                    bool isSuccess = _menuRepository.UpdateMenu(updatedMenu);
                    Console.WriteLine($"Successfully updated {updatedMenu.MealName}. Press any key to continue....");
                }
                else
                {
                    bool isSuccess = _menuRepository.UpdateMenu(updatedMenu, menu.MealName);
                    Console.WriteLine($"Successfully updated {updatedMenu.MealName}. Press any key to continue....");
                    Console.ReadKey();
                }

            }
            else
            {
                Console.WriteLine("We couldn't find that menu. Press any key to continue....");
                Console.ReadKey();
            }
        }

        private void DeleteMenu()
        {
            Console.WriteLine("Enter meal name to delete: ");
            string input = GetUserInput();

            bool isSuccess = _menuRepository.DeleteMenuByMealName(input);

            if (isSuccess)
            {
                Console.WriteLine("Menu item deleted. Press any key to continue....");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("We couldn't find that menu item. Press any key to continue....");
                Console.ReadKey();
            }

        }

        public void ExitApplication()
        {
            Console.WriteLine("Press any key to Leave.");
            Console.ReadKey();
        }
    }
}