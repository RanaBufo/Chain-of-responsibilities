using ChainOfResponsibilities.DB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilities.Handlers
{
    internal class AddNameUserHandler : BaseHandlers
    {
        public override void Process(Request request)
        {
            if(request.Data is BankData data)
            {
                Console.Write("Введите имя: ");
                data.Name = Console.ReadLine();
                if (_validateClass.ValidateNameOrSurname(data.Name))
                {
                    data.Name = data.Name.ToLower(new CultureInfo("ru-RU"));
                    data.Name = char.ToUpper(data.Name[0], new CultureInfo("ru-RU")) + data.Name.Substring(1);
                    request.Data = data;
                    if (_nextHandler != null) _nextHandler.Process(request);
                }
                else
                {
                    Console.WriteLine("Имя может содержать только буквы!!!");
                }
            }
            else
            {
                throw new Exception("НЕДОПУСТИМЫЕ ДАННЫЕ");
            }
        }
    }
}
