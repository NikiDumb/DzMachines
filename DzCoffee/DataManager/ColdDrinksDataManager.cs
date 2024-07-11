using DzCoffee.Drinks;
using System.Text.Json;

namespace DzCoffee.DataManager
{
    public class ColdDrinksDataManager
    {
        public string DrinksJSON { get; set; }

        public List<ColdDrink> Drinks { get; set; }

        private string _filePath;

        public ColdDrinksDataManager(string filePath)
        {
            Drinks = new List<ColdDrink>();

            DrinksJSON = "";

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

        public List<ColdDrink> ReadFile()
        {
            List<ColdDrink> drinksBuffer = new List<ColdDrink>();

            StreamReader reader = new StreamReader(_filePath);
            DrinksJSON = reader.ReadToEnd();
            reader.Close();

            if (DrinksJSON != "")
            {
                drinksBuffer = JsonSerializer.Deserialize<List<ColdDrink>>(DrinksJSON);
            }

            return drinksBuffer;
        }

        public Dictionary<string, ColdDrink> ReturnDrinksDict()
        {
            Dictionary<string, ColdDrink> coldDrinksDict = new Dictionary<string, ColdDrink>();
            List<ColdDrink> coldDrinks = ReadFile();

            foreach (ColdDrink drink in coldDrinks)
            {
                coldDrinksDict.Add(drink.Name, drink);
            }

            return coldDrinksDict;
        }


        public Dictionary<string, string> WriteParameters()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            Console.Write("Название: ");
            string name = Console.ReadLine();
            parameters.Add("name", name);

            Console.Write("Сколько бутылок принес: ");
            string count = Console.ReadLine();
            parameters.Add("count", count);

            Console.Write("Сколько стоит: ");
            string price = Console.ReadLine();
            parameters.Add("price", price);

            return parameters;
        }

        public void AddDrink(Dictionary<string, string> parameters)
        {
            try
            {
                ColdDrink coldDrink = new ColdDrink(
                    parameters["name"],
                    Convert.ToDouble(parameters["price"]),
                    Convert.ToInt32(parameters["count"])
                    );

                Drinks.Add(coldDrink);

                WriteToFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Насрал в консоль {ex.ToString()}");
            }
        }
        private void WriteToFile()
        {
            List<ColdDrink> parametersBuffer = ReadFile();

            parametersBuffer.AddRange(Drinks);

            StreamWriter writer = new StreamWriter(_filePath);

            writer.Write(JsonSerializer.Serialize(parametersBuffer));
            writer.Close();
        }
    }
}
