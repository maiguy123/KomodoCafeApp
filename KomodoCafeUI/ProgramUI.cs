using GoldBadgeChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeUI
{
    class ProgramUI
    {
        private MenuRepo _Repo = new MenuRepo();
        // Method that run/starts the application
        public void Run()
        {
           
            Menu();
        }

        // Menu 
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display our options to the user
                Console.WriteLine("Select a menu option: \n" +
                   "1. Create New Menu list\n" +
                   "2.View All Menu Items Description\n" +
                   "3. Update Existing Menu Items\n" +
                   "4. Delete Existing Content Items\n" +
                   "5. Exit");
                  

                // Get the user's input
                string input = Console.ReadLine();

                //Evaluate the suer's input and act accordingly 
                switch (input)
                {
                    case "1":
                        // Creat new Menu item
                        CreateNewMenuItem();
                        break;
                    case "2":
                        // View All Menu item
                        DisplayAllMenuItems();
                        break;
                   
                    case "3":
                        // Update Exisiting Menu item 
                        UpdateExistingMenuItem();
                        break;
                    case "4":
                        // Delete Exisiting Menu Item
                        DeleteExistingMenuItem();
                        break;
                    case "5":
                        // Exit 
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        break;

                }
                Console.WriteLine("Please Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        // Create new Menu Item
        private void CreateNewMenuItem()
        {
            Menu newContent = new Menu();
            Console.WriteLine("Name Item");
            newContent.Name = Console.ReadLine();
            Console.WriteLine("Description of Item");
            newContent.Descripition = Console.ReadLine();
            Console.WriteLine("Prices of Item");
            newContent.Price = Convert.ToDecimal(Console.ReadLine());

            List<string> ingredients = new List<string>();
            newContent.Ingredients = ingredients;

            Console.WriteLine("What is the first ingredient?");
            string ingredientOne = Console.ReadLine();
            ingredients.Add(ingredientOne);


            Console.WriteLine("Anymore ingreidensts yes or no");
            string userInput = Console.ReadLine().ToLower().Trim();
            
            while (userInput == "yes")
            {
                Console.WriteLine("What's the next ingredient?");
                string nextIngredient = Console.ReadLine();
                ingredients.Add(nextIngredient);
                Console.WriteLine("Would you like to add more yes or no");
                userInput = Console.ReadLine();
            }

            _Repo.AddContentToList(newContent);
            Console.WriteLine("This is your new Menu Item \n" +
                "Press any key to continue.");
            Console.ReadLine();
        }

        // View Current Menu Item
        private void DisplayAllMenuItems()
        {
          List<Menu> items = _Repo.GetMenuByList();

            Console.WriteLine($"{"Food Name"} {"Food Price"} {"Food Description"} {"Food Ingredients"} ");

            foreach(Menu item in items)
            {
                var ingredients = String.Join(",", item.Ingredients );
                Console.WriteLine($"{item.Name} { item.Price} {item.Descripition} {ingredients}");
            }
            Console.ReadKey();
        }

        // Update Exisiting Menu Item
        private void UpdateExistingMenuItem()
        {
            Console.Clear();
            // Display all content
            DisplayAllMenuItems();
            // Ask for the title of the content to update
            Console.WriteLine("Enter title of the menu item you'd like to update:");

            // Get Title 
            string oldMenuItem = Console.ReadLine();


            if (_Repo.GetMenu(oldMenuItem) != null)
            {
                // We will build a new object
                Menu newContent = new Menu();
                Console.WriteLine("Name Item");
                newContent.Name = Console.ReadLine();
                Console.WriteLine("Description of Item");
                newContent.Descripition = Console.ReadLine();
                Console.WriteLine("Prices of Item");
                newContent.Price = Convert.ToDecimal(Console.ReadLine());

                List<string> ingredients = new List<string>();
                newContent.Ingredients = ingredients;

                Console.WriteLine("What is the first ingredient?");
                string ingredientOne = Console.ReadLine();
                ingredients.Add(ingredientOne);
                Console.WriteLine("Would you like to add another ingredient yes or no");
                string userInput = Console.ReadLine();
                while (userInput == "yes")
                {
                    Console.WriteLine("What's the next ingredient?");
                    string nextIngredient = Console.ReadLine();
                    ingredients.Add(nextIngredient);

                    Console.WriteLine("Would you like to add more yes or no");
                    userInput = Console.ReadLine();

                }

                _Repo.UpdateExisitingMenu(oldMenuItem, newContent);
            }
            else
            {
                Console.WriteLine("This item doesn't exist. try again yes or no.");
                string userInput  = Console.ReadLine();
                if(userInput == "yes")
                {
                    UpdateExistingMenuItem();
                }
            }

        }

        // Delete Exisiting Menu Item
        private void DeleteExistingMenuItem()
        {

            DisplayAllMenuItems();

            // Get  menu item you want to remove
            Console.WriteLine("Enter the item you would like to remove");
            
            string input = Console.ReadLine();


            // call the delete method
            bool wasDeleted = _Repo.RemoveMenuFromList(input);

            // if the menu item was deleted, say so 
            if (wasDeleted)
            {
                Console.WriteLine("The Item was deleted.");
            }
            // otherwise state it could not be deleted
            else
            {
                Console.WriteLine("The item could not be deleted");
            }

        }

        private void Seed()
        {
            Menu one = new Menu("Big Boy Burger", "Super Tasty", new List<string> { "Bun", "Two beef patties", "Pickles", "Mayo" }, 12.99m);
            _Repo.AddContentToList(one);
        }

    }
}
 