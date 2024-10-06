using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using SalesWebMVC.Services.Exceptions;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly BancoContext _bancoContext;
        public SellerService(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _bancoContext.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _bancoContext.Add(obj);
            await _bancoContext.SaveChangesAsync();
        }

        public async Task<Seller >FindByIdAsync(int id)
        {
            return await _bancoContext.Seller.Include(x => x.Department).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _bancoContext.Seller.FindAsync(id);
                _bancoContext.Seller.Remove(obj);
                await _bancoContext.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }

        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await  _bancoContext.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _bancoContext.Update(obj);
                await _bancoContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }
    }
}
