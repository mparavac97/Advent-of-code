using AdventOfCode.Day_1;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITaskRunner>().To<TrebuchetTaskRunner>();
        }
    }
}
