using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.Entities;
using WestWindSystem.DAL;

namespace WestwindSystem.BLL
{
    public class CategoryServices
    {
        // Step 1: Define a readonly data field for the custom DbContext class

        private readonly WestWindContext _dbContext;

        // Step 2: Setup constructor for dependency injection for the custom DbContext type
        internal CategoryServices(WestWindContext context)
        {
            _dbContext = context;
        }

        // Step 3: Define methods to query and save instances of the entity
        public List<Category> List()
        {
            var query = _dbContext
                .Categories
                .OrderBy(item => item.CategoryName);
            return query.ToList();
        }

        public Dictionary<int, string> DictionaryOfSelectItem()
        {
            var query = _dbContext
                .Categories
                .OrderBy(item => item.CategoryName)
                .Select(item => new { item.ID, item.CategoryName });
            return query.ToDictionary(item => item.ID, item => item.CategoryName);
        }

        public Category? GetById(int categoryId)
        {
            var query = _dbContext
                .Categories
                .Where(item => item.ID == categoryId);
            return query.FirstOrDefault();
        }

        public Category? FindByName(string categoryName)
        {
            var query = _dbContext
                .Categories
                .Where(item => item.CategoryName == categoryName);
            return query.FirstOrDefault();
        }
    }
}