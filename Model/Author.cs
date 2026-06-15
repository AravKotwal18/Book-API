using System;
namespace BookApi.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Country { get; set; }
        public ICollection<BookAuthor> Books { get; set; }
    
    }
}