using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagement.Domain.ValueObjects
{
    public class TestCenterAddress : ValueObject
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public TestCenterAddress()
        {

        }
        public TestCenterAddress(string city, string state, string street, string zipCode)
        {
            City = city;
            State = state;
            Street = street;
            ZipCode = zipCode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            return new object[] { City, State, Street, ZipCode };
        }
    }
}
