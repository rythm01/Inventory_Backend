using WebAppRepo.Models;
using WebAppRepo.UnitofWork;
using Microsoft.EntityFrameworkCore;
using WebAppRepo.Data;

namespace WebAppRepo.Repository
{
    public class CategoryRepository : RepositoryBase<Category>
    {
        public CategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
