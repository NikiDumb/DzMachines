using DzCoffee.DataManager;
using DzCoffee.Machines;
using System.Net;
using System.Reflection.PortableExecutable;

namespace DzCoffee.MachineManager
{
    public class DrinksMachinesManager
    {
        public List<Machines.Machine> Machines { get; set; }

        public ErrorsDataManager ErrorsWriter { get; set; }

        public void RunMachines()
        {
            foreach (var machine in Machines)
            {
                try
                {
                    machine.GetDrink();
                }
                catch (Exception e)
                {
                    if (e.Message != "")
                    {
                        ErrorsWriter.WriteToFile(e.Message);

                        SolveError();
                    }
                }
            }
        }

        public void SolveError()
        {
            Dictionary<string, Machines.Machine> brokenMachines = PrintBrokenMachines();
            string solution = ChooseSolution();
            Repairs(solution, brokenMachines);
        }

        public Dictionary<string, Machines.Machine> PrintBrokenMachines()
        {
            Dictionary<string, Machines.Machine> brokenMachines = new Dictionary<string, Machines.Machine>();

            foreach(var machine in Machines)
            {
                if (machine.isBroken)
                {
                    Console.WriteLine($"{machine.Name} на {machine.Address} сломана((");

                    brokenMachines.Add(machine.Name, machine);
                }
            }

            Console.WriteLine("Напиши БЕДА чтобы вызвать ремонтника на все адреса или ОДНО НАЗВАНИЕ чтобы вызвать ремонтника туда");
            Console.WriteLine("Напиши что хочешь если тебе все равно");

            return brokenMachines;
        }

        public string ChooseSolution()
        {
            string solution = Console.ReadLine();

            return solution;
        }

        public void Repairs(string solution, Dictionary<string, Machines.Machine> machines)
        {
            if (solution == "БЕДА")
            {
                foreach(string address in machines.Keys)
                {
                    machines[address].ReloadMachineStocks();

                    machines[address].isBroken = false;

                    ErrorsWriter.WriteToFile($"{machines[address].Name} на {machines[address].Address}. Проблема устранена!");
                }
            }
            else if (machines.Keys.Contains(solution))
            {
                machines[solution].ReloadMachineStocks();

                machines[solution].isBroken = false;

                ErrorsWriter.WriteToFile($"{machines[solution].Name} на {machines[solution].Address}. Проблема устранена!");
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
