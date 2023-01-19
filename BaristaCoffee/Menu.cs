using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BaristaCoffee.Recipe;

namespace BaristaCoffee
{
    public class Menu
    {

        public Dictionary<String, Recipe> recipes { get; set; }
       

        public Menu(Inventory inventory)
        {
            recipes = new Dictionary<String, Recipe>();
            addRecipe(new CaffeAmericanoRecipe(inventory));
            addRecipe(new CaffeLatteRecipe(inventory));
            addRecipe(new CaffeMochaRecipe(inventory));
            addRecipe(new CappuccinoRecipe(inventory));
            addRecipe(new CoffeeRecipe(inventory));
            addRecipe(new DecafCoffeeRecipe(inventory));

        }

        // Add a new recipe to the menu
        public void addRecipe(Recipe recipe)
        {
            if (recipes.ContainsKey(recipe.name))
            {
                throw new Exception();
            }
            else
            {
                recipes.Add(recipe.name, recipe);
            }
        }

        public void display()
        {
            Console.WriteLine("Menu:");
            int i = 0;
            foreach (var recipe in recipes)
            {
                String price = recipe.Value.cost.ToString();
                Console.WriteLine((i + 1) + "," + recipe.Key + "," + "$" + price + "," + recipe.Value.isInStock());
                i++;
            }
        }

        public Drink makeDrink(int index)
        {
            if (index < recipes.Count)
            {
                Console.WriteLine(recipes.ElementAt(index).Key);
                return recipes.ElementAt(index).Value.makeDrink();
            }
            else
            {
                throw new Exception();
            }

        }

    }
}
