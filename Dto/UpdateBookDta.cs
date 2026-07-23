namespace BookApi.Dto
{
    public class UpdateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; } = default;
    }
}