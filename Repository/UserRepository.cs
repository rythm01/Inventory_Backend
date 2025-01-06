using Microsoft.EntityFrameworkCore;
using WebAppRepo.Data;
using WebAppRepo.Models;
using WebAppRepo.UnitofWork;

namespace WebAppRepo.Repository
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
