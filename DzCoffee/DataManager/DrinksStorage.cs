﻿using DzCoffee.Drinks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DzCoffee.DataManager
{
    public class DrinksStorage<T> where T : AbstractDrink
    {
        private string _filePath { get; set; }

        public DrinksStorage(string filepath)
        {
            ChangeFilePath(filepath);
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

        public Dictionary<string, T> ReturnDrinksDict()
        {
            var drinksDict = new Dictionary<string, T>();

            List<T> drinks = ReadFile();

            foreach (var drink in drinks)
            {
                drinksDict.Add(drink.Name, drink);
            }

            return drinksDict;
        }

        public List<T> ReadFile()
        {
            List<T> drinks = new List<T>();

            var reader = new StreamReader(_filePath);
            var drinksJSON = reader.ReadToEnd();
            reader.Close();

            if (drinksJSON != "")
            {
                drinks = JsonSerializer.Deserialize<List<T>>(drinksJSON);
            }

            return drinks;
        }

        public void AddDrink(T drink)
        {
            var drinks = ReadFile();

            if (!drinks.Contains(drink))
            {
                drinks.Add(drink);

                WriteToFile(drinks);
            }
        }

        public void WriteToFile(List<T> drinks)
        {
            StreamWriter writer = new StreamWriter(_filePath);

            writer.Write(JsonSerializer.Serialize(drinks));
            writer.Close();
        }

        public bool RemoveDrink(string drinkName)
        {
            var drinks = ReadFile();

            foreach (var drink in drinks)
            {
                if (drink.Name == drinkName)
                {
                    drinks.Remove(drink);
                    WriteToFile(drinks);

                    return true;
                }
            }
            return false;
        }

        public bool RemoveDrink(T drinkToRemove)
        {
            var drinks = ReadFile();

            if (drinks.Contains(drinkToRemove))
            {
                drinks.Remove(drinkToRemove);
                WriteToFile(drinks);

                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is DrinksStorage<T> storage &&
                   _filePath == storage._filePath;
        }
    }
}