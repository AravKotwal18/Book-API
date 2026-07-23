using BookApi.Data;
using BookApi.Interfaces;
using BookApi.Models;
using Microsoft.EntityFrameworkCore;namespace BookApi.Repository
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
            return _context.Books.Include(b => b.Authors).ThenInclude(ba => ba.Author).ToList();
        }
        public Book? GetBook(int id)
        {
            return _context.Books.Include(b => b.Authors).ThenInclude(ba => ba.Author)
                .FirstOrDefault(b => b.Id == id);
        }
        public Book? GetBook(string name)
        {
            return _context.Books.Include(b => b.Authors).ThenInclude(ba => ba.Author)
                .FirstOrDefault(b => b.Title == name);
        }
        public bool BookExists(int id)
        {
            return _context.Books.Any(b => b.Id == id);
        }
        public bool CreateBook(Book book)
        {
            _context.Books.Add(book);
            return Save();
        }
        private bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
        public bool UpdateBook(Book book)
        {
        _context.Books.Update(book);
            return Save();
        }
        public bool DeleteBook (Book book)
        {
            _context.Books.Remove(book);
            return Save();
        }
    }
}
