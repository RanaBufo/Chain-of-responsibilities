using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilities.Handlers
{
    internal class BaseHandlers : IHandler
    {
        protected IHandler _nextHandler;
        protected ValidateStruct _validateClass;
        protected LastIdStruct lastIdStruct = new LastIdStruct();
        public BaseHandlers()
        {
            _nextHandler = null;
        }
        public void SetNextHandler(IHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }
        public virtual void Process(Request request)
        {
            throw new NotImplementedException();
        }
    }
}
