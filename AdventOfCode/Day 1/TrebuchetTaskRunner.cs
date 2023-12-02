using AOC.Helpers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Day_1
{
    public class TrebuchetTaskRunner : ITaskRunner
    {
        public IFileReader FileReader {  get; set; }

        public TrebuchetTaskRunner(IFileReader fileReader)
        {
            FileReader = fileReader;
        }

        public void Run()
        {
            Console.WriteLine("Starting the trebuchet task...");

            var calibration = FileReader.ReadCalibrationDocument();

            var result = GetFirstAndLastDigitFromCalibration(calibration);

            int sum = 0;
            foreach (var res in result)
            {
                sum += res;
            }

            Console.WriteLine(sum);
        }

        public IEnumerable<int> GetFirstAndLastDigitFromCalibration(IEnumerable<string> document)
        {
            List<int> result = new List<int>();

            foreach (var calibration in document)
            {
                var digitString = calibration.Where(Char.IsDigit);
                var firstDigit = digitString.First();
                var lastDigit = digitString.Last();

                
                var sum = firstDigit.ToString() + lastDigit.ToString();

                result.Add(Int32.Parse(sum));
                Console.WriteLine($"Original: {calibration}; Result: {sum}.");
            }


            return result;
        }
    }
}
