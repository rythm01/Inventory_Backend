using WebAppRepo.Models;
using WebAppRepo.UnitofWork;
using Microsoft.EntityFrameworkCore;
using WebAppRepo.Data;

namespace WebAppRepo.Repository
{
    public class ProductRepository : RepositoryBase<Product>
    {
        public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
