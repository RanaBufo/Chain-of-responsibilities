using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilities
{
    internal interface IHandler
    {
        void SetNextHandler(IHandler handler);
        void Process(Request request);
    }
}
