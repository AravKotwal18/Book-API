using BookApi.Data;
using BookApi.Models;

namespace BookApi
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedDataContext()
        {
            if (!_context.BookAuthors.Any())
            {
                var bookAuthors = new List<BookAuthor>()
                {
                    new BookAuthor()
                    {
                        Book = new Book()
                        {
                            Title = "Dune",
                            PublishedDate = new DateTime(1997, 6, 26),
                            Reviews = new List<Review>()
                            {
                                new Review { Title = "Great book", Rating = 5, Comment = "Amazing story" },
                                new Review { Title = "Loved it", Rating = 4, Comment = "Very engaging" }
                            },
                            Categories = new List<BookCategory>()
                            {
                                new BookCategory { Category = new Category() { Name = "Fantasy", Description = "Fantasy books" } }
                            }
                        },
                        Author = new Author()
                        {
                            FirstName = "Frank",
                            SecondName = "Herbert",
                            Country = "USA"
                        }
                    }
                };

                _context.BookAuthors.AddRange(bookAuthors);
                _context.SaveChanges();
            }
        }
    }
}