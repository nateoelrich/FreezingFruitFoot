using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreezingFruitFoot.Models
{
    public class Phone
    {
        private string phoneType;
        private string number;

        public string PhoneType { get => phoneType; set => phoneType = value; }
        public string Number { get => number; set => number = value; }
    }
}
