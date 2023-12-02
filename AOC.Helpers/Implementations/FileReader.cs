using AOC.Helpers.Contracts;

namespace AOC.Helpers.Implementations
{
    public class FileReader : IFileReader
    {
        private string _filePath;

        private StreamReader StreamReader { get; set; }

        public FileReader(string filePath)
        {
            _filePath = filePath;
            StreamReader = new StreamReader(_filePath);
        }

        public string[] ReadDocument(int collectionSize)
        {
            using (StreamReader)
            {
                string[]? result = new string[collectionSize];
                int i = 0;
                while (StreamReader.Peek() >= 0)
                {
                    result[i] = StreamReader.ReadLine();
                    i++;
                }

                return result;
            }
        }

        public IEnumerable<string> ReadDocumentAsList()
        {
            using (StreamReader)
            {
                List<string> result = new List<string>();
                while (StreamReader.Peek() >= 0)
                {
                    result.Add(StreamReader.ReadLine());
                }

                return result;
            }
        }
    }
}