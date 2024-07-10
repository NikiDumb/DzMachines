
using DzCoffee.DataManager;
using DzCoffee.Machines;

namespace DzCoffee.MachineManager
{
    public class ColdDrinksMachinesManager
    {
        public List<ColdDrinksMachine> Machines { get; set; }

        public ErrorsDataManager ErrorsWriter { get; set; }

        public void RunMachines()
        {
            try
            {
                foreach (var machine in Machines)
                {
                    machine.GetColdDrink();
                }
            }
            catch (Exception e)
            {
                ErrorsWriter.WriteToFile(e.Message);
            }
        }

        public void PrintErrors()
        {
            ErrorsWriter.PrintErrors();
        }

        public void PrintInfo()
        {
            Console.WriteLine("Ваши автоматы");

            foreach (var machine in Machines)
            {
                Console.WriteLine($"{machine.Name} на {machine.Address}");
            }
            ErrorsWriter.GetErrorsJSON();
            PrintErrors();
        }
    }
}
