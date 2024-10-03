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
    }
}
