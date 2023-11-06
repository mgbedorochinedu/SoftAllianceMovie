using System.ComponentModel.DataAnnotations.Schema;

namespace SoftAllianceMovie.Models
{
    public class Genre : BaseEntity
    {
        public int GenreId { get; set; }
        public string? GenreName { get; set; }

        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}
