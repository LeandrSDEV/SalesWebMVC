using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class DepartimentService
    {
        private readonly BancoContext _bancoContext;
        public DepartimentService(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<Department> FindAll()
        {
            return _bancoContext.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
