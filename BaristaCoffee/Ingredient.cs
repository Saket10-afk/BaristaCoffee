using BaristaCoffee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaCoffee
{
    public abstract class Ingredient : Drink
    {
        public Drink drink { get; set; }

        public int price { get; set; }
        

        public Ingredient(String name, int price) : base(name) 
        {
           
            this.price = price;
        }
    
        public String getName()
        {
            return name;
        }

     
        public Drink addTo(Drink drink)
        {
            this.drink = drink;
            return this;
        }

     
        
        public override int cost()
        {
            if (drink != null)
            {
                return price + drink.cost();
            }
            else
            {
                return price;
            }
        }

        public abstract Ingredient clone();
    }

    class Coffee : Ingredient
    {

        public Coffee(): base("Coffee", 75) {  }

    
        public override Ingredient clone()
        {
            return new Coffee();
        }

    }

    class DecafCoffee : Ingredient
    {


        public DecafCoffee() : base("Decaf Coffee", 75) { }

        public override Ingredient clone()
        {
            return new DecafCoffee();
        }

    }

    class Sugar : Ingredient
    {


        public Sugar() : base("Sugar", 25) { }

        public override Ingredient clone()
        {
            return new Sugar();
        }

    }

    class Cream : Ingredient
    {


        public Cream() : base("Cream", 25) { }

        public override Ingredient clone()
        {
            return new Cream();
        }

    }

    class SteamedMilk : Ingredient
    {


        public SteamedMilk() : base("Steamed Milk", 35) { }



        public override Ingredient clone()
        {
            return new SteamedMilk();
        }

    }

    class FoamedMilk : Ingredient
    {


        public FoamedMilk() : base("Foamed Milk", 35) { }

        public override Ingredient clone()
        {
            return new FoamedMilk();
        }

    }

    class Espresso : Ingredient
    {


        public Espresso() : base("Espresso", 110) { }

        public override Ingredient clone()
        {
            return new Espresso();
        }

    }

    class Cocoa : Ingredient
    {


        public Cocoa() : base("Cocoa", 90) { }



        public override Ingredient clone()
        {
            return new Cocoa();
        }

    }

    class WhippedCream : Ingredient
    {
        public WhippedCream() : base("Whipped Cream", 100) { }

        public override Ingredient clone()
        {
            return new WhippedCream();
        }

    }
    }
