using BookApi.Data;
using BookApi.Interfaces;
using BookApi.Models;
namespace BookApi.Repository
{    
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
        public Category? GetCategory(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }
        public Category? GetCategory(string name)
        {
            return _context.Categories.FirstOrDefault(c => c.Name == name);
        }
        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }
    }
}