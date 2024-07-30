using DzCoffee.Drinks;
using DzCoffee.Machines;
using System.Collections;

namespace DzCoffee.Test
{
    public class DrinksMachinesManagerTest
    {
        [TestCaseSource(typeof(RemoveMachineByNameTestSource))]
        public void RemoveMachineByNameTest(string machineName, DrinksMachinesManager drnksMchnMngr, DrinksMachinesManager expected)
        {
            drnksMchnMngr.RemoveMachine(machineName);

            DrinksMachinesManager actual = drnksMchnMngr;

            Assert.AreEqual(expected, actual);
        }

        pub
    }
    public class RemoveMachineByNameTestSource() : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var drnksMchnMngr = new DrinksMachinesManager()
            {
                Machines = new List<AbstractMachine>()
                {
                    new ColdDrinksMachine
                    ( "Артурка", "Дыбенко", 
                    new Dictionary<string, AbstractDrink>()
                    {
                        {"pepsi" , new ColdDrink("pepsi", 200, 1)}
                    }
                    ),

                    new CoffeeMachine
                    ( "Максем", "Пионерская", 100, 100, 100, 100,
                    new Dictionary<string, HotDrink>()
                    { {"k", new HotDrink("2", 2,2,2,2,2) }
                    }
                    ),

                    new JuiceMachine
                    ( "ЕГОРКА", "Спасская" )
                },
            };

            var expected = new DrinksMachinesManager()
            {
                Machines = new List<AbstractMachine>()
                {
                    new CoffeeMachine
                    ( "Максем", "Пионерская", 100, 100, 100, 100,
                    new Dictionary<string, HotDrink>()
                    { {"k", new HotDrink("2", 2,2,2,2,2) }
                    }
                    ),

                    new JuiceMachine
                    ( "ЕГОРКА", "Спасская" )
                },
            };

            string machineName = "Артурка";

            yield return new object[] {machineName, drnksMchnMngr, expected};

            drnksMchnMngr = new DrinksMachinesManager()
            {
                Machines = new List<AbstractMachine>()
                {
                    new ColdDrinksMachine
                    ( "Артурка", "Дыбенко",
                    new Dictionary<string, AbstractDrink>()
                    {
                        {"pepsi" , new ColdDrink("pepsi", 200, 1)}
                    }
                    ),

                    new CoffeeMachine
                    ( "Максем", "Пионерская", 100, 100, 100, 100,
                    new Dictionary<string, HotDrink>()
                    { {"k", new HotDrink("2", 2,2,2,2,2) }
                    }
                    ),

                    new JuiceMachine
                    ( "ЕГОРКА", "Спасская" )
                },
            };

            expected = new DrinksMachinesManager()
            {
                Machines = new List<AbstractMachine>()
                {
                    new ColdDrinksMachine
                    ( "Артурка", "Дыбенко",
                    new Dictionary<string, AbstractDrink>()
                    {
                        {"pepsi" , new ColdDrink("pepsi", 200, 1)}
                    }
                    ),

                    new CoffeeMachine
                    ( "Максем", "Пионерская", 100, 100, 100, 100,
                    new Dictionary<string, HotDrink>()
                    { {"k", new HotDrink("2", 2,2,2,2,2) }
                    }
                    ),

                    new JuiceMachine
                    ( "ЕГОРКА", "Спасская" )
                },
            };

            machineName = "fvfvv";

            yield return new object[] { machineName, drnksMchnMngr, expected };
        }
    }
}
