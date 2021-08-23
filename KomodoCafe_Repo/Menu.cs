using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GoldBadgeChallenge
{
  public class  Menu
    {
         public string Name { get; set; } 
         public string Descripition { get; set; } 
         public string Price { get; set; }
        public List<string> Ingredients { get; set; }

        public Menu () {  }
        public Menu(string nameOfMeal, string description, List<string> ingredients, string price)
        {
            Name = nameOfMeal;
            Descripition = description;
            Ingredients = ingredients;
            Price = price; 
            
        }

    }
 


}







