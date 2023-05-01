

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoClubA.Core.Entities
{
    public class MovieRent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string MovieTitle { get; set; }

        public  string MovieCopyId { get; set; }

        public string CustomerId { get; set; }

        public DateTime RentDate { get; set; }

        public DateTime ReturnDate { get; set; }   

        public string? Comment { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual MovieCopy MovieCopy { get; set; }

        public virtual Customer Customer { get; set; }
      
   

    }
}
