using System;
namespace BookApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public ICollection<BookAuthor> Authors { get; set; }
        public ICollection<BookCategory> Categories { get; set; }
        public ICollection<Review> Reviews { get; set; }
    
    }
}