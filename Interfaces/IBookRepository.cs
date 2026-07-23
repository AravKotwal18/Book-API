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
        bool CreateBook(Book book);
        bool UpdateBook(Book book);
        bool DeleteBook (Book book);
    }
}
