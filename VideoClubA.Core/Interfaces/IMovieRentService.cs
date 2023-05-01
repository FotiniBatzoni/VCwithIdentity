using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClubA.Core.Entities;

namespace VideoClubA.Core.Interfaces
{
    public interface IMovieRentService
    {
        public List<MovieRent> GetMovieRents();

        public List<MovieRent> GetRentsPerCustomer(string customerId);

        public void CreateReservation(MovieRent movieRent);

    }
}
