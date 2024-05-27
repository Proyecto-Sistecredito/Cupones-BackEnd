using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cupones.Models;

namespace Cupones.Services
{
    public interface ICampañasService
    {
        IEnumerable<Campaña> GetAll();

        Campaña GetById(int id);

        void add(Campaña campaña);

        void remove(int id);

        void update(Campaña campaña);
        IEnumerable<Campaña> Search(string consulta);
    }
}