using AdventOfCode.Day_1;
using AOC.Helpers.Contracts;
using AOC.Helpers.Implementations;
using Ninject;
using System.Reflection;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace AdventOfCode
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating kernel...");
            IKernel kernel = new StandardKernel(new DIModule());
            try
            {
                ITaskRunner runner = new TrebuchetTaskRunner(new FileReader());
                runner.Run();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                //this comment is a test for a test branch
            }
        }
    }
}
