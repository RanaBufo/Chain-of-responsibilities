using ChainOfResponsibilities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilities.Handlers
{
    internal class AddSummaMoneyHandler : BaseHandlers
    {
        public override void Process(Request request)
        {
            if (request.Data is BankData data)
            {
                Console.Write("Внесите деньги: ");
                float.TryParse(Console.ReadLine(), out float money);
                data.Money = money;
                if (money > 0)
                {
                    request.Data = data;
                    if (_nextHandler != null) _nextHandler.Process(request);
                }
                else
                {
                    Console.WriteLine("Вы не внесли деньги!!!");
                }
            }
            else
            {
                throw new Exception("НЕДОПУСТИМЫЕ ДАННЫЕ");
            }
        }
    }
}
