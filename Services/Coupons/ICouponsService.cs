using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cupones.Models;

namespace Cupones.Services
{
    public interface ICouponsService
    {
        IEnumerable<Cupon> GetAll();

        Cupon GetById(int id);

        void add(Cupon cupon);

        void remove(int id);

        void update(Cupon cupon);
        IEnumerable<Cupon> Search(string consulta);

    }
}