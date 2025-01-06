using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppRepo.Data;
using WebAppRepo.Models;
using WebAppRepo.UnitofWork;

namespace WebAppRepo.Repository
{
    public abstract class RepositoryBase<T> : ControllerBase, IRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;
        protected DbSet<T> dbSet;
        private readonly IUnitOfWork _unitOfWork;

        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            dbSet = _unitOfWork.Context.Set<T>();
        }

        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            var data = await dbSet.ToListAsync();
            return Ok(data);
        }

        public async Task<ActionResult<T>> Create(T entity)
        {
            dbSet.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<IActionResult> Update(int id, T entity)
        {
            //if (id != entity.Id)
            //{
            //    return BadRequest();
            //}

            var existingOrder = await dbSet.FindAsync(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            _unitOfWork.Context.Entry(existingOrder).CurrentValues.SetValues(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }

            return NoContent();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await dbSet.FindAsync(id);
            if (data == null)
            {
                return NotFound(id);
            }

            dbSet.Remove(data);

            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
