using ChainOfResponsibilities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilities.Handlers
{
    internal class AddPincodeUserHandler : BaseHandlers
    {
        public override void Process(Request request)
        {
            if (request.Data is BankData data)
            {
                Console.Write("Внесите пинкод: ");
                data.PinCode = Console.ReadLine();
                if (data.PinCode.Length == 4)
                {
                    request.Data = data;
                    if (_nextHandler != null) _nextHandler.Process(request);
                }
                else
                {
                    Console.WriteLine("Вы должны ввести только 4 цифры!!!");
                }
            }
            else
            {
                throw new Exception("НЕДОПУСТИМЫЕ ДАННЫЕ");
            }
        }
    }
}
