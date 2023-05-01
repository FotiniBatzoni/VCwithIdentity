using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideoClubA.Core.Entities;
using VideoClubA.Core.Interfaces;
using VideoClubA.Web.Areas.ActiveReservations.Models;

namespace VideoClubA.Web.Areas.ActiveReservations.Controllers
{
    public class ActiveReservationController : Controller
    {

        private readonly IMovieRentService _movieRentDb;
        private readonly ICustomerSevice _customerDb;
        private readonly IMovieCopyService _movieCopyDb;
        private readonly IMapper _mapper;

        public ActiveReservationController(IMovieRentService movieRentDb,
            ICustomerSevice customerDb, IMovieCopyService movieCopyDb,
            IMapper mapper)
        {
            _movieRentDb = movieRentDb;
            _customerDb = customerDb;
            _movieCopyDb = movieCopyDb;
            _mapper = mapper;
        }

        [HttpGet]
        [Area("ActiveReservations")]
        public IActionResult ActiveReservationsPanel(int page = 1, int pageSize = 5)
        {

            return View(PaginateReservations(page, pageSize));
        }

        private ActiveReservationsViewModel PaginateReservations(int page, int pageSize)
        {

            //Validate Page
            page = Math.Clamp(page, 1, pageSize);

            int startIndex = (int)((page - 1) * pageSize);

            List<MovieRent> allReservations = _movieRentDb.GetMovieRents();

            var activeReservations = _mapper.Map<List<ActiveReservationViewModel>>
                (allReservations);

            int totalPages = (int)Math.Ceiling((double)activeReservations.Count / pageSize);

            activeReservations = activeReservations.Skip(startIndex).Take(pageSize).ToList();


            var reservationsViewModel = new ActiveReservationsViewModel(
                activeReservations, page);


            reservationsViewModel.CurrentPage = page;
            reservationsViewModel.TotalPages = totalPages;

            return reservationsViewModel;

        }
    }
}
