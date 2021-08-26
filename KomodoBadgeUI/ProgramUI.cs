using KomodoBadge_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadgeUI
{
    class ProgramUI
    {
        private BadgeRepo _badges = new BadgeRepo();
        // Method that run/starts the application

        public void Run()
        {
            Seed();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // DIsplay our Options to user 
                Console.WriteLine("Select a menu options\n" +
                    "1.Add a badge\n" +
                    "2.Edit a Badge\n" +
                    "3.List all badges" +
                    "4. Exit");
                // Get User's Input 
                string input = Console.ReadLine();

                // Evaluate the user's input and act accorddingly
                switch (input)
                {
                    case "1":
                        // add a badge
                        CreateNewBadges();
                        break;
                    case "2":
                        // edit a badge

                        break;
                    case "3":
                        // list all badge
                        DisplayAllBadgeItems();
                        break;
                    case "4":
                        // exit 
                        break;
                    default:
                        Console.WriteLine("Please enter Valid option");
                        break;
                }
                Console.WriteLine("Please Press any key to continue ....");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void DisplayAllBadgeItems()
        {
            List<Badges> badges = _badges.GetBadgesByList();
            Console.WriteLine($"{"Badge Number"} {"Doors"}");

            foreach(Badges item in badges)
            {
                var doors = String.Join(",", item.Doors);
                Console.WriteLine($"{item.BadgeID } {item.BadgeID}");
            }
            Console.ReadKey();
        }
        private void UpdateExisitingDoors()
        {
            Console.Clear();
            //display all content 
            DisplayAllBadgeItems();
            // ask to update badge
            Console.WriteLine("Enter Badge you would like to update");

            //get title
            string oldcontent = Console.ReadLine();

           // if (_badges.GetBadgesByList(oldcontent) !=null)
           // {
             //   Badges newContent = new Badges();
            //}

        }

        private void CreateNewBadges()
        {
            Badges newContent = new Badges();
            Console.WriteLine("what is the Badge ID");
            newContent.BadgeID = Console.ReadLine();
            

        }
        private void Seed()
        {
            Badges one = new Badges("Badge 1", new List<string> { "Door 1", "Door 2", "Door 3", "Door 4" });
            Badges two = new Badges("Badge 2", new List<string> { "Door 5", "Door 6", "Door 7", "Door 8" });
            Badges three = new Badges("Badge 3", new List<string> { "Door 9", "Door 10", "Door 11", "Door 12" });

            _badges.CreateNewBadges(one);
            _badges.CreateNewBadges(two);
            _badges.CreateNewBadges(three);

        }

    }
}


