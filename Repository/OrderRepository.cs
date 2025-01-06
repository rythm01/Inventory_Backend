using WebAppRepo.Models;
using WebAppRepo.UnitofWork;
using Microsoft.EntityFrameworkCore;
using WebAppRepo.Data;

namespace WebAppRepo.Repository
{
    public class OrderRepository : RepositoryBase<Order>
    {
        public OrderRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
