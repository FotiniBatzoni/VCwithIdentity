
using Microsoft.EntityFrameworkCore;
using VideoClubA.Core.Entities;
using VideoClubA.Core.Interfaces;
using VideoClubA.Infrastucture.Data;

namespace VideoClubA.Common.Services
{
    public class CustomerService : ICustomerSevice
    {
        private readonly VideoClubDbContext _context;

        public CustomerService(VideoClubDbContext context)
        {
            _context = context;
        }
        public List<Customer> GetAllCustomers()
        {
            return  _context.Customers
                    .AsNoTracking()
                    .ToList();
        }
    }
   
}
