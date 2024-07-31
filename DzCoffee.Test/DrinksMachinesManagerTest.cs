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

        [TestCaseSource(typeof(RemoveMachineByObjTestSource))]
        public void RemoveMachineByObjTest(AbstractMachine machine, DrinksMachinesManager drnksMchnMngr, DrinksMachinesManager expected)
        {
            drnksMchnMngr.RemoveMachine(machine);

            DrinksMachinesManager actual = drnksMchnMngr;

            Assert.AreEqual(expected, actual);
        }

        //[TestCaseSource(typeof(SolveErrorTestSource))]
        //public void SolveErrorTest(DrinksMachinesManager drnksMchnMngr, AbstractMachine expected)
        //{
        //    drnksMchnMngr.SolveError();

        //    AbstractMachine actual = drnksMchnMngr.Machines[0];

        //    Assert.AreEqual(expected, actual);
        //}
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

            yield return new object[] { machineName, drnksMchnMngr, expected };

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

    public class RemoveMachineByObjTestSource() : IEnumerable
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

            var machine = new ColdDrinksMachine("Артурка", "Дыбенко",
                    new Dictionary<string, AbstractDrink>()
                    {
                        {"pepsi" , new ColdDrink("pepsi", 200, 1)}
                    }
                    );

            yield return new object[] { machine, drnksMchnMngr, expected };

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

            machine = new ColdDrinksMachine("Артурка", "Дыбенко",
                    new Dictionary<string, AbstractDrink>()
                    {
                        {"bb" , new ColdDrink("bb", 200, 1)}
                    }
                    );

            yield return new object[] { machine, drnksMchnMngr, expected };
        }
    }

    //public class SolveErrorTestSource() : IEnumerable
    //{
    //    public IEnumerator GetEnumerator()
    //    {
    //        var drnksMchnMngr = new DrinksMachinesManager()
    //        {
    //            Machines = new List<AbstractMachine>()
    //            {
    //                new ColdDrinksMachine
    //                ( "Артурка", "Дыбенко",
    //                new Dictionary<string, AbstractDrink>()
    //                {
    //                    {"pepsi" , new ColdDrink("pepsi", 200, 0)}
    //                }
    //                )
    //            },

    //            ErrorsWriter = new DataManager.ErrorsStorage("Data/coldDrinks")
    //        };

    //        var expected = new ColdDrinksMachine
    //                ("Артурка", "Дыбенко",
    //                new Dictionary<string, AbstractDrink>()
    //                {
    //                    {"pepsi" , new ColdDrink("pepsi", 200, 0)}
    //                }
    //                );

    //        expected.ReloadMachineStocks();

    //        yield return new object[] { drnksMchnMngr, expected };
    //    }
    //}


}
