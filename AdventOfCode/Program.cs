using AdventOfCode.Day_1;
using AdventOfCode.Day2;
using AOC.Helpers.Contracts;
using AOC.Helpers.Implementations;
using Ninject;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace AdventOfCode
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Creating kernel...");
            IKernel kernel = new StandardKernel(new DIModule());
            try
            {
                //var sw = new Stopwatch();
                //sw.Start();
                //ITaskRunner runner = new TrebuchetTask2Runner(new FileReader("C:\\Users\\mpara\\Desktop\\adventOfCode\\calibrationDocuemnt.txt"));
                //runner.Run();
                //sw.Stop();
                //Console.WriteLine(sw.Elapsed.ToString());

                ITaskRunner gameRunner = new GameTaskRunner(new FileReader("C:\\Users\\mpara\\Desktop\\adventOfCode\\gameDocument.txt"));
                gameRunner.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}