using ChainOfResponsibilities.DB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilities.Handlers
{
    internal class AddSurnameHandler : BaseHandlers
    {
        public override void Process(Request request)
        {
            if (request.Data is BankData data)
            {
                Console.Write("Введите фамилию: ");
                data.Surname = Console.ReadLine();
                if (_validateClass.ValidateNameOrSurname(data.Surname))
                {
                    data.Surname = data.Surname.ToLower(new CultureInfo("ru-RU"));
                    data.Surname = char.ToUpper(data.Surname[0], new CultureInfo("ru-RU")) + data.Surname.Substring(1);
                    request.Data = data;
                    if (_nextHandler != null) _nextHandler.Process(request);
                }
                else
                {
                    Console.WriteLine("Фамилия может содержать только буквы!!!");
                }
            }
            else
            {
                throw new Exception("НЕДОПУСТИМЫЕ ДАННЫЕ");
            }
        }
    }
}
