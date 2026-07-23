using System;
using System.Collections.Generic;
namespace BookApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public ICollection<BookAuthor> Authors { get; set; } = new List<BookAuthor>();
        public ICollection<BookCategory> Categories { get; set; } = new List<BookCategory>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    
    }
}