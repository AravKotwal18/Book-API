using BookApi.Data;
using BookApi.Interfaces;
using BookApi.Models;
namespace BookApi.Repository
{    
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        public ReviewRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }
        public Review? GetReview(int id)
        {
            return _context.Reviews.FirstOrDefault(r => r.Id == id);
        }
        public Review? GetReview(string name)
        {
            return _context.Reviews.FirstOrDefault(r => r.Title == name);
        }
        public bool ReviewExists(int id)
        {
            return _context.Reviews.Any(r => r.Id == id);
        }
    }
}