using Microsoft.AspNetCore.Mvc;
using BookApi.Models;
using BookApi.Interfaces;
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

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult CreateBook([FromBody] CreateBookDto bookData)
        {
            if (bookData == null || string.IsNullOrWhiteSpace(bookData.Title))
                return BadRequest("Title is required");

            var newBook = new Book
            {
                Title = bookData.Title,
                PublishedDate = bookData.PublishedDate
            };

            if (!string.IsNullOrWhiteSpace(bookData.Author))
            {
                var nameParts = bookData.Author.Split(' ', 2);
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
            return CreatedAtAction(nameof(GetBook), new { id = newBook.Id }, newBook);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookDto bookData)
        {
            if (bookData == null || string.IsNullOrWhiteSpace(bookData.Title))
                return BadRequest("Title is required");

            if (!_bookRepository.BookExists(id))
                return NotFound();

            var book = _bookRepository.GetBook(id);
            if (book == null) return NotFound();
            book.Title = bookData.Title;
            book.PublishedDate = bookData.PublishedDate;

            _bookRepository.UpdateBook(book);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteBook(int id)
        {
            if (!_bookRepository.BookExists(id))
                return NotFound();

            var book = _bookRepository.GetBook(id);
            if (book == null) return NotFound();
            _bookRepository.DeleteBook(book);
            return NoContent();

        }
    }
}