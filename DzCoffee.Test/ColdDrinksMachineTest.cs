using DzCoffee.Drinks;
using DzCoffee.Machines;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzCoffee.Test
{
    public class ColdDrinksMachineTest
    {
        [TestCaseSource(typeof(ReloadMachineStocksTestSource))]
        public void ReloadMachineStocksTest(ColdDrinksMachine machine, ColdDrinksMachine expected)
        {
            machine.ReloadMachineStocks();

            var actual = machine;

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(CreateColdDrinksDictTestSource))]
        public void CreateColdDrinksDictTest(Dictionary<string, AbstractDrink> drinks, ColdDrinksMachine machine, Dictionary<string, ColdDrink> expected)
        {
            var actual = machine.CreateColdDrinksDict(drinks);

            Assert.IsTrue(expected.Count == actual.Count && !expected.Except(actual).Any());
        }
    }

    public class ReloadMachineStocksTestSource() : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var machine = new ColdDrinksMachine("1", "1",
                new Dictionary<string, Drinks.ColdDrink>()
                {
                    {"1", new Drinks.ColdDrink("1", 1, 1)},
                    {"2", new Drinks.ColdDrink("2", 2, 1)}
                }
                );

            var expected = new ColdDrinksMachine("1", "1",
                new Dictionary<string, Drinks.ColdDrink>()
                {
                    {"1", new Drinks.ColdDrink("1", 1, 1)},
                    {"2", new Drinks.ColdDrink("2", 2, 1)}
                }
                );

            yield return new object[] { machine, expected };

            machine = new ColdDrinksMachine("1", "1",
                new Dictionary<string, Drinks.ColdDrink>()
                {
                    {"1", new Drinks.ColdDrink("1", 1, 0)},
                    {"2", new Drinks.ColdDrink("2", 2, 1)}
                }
                );

            expected = new ColdDrinksMachine("1", "1",
                new Dictionary<string, Drinks.ColdDrink>()
                {
                    {"1", new Drinks.ColdDrink("1", 1, 6)},
                    {"2", new Drinks.ColdDrink("2", 2, 1)}
                }
                );

            yield return new object[] { machine, expected };

            machine = new ColdDrinksMachine("1", "1",
                new Dictionary<string, Drinks.ColdDrink>()
                );

            expected = new ColdDrinksMachine("1", "1",
                new Dictionary<string, Drinks.ColdDrink>()
                );

            yield return new object[] { machine, expected };
        }
    }

    public class CreateColdDrinksDictTestSource() : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var machine = new ColdDrinksMachine("1", "1", new Dictionary<string, AbstractDrink>());

            var drinks = new Dictionary<string, AbstractDrink>()
            {
                {"1", new Drinks.AbstractDrink("1", 1) },
                {"2", new Drinks.AbstractDrink("2", 2) }
            };

            var expected = new Dictionary<string, ColdDrink>()
            {
                {"1", new Drinks.ColdDrink("1", 1, 0) },
                {"2", new Drinks.ColdDrink("2", 2, 0) }
            };

            yield return new object[] { drinks, machine, expected };

            machine = new ColdDrinksMachine("1", "1", new Dictionary<string, AbstractDrink>());

            drinks = new Dictionary<string, AbstractDrink>();

            expected = new Dictionary<string, ColdDrink>();

            yield return new object[] { drinks, machine, expected };
        }
    }
}
