using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChainOfResponsibilities
{
    internal  struct ValidateStruct
    {
        public bool ValidateNameOrSurname(string? data)
        {
            return Regex.IsMatch(data, @"^[А-Яа-яЁё]+$"); ;
        }
    }
}
