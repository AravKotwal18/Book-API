using System;
using BookApi.Models;
namespace BookApi.Interfaces
{
    public interface IAuthorRepository
    {
        ICollection<Author> GetAuthors();
        Author? GetAuthor (int id);
        Author? GetAuthor (string name);
        bool AuthorExists (int id);
        // Copilot: Add method to find author by first and second name
        Author? GetAuthorByName(string firstName, string secondName);
        // Copilot: Add method to create new author
        bool CreateAuthor(Author author);
    }
}