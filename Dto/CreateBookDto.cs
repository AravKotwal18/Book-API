namespace BookApi.Dto
{
    public class CreateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; } = default;
        public string? Author { get; set; }
    }
}