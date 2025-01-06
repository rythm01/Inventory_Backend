using Microsoft.AspNetCore.Mvc;
using WebAppRepo.Models;
using WebAppRepo.Repository;
using WebAppRepo.UnitofWork;

namespace WebAppRepo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        IRepository<Category> categoryRepo;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            categoryRepo = new CategoryRepository(_unitOfWork);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await categoryRepo.Get();
            return categories;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            var categories = await categoryRepo.Create(category);
            return categories;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var categories = await categoryRepo.Delete(id);
            return categories;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id,Category category)
        {
            var categories = await categoryRepo.Update(id, category);
            return categories;
        }
    }
}
