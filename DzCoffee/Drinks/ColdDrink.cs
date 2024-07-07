using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzCoffee.Drinks
{
    public class ColdDrink : Drink
    {
        public int Count { get; set; }

        public ColdDrink(string name, double price, int count)
            : base(name, price)
        {
            Count = count;
        }

        public void AddDrinkCount(int count)
        {
            Count += count;
        }
    }
}
