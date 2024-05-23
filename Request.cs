using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilities
{
    internal class Request
    {
        public object Data { get; set; }
        public List<string> ValidationMassege { get; set; }
        public Request()
        {
            ValidationMassege = new List<string>();
        }
    }
}
