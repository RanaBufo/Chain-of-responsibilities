using ChainOfResponsibilities.DB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilities.Handlers
{
    internal class AddMoneyHandler : BaseHandlers
    {
        public override void Process(Request request)
        {
            if (request.Data is BankData data)
            {
                var jsonFilePath = "D://Project/ChainOfResponsibilities/DB/Data.json";
                List<BankData> allUsers = new List<BankData>();

                string jsonData = System.IO.File.ReadAllText(jsonFilePath);

                allUsers = JsonConvert.DeserializeObject<List<BankData>>(jsonData);
                allUsers[data.ID].Money += data.Money;
                string json = JsonConvert.SerializeObject(allUsers, Formatting.Indented);

                System.IO.File.WriteAllText(jsonFilePath, json);
                Console.WriteLine("Деньги внесены");
            }
            else
            {
                throw new Exception("НЕДОПУСТИМЫЕ ДАННЫЕ");
            }
        }
    }
}
