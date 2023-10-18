using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.Repos
{
    interface ISkolaRepo
    {
        List<Skola> GetAll();
        Skola GetById(int? id); 
        int Add(Skola skola);
        void Update(int id, Skola skola);
        void Delete(int id);
    }
}
