using DzCoffee.DataManager;
using DzCoffee.Machines;
using System.Net;
using System.Reflection.PortableExecutable;

namespace DzCoffee
{
    public class DrinksMachinesManager
    {
        public List<AbstractMachine> Machines { get; set; }

        public ErrorsStorage ErrorsWriter { get; set; }

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
            Dictionary<string, AbstractMachine> brokenMachines = ReturnBrokenMachines();

            string solution = ChooseSolution();

            Repairs(solution, brokenMachines);
        }

        public Dictionary<string, AbstractMachine> ReturnBrokenMachines()
        {
            Dictionary<string, AbstractMachine> brokenMachines = new Dictionary<string, AbstractMachine>();

            foreach (var machine in Machines)
            {
                if (machine.isBroken)
                {
                    Console.WriteLine($"system {machine.Name} на {machine.Address} сломана((");

                    brokenMachines.Add(machine.Name, machine);
                }
            }

            Console.WriteLine("system Напиши БЕДА чтобы вызвать ремонтника на все адреса или ОДНО НАЗВАНИЕ чтобы вызвать ремонтника туда");
            Console.WriteLine("system Напиши что хочешь если тебе все равно");

            return brokenMachines;
        }

        public string ChooseSolution()
        {
            string solution = Console.ReadLine();

            return solution;
        }

        public void Repairs(string solution, Dictionary<string, AbstractMachine> machines)
        {
            if (solution == "БЕДА")
            {
                foreach (string address in machines.Keys)
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

        public bool RemoveMachine(string machineName)
        {
            foreach (var machine in Machines)
            {
                if (machine.Name == machineName)
                {
                    Machines.Remove(machine);

                    return true;
                }
            }
            return false;
        }

        public bool RemoveMachine(AbstractMachine machineToRemove)
        {
            if (Machines.Contains(machineToRemove))
            {
                Machines.Remove(machineToRemove);

                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object? obj)
        {

            return obj is DrinksMachinesManager manager &&
                   Machines.SequenceEqual(manager.Machines) &&
                   EqualityComparer<ErrorsStorage>.Default.Equals(ErrorsWriter, manager.ErrorsWriter);
        }
    }
}
