using System;
using BookApi.Models;
namespace BookApi.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category? GetCategory (int id);
        Category? GetCategory (string name);
        bool CategoryExists (int id);
    }
}