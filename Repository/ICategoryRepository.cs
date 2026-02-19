using GameTracker.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Repository
{
    internal interface ICategoryRepository
    {
        public Category GetCategoryByID(int _ID);
        public List<Category> GetAll();
        public void Add(Category _category);
        public void Update(int _ID, Category _category);
        public void Delete(int _ID);
    }
}
