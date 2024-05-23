using ChainOfResponsibilities.DB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilities
{
    internal struct LastIdStruct
    {
        public int FindNewId()
        {
            var jsonFilePath = "D://Project/ChainOfResponsibilities/DB/LastId.json";
            int id;

            string jsonData = System.IO.File.ReadAllText(jsonFilePath);

            id = JsonConvert.DeserializeObject<int>(jsonData);
            return id;
        }
        public void AddNewId()
        {
            var jsonFilePath = "D://Project/ChainOfResponsibilities/DB/LastId.json";
            int id;

            string jsonData = System.IO.File.ReadAllText(jsonFilePath);

            id = JsonConvert.DeserializeObject<int>(jsonData) + 1;
            string json = JsonConvert.SerializeObject(id, Formatting.Indented);

            System.IO.File.WriteAllText(jsonFilePath, json);
        }
    }
}
