using ChainOfResponsibilities.DB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilities.Handlers
{
    internal class AddAgeUserHandler : BaseHandlers
    {
        public override void Process(Request request)
        {
            if (request.Data is BankData data)
            {
                Console.Write("Введите возраст: ");
                int.TryParse(Console.ReadLine(), out int age);
                data.Age = age;
                if (age >= 14)
                {
                    request.Data = data;
                    if (_nextHandler != null) _nextHandler.Process(request);
                }
                else
                {
                    Console.WriteLine("Вы должны вводить только цифры и ваш возраст должен быть не младше 14!!!");
                }
            }
            else
            {
                throw new Exception("НЕДОПУСТИМЫЕ ДАННЫЕ");
            }
        }
    }
}
