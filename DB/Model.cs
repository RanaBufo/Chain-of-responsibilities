using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilities.DB
{
    internal class BankData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public float Money { get; set; }
        public string AccountNumber { get; set; }
        public string PinCode { get; set; }
        public BankData() 
        { 
            this.ID = -1;
            this.Name = "";
            this.Surname = "";
            this.Age = 0;
            this.Money = 0;
            this.AccountNumber = "";
            this.PinCode = "";
        }
    }
}
