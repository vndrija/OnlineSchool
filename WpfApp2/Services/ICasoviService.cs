using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.Services
{
    interface ICasoviService
    {
        List<Casovi> GetAll();
        Casovi GetById(int id);
        void Add(Casovi casovi);
        void Set(List<Casovi> casovi);
        void Update(int id, Casovi casovi);
        void Update2(int id, Casovi casovi);
        void Delete(int id);
    }
}