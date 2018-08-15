using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeFinder.Services
{
    public class Ingredients
    {
        //-----Used as a bind to display the ingredients entered-----//
        public string IngredientsEntered { get; set; }

        public Ingredients(string IngredientsIn)
        {
            IngredientsEntered = IngredientsIn;
        }
    }
}
