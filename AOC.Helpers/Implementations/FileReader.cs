using AOC.Helpers.Contracts;

namespace AOC.Helpers.Implementations
{
    public class FileReader : IFileReader
    {
        private readonly string _filePath = "C:\\Users\\mpara\\Desktop\\adventOfCode\\calibrationDocuemnt.txt";

        private StreamReader StreamReader {  get; set; }

        public FileReader() 
        { 
            StreamReader = new StreamReader(_filePath);
        }

        public string[] ReadCalibrationDocument()
        {
            using (StreamReader)
            {
                string[]? result = new string[1000];
                int i = 0;
                while (StreamReader.Peek() >= 0)
                {
                    result[i] = StreamReader.ReadLine();
                    i++;
                }
                
                return result;
            }
        }
    }
}
