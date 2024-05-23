using ChainOfResponsibilities.DB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilities.Handlers
{
    internal class FindAccountNumberHandler : BaseHandlers
    {
        public override void Process(Request request)
        {
            if (request.Data is BankData data)
            {
                var jsonFilePath = "D://Project/ChainOfResponsibilities/DB/Data.json";
                List<BankData> allUsers = new List<BankData>();

                // Чтение данных из файла JSON
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);

                // Десериализация JSON в список объектов Categories
                allUsers = JsonConvert.DeserializeObject<List<BankData>>(jsonData);
                foreach(var user in allUsers)
                {
                    if(user.AccountNumber == data.AccountNumber)
                    {
                        data.ID = user.ID;
                        request.Data = data;
                        break;
                    }
                }
                if(data.ID != -1)
                {
                    _nextHandler.Process(request);
                }
                else
                {
                    Console.WriteLine("Такой карты нет!!!");
                }
            }
            else
            {
                throw new Exception("НЕДОПУСТИМЫЕ ДАННЫЕ");
            }
        }
    }
}
