using System.ComponentModel.DataAnnotations;

namespace SoftAllianceMovie.Dtos.MovieDto
{
    public class AddMovieDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Release Date is required")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Range(1, 5)]
        public double Rating { get; set; }
        [Required(ErrorMessage = "Ticket Price is required")]
        public decimal TicketPrice { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string? Country { get; set; }
        [Required(ErrorMessage = "Photo URL is required")]
        public string? PhotoUrl { get; set; } //This will require an Azure Blob Storage, to be able to save the Image URL on the database
    }
}
