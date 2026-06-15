using BookApi.Data;
using BookApi.Interfaces;
using BookApi.Models;

namespace BookApi.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Author> GetAuthors()
        {
            return _context.Authors.ToList();
        }

        public Author? GetAuthor(int id)
        {
            return _context.Authors.FirstOrDefault(a => a.Id == id);
        }

        public Author? GetAuthor(string name)
        {
            return _context.Authors.FirstOrDefault(a => a.FirstName == name);
        }

        public bool AuthorExists(int id)
        {
            return _context.Authors.Any(a => a.Id == id);
        }

        // Copilot: Find author by first and second name
        public Author? GetAuthorByName(string firstName, string secondName)
        {
            return _context.Authors.FirstOrDefault(a => 
                a.FirstName == firstName && a.SecondName == secondName);
        }

        // Copilot: Create and save new author to database
        public bool CreateAuthor(Author author)
        {
            _context.Authors.Add(author);
            return Save();
        }

        // Copilot: Helper method to save changes to database
        private bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}