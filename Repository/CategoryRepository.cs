using GameTracker.Class;
using GameTracker.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GameTracker.Repository
{
    class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;

        public CategoryRepository(AppDbContext _context)
        {
            context = _context;
        }

        public Category GetCategoryByID(int _ID)
        {
            return context.categories.AsNoTracking().FirstOrDefault(g => g.Id == _ID);
        }

        public List<Category> GetAll()
        {
            return context.categories.AsNoTracking().ToList();
        }

        public void Add(Category _category)
        {
            if (_category == null)
                throw new Exception("Cant add a NULL category.");
            else
                context.categories.Add(_category);
        }

        public void Add(List<Category> _categories)
        {
            if (_categories == null)
                throw new Exception("Cant add a NULL list of category.");
            else
                context.categories.AddRange(_categories);
        }

        public void Update(int _ID, Category _category)
        {
            Category toUpdate = context.categories.FirstOrDefault(g => g.Id == _ID);

            if (toUpdate == null)
                throw new Exception("No category match the id " + _ID);
            else
            {
                toUpdate = _category;
                context.SaveChanges();
            }
        }

        public void Delete(int _ID)
        {
            Category toDelete = context.categories.FirstOrDefault(g => g.Id == _ID);

            if (toDelete == null)
                throw new Exception("No game match the id " + _ID);
            else
            {
                context.categories.Remove(toDelete);
                context.SaveChanges();
            }
        }
    }
}
