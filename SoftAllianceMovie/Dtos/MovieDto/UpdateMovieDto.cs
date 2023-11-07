namespace SoftAllianceMovie.Dtos.MovieDto
{
    public class UpdateMovieDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
        public decimal TicketPrice { get; set; }
        public string? Country { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
