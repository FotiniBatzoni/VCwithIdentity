using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClubA.Core.Entities;

namespace VideoClubA.Core.Interfaces
{
    public interface ICustomerSevice
    {
        public List<Customer> GetAllCustomers();

        public Customer GetCustomer(string firstName, string lastName);
    }
}
