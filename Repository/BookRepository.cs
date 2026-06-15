using BookApi.Data;
using BookApi.Interfaces;
using BookApi.Models;
using Microsoft.EntityFrameworkCore;
namespace BookApi.Repository
{    
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Book> GetBooks()
        {
            // Copilot: Include Authors with each book to load the related author data
            return _context.Books.Include(b => b.Authors).ThenInclude(ba => ba.Author).ToList();
        }
        public Book? GetBook(int id)
        {
            // Copilot: Include Authors with the book to show author information
            return _context.Books.Include(b => b.Authors).ThenInclude(ba => ba.Author)
                .FirstOrDefault(b => b.Id == id);
        }
        public Book? GetBook(string name)
        {
            // Copilot: Include Authors when searching by name
            return _context.Books.Include(b => b.Authors).ThenInclude(ba => ba.Author)
                .FirstOrDefault(b => b.Title == name);
        }
        public bool BookExists(int id)
        {
            return _context.Books.Any(b => b.Id == id);
        }

        // Copilot: Add method to create and save new books to database
        public bool CreateBook(Book book)
        {
            _context.Books.Add(book);
            return Save();
        }

        // Copilot: Add helper method to save changes to database
        private bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}