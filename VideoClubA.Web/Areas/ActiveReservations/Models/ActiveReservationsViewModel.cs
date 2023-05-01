using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace VideoClubA.Web.Areas.ActiveReservations.Models
{
    public class ActiveReservationsViewModel
    {
        public List<ActiveReservationViewModel> ActiveReservationsList { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public ActiveReservationsViewModel()
        {
            
        }

        public ActiveReservationsViewModel(List<ActiveReservationViewModel> activeReservationsList, int currentPage)
        {
            ActiveReservationsList = activeReservationsList;
            CurrentPage = currentPage;
        }

    }
}
