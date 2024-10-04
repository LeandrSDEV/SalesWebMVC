using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Department>> FindAllAsync()
        {
            return await _bancoContext.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
