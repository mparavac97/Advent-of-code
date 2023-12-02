using AOC.Helpers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public interface ITaskRunner
    {
        void Run();

        IFileReader FileReader { get; set; }
    }
}
