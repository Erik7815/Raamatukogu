namespace Library.Models
{
    public class BookDeleteViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedYear { get; set; }
        public bool IsAvailable { get; set; }
    }
}
