using System;
namespace BookApi.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public Book Book { get; set; }
    
    }
}