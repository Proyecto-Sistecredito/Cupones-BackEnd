using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cupones.Models;

namespace Cupones.Services
{
    public interface IEmpresasService
    {
        IEnumerable<Empresa> GetAll();

        Empresa GetById(int id);
        void add(Empresa empresa);
        void remove(int id);
        void update(Empresa empresa);
        IEnumerable<Empresa> Search(string consulta);
        
    }
}