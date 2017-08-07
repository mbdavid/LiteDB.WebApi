using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiteDB.WebApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }
        public List<string> Phones { get; set; }
        public bool Active { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}