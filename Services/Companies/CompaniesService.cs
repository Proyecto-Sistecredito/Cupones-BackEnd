using Cupones.Models;
using Cupones.Data;

namespace Cupones.Services
{
    public class CompaniesService : ICompaniesService
    {
        private readonly CuponesContext _context;

        public CompaniesService(CuponesContext context)
        {
            _context = context;
        }

        public void add(Empresa empresa)
        {
            _context.Add(empresa);
            _context.SaveChanges();
        }

        public IEnumerable<Empresa> GetAll()
        {
            return _context.Empresas.ToList();
        }

        public Empresa GetById(int id)
        {
            return _context.Empresas.Find(id);
        }

        public void remove(int id)
        {
            var empresa = _context.Empresas.Find(id);
            _context.Empresas.Remove(empresa);
            _context.SaveChanges();
        }

        public void update(Empresa empresa)
        {
            _context.Empresas.Update(empresa);
            _context.SaveChanges();
        }

        public IEnumerable<Empresa> Search(string consulta)
        {
            return _context.Empresas
                .Where(e => e.Nombre.Contains(consulta))
                .ToList();
        }
    }
}

