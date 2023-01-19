using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaCoffee
{
    public abstract class Recipe
    {
        public Dictionary<String, int> recipe { get; set; }
        public string name { get; set; }

        public double cost { get; set; }

        public Inventory inventory { get; set; }

        public Recipe(string name, Inventory inventory)
        {
            this.name = name;
            this.inventory = inventory;

            recipe = new Dictionary<String, int>();
            setRecipe();
            cost = (double)Cost() / 100;
        }

        public abstract void setRecipe();

        public void dispenseCoffee()
        {
            Console.WriteLine("Dispensing: " + name);
        }

        public void outOfStock()
        {
            Console.WriteLine("Out of Stock: " + name);
        }

        public void addIngredient(String ingredient, int qty)
        {
            if (recipe.ContainsKey(ingredient))
            {
                recipe[ingredient] = qty;
            }
            else
            {
                recipe.Add(ingredient, qty);
            }
            
        }

        public bool isInStock()
        {

            foreach (var ingredient in recipe)
            {
                if (!inventory.enoughOf(ingredient.Key, ingredient.Value))
                {
                    return false;
                }
            }
            return true;
        }

        public Drink makeDrink()
        {
            Drink drink;
            if (isInStock())
            {
                drink = new Drink(name);
                foreach (var ingredient in recipe)
                {
                    for (int i = 0; i < ingredient.Value; i++)
                    {
                        drink = inventory.get(ingredient.Key).addTo(drink);
                    }
                }
                dispenseCoffee();
                return drink;
            }
            else
            {
                outOfStock();
                return null;
            }
        }
        public int Cost()
        {
            int cost = 0;
            foreach (var ingredient in recipe)
            {
                for (int i = 0; i < ingredient.Value; i++)
                {
                    cost += inventory.getCost(ingredient.Key);
                }
            }
            return cost;
        }




    }

    class CoffeeRecipe : Recipe
    {


        public CoffeeRecipe(Inventory inventory) : base("Coffee", inventory)
        {
               

        }
    
        public override void setRecipe()
        {
            addIngredient("Coffee", 3);
            addIngredient("Sugar", 1);
            addIngredient("Cream", 1);
        }

    }
    class DecafCoffeeRecipe : Recipe
    {


        public DecafCoffeeRecipe(Inventory inventory) : base("Decaf Coffee", inventory)
        {
            

        }

        public override void setRecipe()
        {
            addIngredient("Decaf Coffee", 3);
            addIngredient("Sugar", 1);
            addIngredient("Cream", 1);
        }

    }

    class CaffeLatteRecipe : Recipe
    {


        public CaffeLatteRecipe(Inventory inventory) : base("Caffe Latte", inventory)
        {


        }

        public override void setRecipe()
        {
            addIngredient("Espresso", 2);
            addIngredient("Steamed Milk", 1);
        }

    }

    class CaffeMochaRecipe : Recipe
    {


        public CaffeMochaRecipe(Inventory inventory) : base("Caffe Mocha", inventory)
        {


        }

        public override void setRecipe()
        {
            addIngredient("Espresso", 1);
            addIngredient("Cocoa", 1);
            addIngredient("Steamed Milk", 1);
            addIngredient("Whipped Cream", 1);
        }

    }

    class CaffeAmericanoRecipe : Recipe
    {


        public CaffeAmericanoRecipe(Inventory inventory) : base("Caffe Americano", inventory)
        {


        }

        public override void setRecipe()
        {
            addIngredient("Espresso", 3);
        }

    }

    class CappuccinoRecipe : Recipe
    {


        public CappuccinoRecipe(Inventory inventory) : base("Cappuccino", inventory)
        {


        }

        public override void setRecipe()
        {
            addIngredient("Espresso", 2);
            addIngredient("Steamed Milk", 1);
            addIngredient("Foamed Milk", 1);
        }

    }


}
