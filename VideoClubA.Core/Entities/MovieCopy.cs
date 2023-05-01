

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoClubA.Core.Entities
{
    public class MovieCopy
    {
        public string Id { get; set; }

        public string MovieId { get; set; }

        public bool IsAvailable { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
