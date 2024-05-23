using ChainOfResponsibilities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilities.Handlers
{
    internal class AddAccountNumberUserHandler : BaseHandlers
    {
        public override void Process(Request request)
        {
            if (request.Data is BankData data)
            {
                Console.Write("Введите номер карты: ");
                data.AccountNumber = Console.ReadLine();
                if (data.AccountNumber.Length == 16)
                {
                    data.AccountNumber = data.AccountNumber.Substring(0, 4) + " " +
                                         data.AccountNumber.Substring(4, 4) + " " +
                                         data.AccountNumber.Substring(8, 4) + " " +
                                         data.AccountNumber.Substring(12, 4);
                }

                if (data.AccountNumber.Length == 19)
                {
                    request.Data = data;
                    if (_nextHandler != null) _nextHandler.Process(request);
                }
                else
                {
                    Console.WriteLine("Вы должны вводить только цифры и длина номера карты должна быть ровно 16 символов!!!");
                }
            }
            else
            {
                throw new Exception("НЕДОПУСТИМЫЕ ДАННЫЕ");
            }
        }
    }
}
