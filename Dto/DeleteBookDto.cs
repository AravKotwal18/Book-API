namespace BookApi.Dto
{
    public class DeleteBookDto
    {
        public string Title { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
    }
}