using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaCoffee
{
    public class Inventory
    {
        public Dictionary<String, int> quantities { get; set; }

        public Dictionary<String, Ingredient> ingredients { get; set; }
        

        public Inventory()
        {
            ingredients = new Dictionary<String, Ingredient>();
            quantities = new Dictionary<String, int>();
            loadIngredient(new Cocoa());
            loadIngredient(new Coffee());
            loadIngredient(new Cream());
            loadIngredient(new DecafCoffee());
            loadIngredient(new Espresso());
            loadIngredient(new FoamedMilk());
            loadIngredient(new SteamedMilk());
            loadIngredient(new Sugar());
            loadIngredient(new WhippedCream());
         
        }

        public void display()
        {
            Console.WriteLine("Inventory:");
       
            foreach(var q in quantities) { 
                Console.WriteLine(q.Key + "," + q.Value); 
            }
        }

        public void restock()
        {
            foreach (var ingredient in quantities)
            {
                quantities[ingredient.Key] = 10;
            }         
        }

        // We can add more ingredients once the inventory has been created
        public void loadIngredient(Ingredient ingredient)
        {
            if (ingredients.ContainsKey(ingredient.getName()))
            {
                throw new Exception();
            }
            else
            {
                ingredients.Add(ingredient.getName(), ingredient);
                quantities.Add(ingredient.getName(), 10);
            }
        }

        public bool enoughOf(String ingredient, int qty)
        {
            if (ingredients.ContainsKey(ingredient))
            {
                if (quantities[ingredient] >= qty)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Ingredient Not in Inventory");
                return false;
            }
        }

        // Returns the specified ingredient and decreases its quantity in the inventory
        public Ingredient get(String ingredient)
        {
            if (enoughOf(ingredient, 1))
            {
                if (quantities.ContainsKey(ingredient))
                {
                    quantities[ingredient] = quantities[ingredient] - 1;
                }
                else
                {
                    quantities.Add(ingredient, quantities[ingredient] - 1);
                }
                Console.WriteLine(ingredients[ingredient].clone().name);
                return ingredients[ingredient].clone();
            }
            else
            {
                return ingredients[ingredient].clone();
            }
        }

        // Returns the cost of an ingredient in cents ($1.00 = 100)
        public int getCost(String ingredient)
        {
            if (ingredients.ContainsKey(ingredient))
            {
                return ingredients[ingredient].cost();
            }
            else
            {
                return ingredients[ingredient].cost();
            }
        }
    }
}
