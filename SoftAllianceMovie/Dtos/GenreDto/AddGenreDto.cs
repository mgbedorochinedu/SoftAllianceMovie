using System.ComponentModel.DataAnnotations;

namespace SoftAllianceMovie.Dtos.GenreDto
{
    public class AddGenreDto
    {
        [Required(ErrorMessage = "Genre Name is required")]
        public string? GenreName { get; set; }
        [Required(ErrorMessage = "Movie ID is required")]
        public int MovieId { get; set; }

    }
}
