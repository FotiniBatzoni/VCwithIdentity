
using System.ComponentModel.DataAnnotations;

namespace VideoClubA.Core.Entities
{
    public class Customer
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public bool IsAdmin { get; set; }
    }
}
