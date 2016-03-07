using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaPractice
{
    public class Address
    {
        public string city { get; set; }
        public string country { get; set; }

        public Address(string city, string country)
        {
            this.city = city;
            this.country = country;
        }
    }
}
