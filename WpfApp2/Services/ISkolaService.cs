using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.Services
{
    interface ISkolaService
    {
        List<Skola> GetAll();
        Skola GetById(int id);
        List<Skola> GetActiveSchools();
        void Add(Skola skola);
        void Update(int id, Skola skola);
        void Delete(int id);
    }
}