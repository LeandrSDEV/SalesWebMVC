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

        public List<Seller> FindAll()
        {
            return _bancoContext.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _bancoContext.Add(obj);
            _bancoContext.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _bancoContext.Seller.Include(x => x.Department).FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _bancoContext.Seller.Find(id);
            _bancoContext.Seller.Remove(obj);
            _bancoContext.SaveChanges();

        }

        public void Update(Seller obj)
        {
            if (!_bancoContext.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _bancoContext.Update(obj);
                _bancoContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }
    }
}
