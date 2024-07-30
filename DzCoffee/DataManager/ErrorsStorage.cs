namespace DzCoffee.DataManager
{
    public class ErrorsStorage
    {
        public string ErrorsJSON { get; set; }

        private string _filePath;

        public ErrorsStorage(string filePath)
        {
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

        public string GetErrorsJSON()
        {
            var ErrorsJSON = string.Empty;

            StreamReader reader = new StreamReader(_filePath);
            ErrorsJSON += reader.ReadToEnd();
            reader.Close();

            return ErrorsJSON;
        }

        public void WriteToFile(string error)
        {
            if (error != "")
            {
                var ErrorsJSON = GetErrorsJSON();
                ErrorsJSON += error;

                StreamWriter writer = new StreamWriter(_filePath);
                writer.WriteLine(ErrorsJSON);
                writer.Close();
            }
        }

        public void ClearErrors()
        {
            StreamWriter writer = new StreamWriter(_filePath);

            writer.Write("");
            writer.Close();
        }

        public void PrintErrors()
        {
            Console.WriteLine(ErrorsJSON);
        }
    }
}
