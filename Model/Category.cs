using System;
namespace BookApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<BookCategory> Books { get; set; } = new List<BookCategory>();
    }
}