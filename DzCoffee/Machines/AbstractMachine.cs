
namespace DzCoffee.Machines
{
    public abstract class AbstractMachine
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public bool isBroken { get; set; }

        public AbstractMachine(string name, string address) 
        {
            Name = name;
            Address = address;
            isBroken = false;
        }

        public abstract void GetDrink();

        public abstract void ReloadMachineStocks();
    }
}
