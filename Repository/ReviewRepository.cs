using WebAppRepo.Models;
using WebAppRepo.UnitofWork;
using Microsoft.EntityFrameworkCore;
using WebAppRepo.Data;

namespace WebAppRepo.Repository
{
    public class ReviewRepository : RepositoryBase<Review>
    {
        public ReviewRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
