using System;
using BookApi.Models;
namespace BookApi.Interfaces
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();
        Book? GetBook (int id);
        Book? GetBook (string name);
        bool BookExists (int id);
        // Copilot: Add method to create new books
        bool CreateBook(Book book);
    }
}