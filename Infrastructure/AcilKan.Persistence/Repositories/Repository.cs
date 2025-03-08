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
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
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

        //public Task<int> GetCurrentUserIdAsync()
        //{
        //    // Kullanıcı kimliği claim'ini al
        //    //var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
        //    //var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");


        //    var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub);
        //    //var userIdClaim = _httpContextAccessor.HttpContext?.User?();


        //    // Eğer claim yoksa veya null ise, 0 dönebilirsiniz veya exception fırlatabilirsiniz
        //    if (userIdClaim == null)
        //    {
        //        // Global error handling ile zaten hatayı yönettiğiniz için burada exception fırlatmaya gerek yok
        //        return Task.FromResult(0); // Veya bir default değer dönebilirsiniz
        //    }

        //    // Claim değerini integer'a dönüştür
        //    int.TryParse(userIdClaim.Value, out int userId);

        //    // Başarıyla dönüştürülmemişse, yine default değer dönebilir
        //    return Task.FromResult(userId);
        //}

        //public Task<int> GetCurrentUserIdAsync()
        //{
        //    // HTTPContext ve User nesnelerini kontrol et
        //    var context = _httpContextAccessor.HttpContext;
        //    if (context == null)
        //    {
        //        // HttpContext null ise, burada hata alıyorsunuz demektir
        //        // Burada loglama yapabilir veya hata mesajı dönebilirsiniz
        //        Console.WriteLine("HttpContext null");
        //        return Task.FromResult(0);
        //    }

        //    //var user = context.User;
        //    var user = context.User as ClaimsPrincipal;
        //    string username = user.Claims.Where(c => c.Type == "sub")
        //        .Select(x => x.Value).FirstOrDefault();
        //    if (user == null)
        //    {
        //        // User null ise, kullanıcının kimliği (authentication) mevcut değil demektir
        //        Console.WriteLine("User null");
        //        return Task.FromResult(0);
        //    }

        //    // Claim listesinin boş olup olmadığını kontrol et
        //    var userIdClaim = user.FindFirst(JwtRegisteredClaimNames.Sub);
        //    //var userIdClaim = user.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
        //    if (userIdClaim == null)
        //    {
        //        // userIdClaim null ise, "sub" claim'i bulunamadı demektir
        //        Console.WriteLine("userIdClaim null");
        //        return Task.FromResult(0);
        //    }

        //    // Claim değerini integer'a dönüştürme işlemi
        //    int userId = 0;
        //    bool isParsed = int.TryParse(userIdClaim.Value, out userId);
        //    if (!isParsed)
        //    {
        //        // Eğer dönüşüm başarısız olursa, hata mesajı yazdırabilirsiniz
        //        Console.WriteLine("Claim değeri integer'a dönüştürülemedi");
        //        return Task.FromResult(0);
        //    }

        //    // Başarıyla işlenen kullanıcı ID'si döndürülüyor
        //    return Task.FromResult(userId);
        //}



    }
}
