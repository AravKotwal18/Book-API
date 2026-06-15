using System;
using BookApi.Models;
namespace BookApi.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review? GetReview (int id);
        Review? GetReview (string name);
        bool ReviewExists (int id);
    }
}