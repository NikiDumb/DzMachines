
namespace DzCoffee.DataManager
{
    public class ErrorsDataManager
    {
        public string ErrorsJSON { get; set; }

        private string _filePath;

        public ErrorsDataManager(string filePath)
        {
            ErrorsJSON = "";

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

        public void GetErrorsJSON()
        {
            ErrorsJSON = string.Empty;
            StreamReader reader = new StreamReader(_filePath);
            ErrorsJSON += reader.ReadToEnd();
            reader.Close();

        }

        public void WriteToFile(string error)
        {
            GetErrorsJSON();
            ErrorsJSON += error;

            StreamWriter writer = new StreamWriter(_filePath);
            writer.WriteLine(ErrorsJSON);
            writer.Close();
        }

        public void PrintErrors()
        {
            Console.WriteLine(ErrorsJSON);
        }
    }
}
