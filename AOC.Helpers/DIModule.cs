using AOC.Helpers.Contracts;
using AOC.Helpers.Implementations;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC.Helpers
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFileReader>().To<FileReader>();
        }
    }
}
