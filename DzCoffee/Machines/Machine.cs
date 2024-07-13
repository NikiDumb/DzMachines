
namespace DzCoffee.Machines
{
    public abstract class Machine
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public bool isBroken { get; set; }

        public Machine(string name, string address) 
        {
            Name = name;
            Address = address;
            isBroken = false;
        }

        public abstract void GetDrink();

        public abstract void ReloadMachineStocks();
    }
}
