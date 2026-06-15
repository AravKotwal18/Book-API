using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using BookApi.Models;
using BookApi.Interfaces;
using BookApi.Repository;
namespace BookApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
        {
            private readonly IAuthorRepository _authorRepository;

            public AuthorController(IAuthorRepository authorRepository)
            {
                _authorRepository = authorRepository;
            }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Author>))]
        public IActionResult GetAuthors()
        {
            var authors = _authorRepository.GetAuthors();
            if (!ModelState.IsValid)
            return BadRequest(ModelState);
            return Ok(authors);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Author))]
        [ProducesResponseType(404)]
        public IActionResult GetAuthor(int id)
        {
           if (!_authorRepository.AuthorExists(id))
                return NotFound();

            var author = _authorRepository.GetAuthor(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(author);
}
    }
}