using DzCoffee.Drinks;
using System.Text.Json;

namespace DzCoffee.DataManager
{
    internal class CoffeeReceipesDataManager
    {
        public string HotDrinksJSON { get; set; }

        public List<HotDrink> HotDrinks { get; set; }

        private string _filePath;

        public CoffeeReceipesDataManager(string filePath)
        {
            HotDrinks = new List<HotDrink>();

            HotDrinksJSON = "";

            ChangeFilePath(filePath);
        }

        public void ChangeFilePath(string filePath)
        {
            filePath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, filePath);
            if (File.Exists(filePath))
            {
                _filePath = filePath;
            }
            else
            {
                StreamWriter writer = new StreamWriter(filePath);
                writer.Close();
                _filePath = filePath;
            }
        }

        public List<HotDrink> ReadFile()
        {
            List<HotDrink> hotDrinksBuffer = new List<HotDrink>();

            StreamReader reader = new StreamReader(_filePath);
            HotDrinksJSON = reader.ReadToEnd();
            reader.Close();

            if (HotDrinksJSON != "")
            {
                hotDrinksBuffer = JsonSerializer.Deserialize<List<HotDrink>>(HotDrinksJSON);
            }

            return hotDrinksBuffer;
        }

        public Dictionary<string, HotDrink> ReturnReceipesDict()
        {
            Dictionary<string, HotDrink> hotDrinksDict = new Dictionary<string, HotDrink>();
            List<HotDrink> hotDrinks = ReadFile();

            foreach(HotDrink drink in hotDrinks)
            {
                hotDrinksDict.Add(drink.Name, drink);
            }

            return hotDrinksDict;
        }


        public Dictionary<string, string> WriteReceipe()
        {
            Dictionary<string, string> ingredients = new Dictionary<string, string>();

            Console.Write("Название: ");
            string name = Console.ReadLine();
            ingredients.Add("name",name);

            Console.Write("Сколько водички: ");
            string water = Console.ReadLine();
            ingredients.Add("water", water);

            Console.Write("Сколько кофе: ");
            string coffee = Console.ReadLine();
            ingredients.Add("coffee", coffee );

            Console.Write("Сколько молока: ");
            string milk = Console.ReadLine();
            ingredients.Add("milk", milk);

            Console.Write("Сколько сахара: ");
            string sugar = Console.ReadLine();
            ingredients.Add("sugar", sugar );

            Console.Write("Сколько стоит: ");
            string price = Console.ReadLine();
            ingredients.Add("price", price);

            return ingredients;
        }

        public void AddReceipe(Dictionary<string, string> receipe)
        {
            try
            {
                HotDrink coffeeReceipe = new HotDrink(
                    receipe["name"],
                    Convert.ToDouble(receipe["water"]),
                    Convert.ToDouble(receipe["coffee"]),
                    Convert.ToDouble(receipe["milk"]),
                    Convert.ToInt32(receipe["sugar"]),
                    Convert.ToDouble(receipe["price"])
                    );

                HotDrinks.Add(coffeeReceipe);

                WriteToFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Насрал в консоль { ex.ToString()}");
            }
        }
        private void WriteToFile()
        {
            List<HotDrink> receipesBuffer = ReadFile();

            receipesBuffer.AddRange(HotDrinks);

            StreamWriter writer = new StreamWriter(_filePath);

            writer.Write(JsonSerializer.Serialize<List<HotDrink>>(receipesBuffer));
            writer.Close();
        }
    }
}
