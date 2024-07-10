using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzCoffee.Machines
{
    public abstract class Machine
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public Machine(string name, string address) 
        {
            Name = name;
            Address = address;
        }

        public abstract void GetDrink();
    }
}
