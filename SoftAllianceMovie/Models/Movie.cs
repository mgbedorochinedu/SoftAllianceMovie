namespace SoftAllianceMovie.Models
{
    public class Movie : BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
        public decimal TicketPrice { get; set; }
        public string? Country { get; set; }
        public string? PhotoUrl { get; set; }
        public ICollection<Genre>? Genre { get; set; }
       
    }
}
