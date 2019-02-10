using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreezingFruitFoot.Models
{
    public class Customer
    {
        private int _id;
        private int agent_id;
        private Guid guid;
        private bool isActive;
        private string balance;
        private int age;
        private string eyeColor;
        private CustomerName name;
        private string company;
        private string email;
        private string phone;
        private string address;
        private DateTime registered;
        private string latitude;
        private string longitude;
        private List<string> tags;

        public int _Id { get => _id; set => _id = value; }
        public int Agent_id { get => agent_id; set => agent_id = value; }
        public Guid Guid { get => guid; set => guid = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public string Balance { get => balance; set => balance = value; }
        public int Age { get => age; set => age = value; }
        public string EyeColor { get => eyeColor; set => eyeColor = value; }
        public CustomerName Name { get => name; set => name = value; }
        public string Company { get => company; set => company = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public DateTime Registered { get => registered; set => registered = value; }
        public string Latitude { get => latitude; set => latitude = value; }
        public string Longitude { get => longitude; set => longitude = value; }
        public List<string> Tags { get => tags; set => tags = value; }
    }
}
