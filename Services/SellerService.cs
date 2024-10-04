using SalesWebMVC.Data;
using SalesWebMVC.Models;

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
            return _bancoContext.Seller.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _bancoContext.Seller.Find(id);
            _bancoContext.Seller.Remove(obj);
            _bancoContext.SaveChanges();

        }
    }
}
