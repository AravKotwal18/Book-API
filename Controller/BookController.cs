using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using BookApi.Models;
using BookApi.Interfaces;
using BookApi.Repository;
using BookApi.Dto;
namespace BookApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
        {
            private readonly IBookRepository _bookRepository;
            private readonly IAuthorRepository _authorRepository;

            public BookController(IBookRepository bookRepository, IAuthorRepository authorRepository)
            {
                _bookRepository = bookRepository;
                _authorRepository = authorRepository;
            }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        public IActionResult GetBooks()
        {
            var books = _bookRepository.GetBooks();
            if (!ModelState.IsValid)
            return BadRequest(ModelState);
            return Ok(books);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Book))]
        [ProducesResponseType(404)]
        public IActionResult GetBook(int id)
        {
           if (!_bookRepository.BookExists(id))
                return NotFound();

            var book = _bookRepository.GetBook(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(book);
        }

        // Copilot: Add POST endpoint to create new books from HTML
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult CreateBook([FromBody] dynamic bookData)
        {
            if (bookData == null || string.IsNullOrWhiteSpace(bookData.title?.ToString()) || 
                string.IsNullOrWhiteSpace(bookData.publishedDate?.ToString()))
                return BadRequest("Title and publishedDate are required");

            var newBook = new Book
            {
                Title = bookData.title.ToString(),
                PublishedDate = DateTime.Parse(bookData.publishedDate.ToString())
            };

            // Copilot: Handle author creation/linking if author is provided
            string authorName = bookData.author?.ToString();
            if (!string.IsNullOrWhiteSpace(authorName))
            {
                var nameParts = authorName.Split(' ', 2);
                string firstName = nameParts[0];
                string secondName = nameParts.Length > 1 ? nameParts[1] : "";

                var author = _authorRepository.GetAuthorByName(firstName, secondName);
                
                if (author == null)
                {
                    author = new Author
                    {
                        FirstName = firstName,
                        SecondName = secondName,
                        Country = "Unknown"
                    };
                    _authorRepository.CreateAuthor(author);
                }

                newBook.Authors = new List<BookAuthor>
                {
                    new BookAuthor { Author = author }
                };
            }

            _bookRepository.CreateBook(newBook);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return CreatedAtAction(nameof(GetBook), new { id = newBook.Id }, newBook);
        }
    }
}