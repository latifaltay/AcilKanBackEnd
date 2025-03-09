using AcilKan.Application.Interfaces;
using AcilKan.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Linq.Expressions;
using System.Security.Claims;

namespace AcilKan.Persistence.Repositories
{
    public class Repository<T>(AcilKanContext _context, IHttpContextAccessor _httpContextAccessor) : IRepository<T> where T : class
    {
        public async Task CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<List<T>> GetAllByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).ToListAsync();
        }
        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            //return await _context.Set<T>().FindAsync(id);
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => EF.Property<int>(x, "Id") == id);

        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public Task<int> GetCurrentUserIdAsync()
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
            int.TryParse(userIdClaim.Value, out int userId);
            return Task.FromResult(userId);
        }
    }
}
