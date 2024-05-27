using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cupones.Data;
using Cupones.Models;

namespace Cupones.Services
{
    public class CuponesService : ICuponesService
    {
        private readonly CuponesContext _context;

        public CuponesService(CuponesContext context)
        {
            _context = context;
        }

        public void add(Cupon cupon)
        {
            _context.Add(cupon);
            _context.SaveChanges();
        }

        public IEnumerable<Cupon> GetAll()
        {
            return _context.Cupones.ToList();
        }

        public Cupon GetById(int id)
        {
            return _context.Cupones.Find(id);
        }

        public void remove(int id)
        {
            var cupon = _context.Cupones.Find(id);
            _context.Cupones.Remove(cupon);
            _context.SaveChanges();
        }

        public void update(Cupon cupon)
        {
            _context.Cupones.Update(cupon);
            _context.SaveChanges();
        }
         public IEnumerable<Cupon> Search(string consulta)
{
   return _context.Cupones
        .Where(e => e.Nombre.Contains(consulta)|| e.Codigo.Contains(consulta))
        .ToList();
}
    }
}