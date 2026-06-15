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
    public class CategoryController : ControllerBase
        {
            private readonly ICategoryRepository _categoryRepository;

            public CategoryController(ICategoryRepository categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _categoryRepository.GetCategories();
            if (!ModelState.IsValid)
            return BadRequest(ModelState);
            return Ok(categories);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(404)]
        public IActionResult GetCategory(int id)
        {
           if (!_categoryRepository.CategoryExists(id))
                return NotFound();

            var category = _categoryRepository.GetCategory(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }
    }
}