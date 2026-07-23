using System;
namespace BookApi.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public ICollection<BookAuthor> Books { get; set; } = new List<BookAuthor>();
    
    }
}