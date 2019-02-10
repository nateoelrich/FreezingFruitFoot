using FreezingFruitFoot;
using FreezingFruitFoot.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAgents_ContentNotNull()
        {
            var repo = new Repository();
                    
            var result = repo.GetAgents();

            Assert.IsTrue(null != result.Content);
        }

        [Test]
        public void GetAgents_ContentCountGreaterThan0()
        {
            var repo = new Repository();

            var result = repo.GetAgents();

            Assert.IsTrue(result.Content.Count > 0);
        }

        [Test]
        public void GetAgent_ContentNotNull()
        {
            var repo = new Repository();

            var result = repo.GetAgent(321);

            Assert.IsTrue(null != result.Content);
        }

        [Test]
        public void InsertAgent_WasSuccessful()
        {
            var repo = new Repository();


            var a = new Agent()
            {
                _Id = 999,
                Name = "Nate",
                Address = "504 Test Ave",
                City = "Seattle",
                State = "WA",
                ZipCode = "98101",
                Tier = 1,
                PhoneNumbers = new List<Phone>() { new Phone() { PhoneType = "mobile", Number = "123-789-7897" } }
            };

            var result = repo.InsertAgent(a);

            Assert.IsTrue(null != result.Content);
        }

        [Test]
        public void InsertAgent_CountIncremented()
        {
            var repo = new Repository();

            var originalCount = repo.GetAgents().Content?.Count;

            var a = new Agent()
            {
                _Id = 101010,
                Name = "Nate",
                Address = "504 Test Ave",
                City = "Seattle",
                State = "WA",
                ZipCode = "98101",
                Tier = 1,
                PhoneNumbers = new List<Phone>() { new Phone() { PhoneType = "mobile", Number = "123-789-7897" } }
            };

            var result = repo.InsertAgent(a);

            var newCount = repo.GetAgents().Content?.Count;

            Assert.IsTrue(newCount == originalCount + 1);
        }

        [Test]
        public void UpdateAgent_ChangesReflected()
        {
            var repo = new Repository();

            var lastAgent = repo.GetAgents().Content.Last();

            lastAgent.Name = "Has Changed";         

            var result = repo.UpdateAgent(lastAgent);

            var postChangeAgent = repo.GetAgent(lastAgent._Id).Content;

            Assert.IsTrue(postChangeAgent.Name == "Has Changed");
        }

        [Test]
        public void GetCustomers_ContentNotNull()
        {
            var repo = new Repository();

            var result = repo.GetCustomers();

            Assert.IsTrue(null != result.Content);
        }

        [Test]
        public void GetCustomers_ContentCountGreaterThan0()
        {
            var repo = new Repository();

            var result = repo.GetCustomers();

            Assert.IsTrue(result.Content.Count > 0);
        }

        [Test]
        public void GetCustomersByAgentId_CountIs22()
        {
            var repo = new Repository();

            var result = repo.GetCustomers(467);

            Assert.IsTrue(result.Content.Count == 22);
        }

        [Test]
        public void InsertCustomer_WasSuccessful()
        {
            var repo = new Repository();

            var c = new Customer()
            {
                Name = new CustomerName() { First = "Cust", Last = "Tomer" },
                _Id = 56647854,
                Age = 28,
                EyeColor = "blue"
            };

            var result = repo.InsertCustomer(c);

            Assert.IsTrue(null != result.Content);
        }

        [Test]
        public void InsertCustomer_CountIncremented()
        {
            var repo = new Repository();

            var originalCount = repo.GetCustomers().Content?.Count;

            var c = new Customer()
            {
                Name = new CustomerName() { First = "Cust", Last = "Tomer" },
                _Id = 911911911,
                Age = 28,
                EyeColor = "blue"
            };

            var result = repo.InsertCustomer(c);

            var newCount = repo.GetCustomers().Content?.Count;

            Assert.IsTrue(newCount == originalCount + 1);
        }

        [Test]
        public void UpdateCustomer_ChangesReflected()
        {
            var repo = new Repository();

            var lastCust = repo.GetCustomers().Content.Last();

            lastCust.Name = new CustomerName() { First = "Cust", Last = "Tomer" };

            var result = repo.UpdateCustomer(lastCust);

            var postChangeCust = repo.GetCustomers().Content.Where(x => x._Id == lastCust._Id).FirstOrDefault();

            Assert.IsTrue(postChangeCust.Name.Last == "Tomer");
        }

        [Test]
        public void DeleteCustomer_CountDecremented()
        {
            var repo = new Repository();

            var lastCustId = repo.GetCustomers().Content.Last()._Id;

            var originalCount = repo.GetCustomers().Content?.Count;

            var result = repo.DeleteCustomer(lastCustId);

            var newCount = repo.GetCustomers().Content?.Count;

            Assert.IsTrue(newCount == originalCount - 1);
        }
    }
}