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
    public class ReviewController : ControllerBase
        {
            private readonly IReviewRepository _reviewRepository;

            public ReviewController(IReviewRepository reviewRepository)
            {
                _reviewRepository = reviewRepository;
            }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public IActionResult GetReviews()
        {
            var reviews = _reviewRepository.GetReviews();
            if (!ModelState.IsValid)
            return BadRequest(ModelState);
            return Ok(reviews);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(404)]
        public IActionResult GetReview(int id)
        {
           if (!_reviewRepository.ReviewExists(id))
                return NotFound();

            var review = _reviewRepository.GetReview(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(review);
}
    }
}