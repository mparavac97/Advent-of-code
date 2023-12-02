using AOC.Helpers.Contracts;
using AOC.Helpers.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Day2
{
    public class TrebuchetTask2Runner : ITaskRunner
    {
        #region Private Fields

        private readonly string[] _stringDigits = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

        private Dictionary<string, string> wordToDigitMap = new Dictionary<string, string>
        {
            {"1e", "one"},
            {"2o", "two"},
            {"3e", "three"},
            {"4r", "four"},
            {"5e", "five"},
            {"6x", "six"},
            {"7n", "seven" },
            {"8t", "eight"},
            {"9e", "nine"}
        };

        #endregion Private Fields

        #region Public Constructors

        public TrebuchetTask2Runner(IFileReader fileReader)
        {
            FileReader = fileReader;
        }

        #endregion Public Constructors

        #region Public Properties

        public IFileReader FileReader { get; set; }

        #endregion Public Properties

        #region Public Methods

        public IEnumerable<string> GetAllDigitsFromDocument(IEnumerable<string> document)
        {
            List<string> result = new List<string>();
            foreach (var calibration in document)
            {
                var replacedWord = ReplaceAllWordsWithDigit(calibration);
                result.Add(replacedWord);
            }

            return result;
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

        public string ReplaceAllWordsWithDigit(string word)
        {
            foreach (var digit in wordToDigitMap)
            {
                if (word.Contains(digit.Value))
                {
                    word = word.Replace(digit.Value, digit.Key.ToString());
                }
            }
            return word;
        }

        public void Run()
        {
            var calibration = FileReader.ReadCalibrationDocument();

            var replacedStrings = GetAllDigitsFromDocument(calibration);

            var contains = replacedStrings.Select(p => p.Contains("8l"));

            var result = GetFirstAndLastDigitFromCalibration(replacedStrings);

            int sum = 0;
            foreach (var res in result)
            {
                sum += res;
            }

            Console.WriteLine(sum);
        }

        #endregion Public Methods

        #region Public Classes

        public class CalculationResult
        {
            #region Public Properties

            public string Original { get; set; }

            public string Replaced { get; set; }

            public int Result { get; set; }

            #endregion Public Properties
        }

        #endregion Public Classes
    }
}