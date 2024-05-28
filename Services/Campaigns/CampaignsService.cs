using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cupones.Data;
using Cupones.Models;

namespace Cupones.Services
{
    public class CampaignsService : ICampaignsService
    {
        private readonly CuponesContext _context;

        public CampaignsService(CuponesContext context)
        {
            _context = context;
        }

        public void add(Campaña campaña)
        {
            _context.Add(campaña);
            _context.SaveChanges();
        }

        public IEnumerable<Campaña> GetAll()
        {
            return _context.Campañas.ToList();
        }

        public Campaña GetById(int id)
        {
            return _context.Campañas.Find(id);
        }

        public void remove(int id)
        {
            var campaña = _context.Campañas.Find(id);
            _context.Campañas.Remove(campaña);
            _context.SaveChanges();
        }

        public void update(Campaña campaña)
        {
            _context.Campañas.Update(campaña);
            _context.SaveChanges();
        }
        public IEnumerable<Campaña> Search(string consulta)
{
   return _context.Campañas
        .Where(e => e.Nombre.Contains(consulta))
        .ToList();
}
    }
}