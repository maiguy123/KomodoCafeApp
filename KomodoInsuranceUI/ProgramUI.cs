using KomodoInsurance_Re;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceUI
{
    class ProgramUI
    {
        private ClaimsRepo _claims = new ClaimsRepo();
        // Methos that run/starts the application

        public void Run()
        {
            Seed();
            Menu();
        }

        //Menu 
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display our Options to the user 
                Console.WriteLine("Select a menu option\n"+
                   "1. See all claims\n" +
                   "2.Take Care of next Claim\n" +
                   "3.Enter a new claim\n"+
                   "4. Exit");


                // Get the user's input 
                string input = Console.ReadLine();

                //Evsluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //See all Claims
                        DisplayallClaims();
                        break;
                    case "2":
                        //deleting claims
                        DequeueExistingClaim();
                        break;
                    case "3":
                        // enter new claim
                        break;
                    case "4":
                        //Exit
                        break;
                    default:
                        Console.WriteLine("Please enter Valid option.");
                        break;
                }
                Console.WriteLine("Please Press any key to continue ...");
                Console.ReadKey();
                Console.Clear();



            }
        }
        // View all claim
        private void DisplayallClaims()
        {
            Queue<Claims> claims = _claims.GetClaimsByQueue();
            Console.WriteLine($"{"ID"} {"Type"} {"Description"} {"Amount"} {"DateOfAccident"} {"DateofClaim"}");
        }
         
        private void NextMessage()
        {
            Console.WriteLine("Press key to continue");
            Console.ReadKey();
        } 
        public int AgeOfClaim(DateTime dateofclaim, DateTime dateOdIncident)
        {
            var days = dateofclaim - dateOdIncident;
            return Convert.ToInt32(days);
        }

        //Dequeue Existing Claims menu 
        private void DequeueExistingClaim()
        {
           DisplayallClaims();

             //Get Claims you want to remove
            Console.WriteLine("Enter the item you want to remove");

          string input = Console.ReadLine();

        // call the delete method
            bool wasDeleted = _claims.DequeueFromList(input);

            //if the claim was deleted, say so
            if (wasDeleted)
            {
               Console.WriteLine("The claim was deleted.");
            }
           // otherwise state it could not be deleted
           else
           {
                Console.WriteLine("The claim could not be deleted");
           }
        }
        private void CreateNewClaim()
        {
            Claims newContent = new Claims();
            Console.WriteLine("What is the ID");
            newContent.ID = Console.ReadLine();
            Console.WriteLine("What is the type of claim");
            newContent.Type = Console.ReadLine();
            Console.WriteLine("The description of claim");
            newContent.Description = Console.ReadLine();
            Console.WriteLine("What is the date of incident");
            newContent.DateOfIncident = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("What is the date of claim");
            newContent.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            
        }
        private void Seed()
        {
            Claims one = new Claims("1", "Car", "Car accident on 465", 400m, new DateTime(4 / 25 / 18), new DateTime(4 / 27 / 18),);
            _claims.AddClaimsToQueue(one);
        }
    }
}
