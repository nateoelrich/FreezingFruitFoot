using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreezingFruitFoot.Models
{
    public class Agent
    {
        private int _id;
        private string name;
        private string address;
        private string city;
        private string state;
        private string zipCode;
        private int tier;
        private List<Phone> phoneNumbers;

        public int _Id { get => _id; set => _id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string ZipCode { get => zipCode; set => zipCode = value; }
        public int Tier { get => tier; set => tier = value; }
        public List<Phone> PhoneNumbers { get => phoneNumbers; set => phoneNumbers = value; }
    }
}
