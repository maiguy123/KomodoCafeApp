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
                Console.WriteLine("Select a menu option\n" +
                   "1. See all claims\n" +
                   "2.Take Care of next Claim\n" +
                   "3.Enter a new claim\n" +
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
                        // Take Care of next claims
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        // enter new claim
                        CreateNewClaim();
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
            Console.WriteLine($"{"ID"} | {"Type"} |  {"Description"} |  {"Amount"} |  {"DateOfAccident"}  | {"DateofClaim"} | {"Isvalid"}\n\n");
            //Console.WriteLine($"{"1"} |  {"Car"} |  {"Car accident on 465"} | {"400"} |  {"(4/25/18)"} |  {"(4/27/18)"} |  {"True"}\n");
            //Console.WriteLine($"{"2"} | {"Home"} |  {"House for in kitchen"} |  {"4000"} |  {"(4/11/18)"} |  {"(4/12/18)"} |  {"True"}\n");
            //Console.WriteLine($"{"3"} |  {"Theft"} |  {"Stolen goods"} |  {"4"} |  {"(4/27/18)"} |  {"(6/01/18)"} |  {"False"}\n");
            foreach(Claims claims1 in claims)
            {
                Console.WriteLine($"{claims1.ID}  {claims1.Type}  {claims1.Description}  " +
                    $"{claims1.Amount}  {claims1.DateOfIncident}  {claims1.DateOfClaim}  {claims1.IsValid}");
            }
            Console.ReadKey();


        }

       

        ////Dequeue Existing Claims menu 
        //private void DequeueExistingClaim()
        //{
        //   DisplayallClaims();

        //     //Get Claims you want to remove
        //    Console.WriteLine("Enter the item you want to remove");

        //  string input = Console.ReadLine();

        //// call the delete method
        //    bool wasDeleted = _claims.DequeueFromList(input);

        //    //if the claim was deleted, say so
        //    if (wasDeleted)
        //    {
        //       Console.WriteLine("The claim was deleted.");
        //    }
        //   // otherwise state it could not be deleted
        //   else
        //   {
        //        Console.WriteLine("The claim could not be deleted");
        //   }
        //}
        public void TakeCareOfNextClaim()
        {
            Console.Clear();
            bool lookingAtQueue = true;
            while (lookingAtQueue)
            {
                Console.WriteLine("infromation about the claim");
                //Claims claims = _claims.DequeueFromList();
                Queue<Claims> queueOfClaims = _claims.GetClaimsByQueue();
                Claims claims = queueOfClaims.Peek();
                Console.WriteLine($"ClaimID: {claims.ID}\n\nType:{claims.Type}\n\nDescription{claims.Description}\n\n" +
                    $"Amount:{claims.Amount}\n\nDateOfIncident:{claims.DateOfIncident}\n\nDateofClaim:{claims.DateOfClaim}\n\n" +
                    $"Isvalid:{claims.IsValid}\n\n");
                Console.WriteLine(" Would you like to handle with this claim right now, yes or no");

                string input = Console.ReadLine().ToLower().Trim();
                if (input == "yes")
                {
                    _claims.DequeueFromList();
                    Console.Clear();

                }
                else if (input == "no")
                {
                    lookingAtQueue = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please press the correct response");
                }
            }
            Console.Clear();
            Console.WriteLine("Press any key to return to menu");
            Console.Clear();
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
            Console.WriteLine("What the amount");
            newContent.Amount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("What is the date of incident");
            newContent.DateOfIncident = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("What is the date of claim");
            newContent.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

        }
        private void Seed()
        {
            Claims one = new Claims("1", "Car", "Car accident on 465", 400m, new DateTime(4 / 25 / 18), new DateTime(4 / 27 / 18));
            Claims two = new Claims("2", "Home", "House fire in kitchen", 4000m, new DateTime(4 / 11 / 18), new DateTime(4 / 12 / 18));
            Claims three = new Claims("3", "Theft", "Stolen goods", 4m, new DateTime(4 / 27 / 18), new DateTime(6 / 01 / 18));

            _claims.AddClaimsToQueue(one);
            _claims.AddClaimsToQueue(two);
            _claims.AddClaimsToQueue(three);
        }
    }
}
