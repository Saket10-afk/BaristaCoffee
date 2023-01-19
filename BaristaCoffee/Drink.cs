using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaCoffee
{
    public class Drink
    {
        public String name { get; set; }
        

        public Drink(String name)
        {
            this.name = name;
        }

        public virtual int cost()
        {
            return 0;
        }
    }
}
