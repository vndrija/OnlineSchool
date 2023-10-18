using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.Repos
{
    interface IJezikRepo
    {
        List<Jezik> GetAll();
        Jezik GetById(int id);
        int Add(Jezik jezik);
        void Update(int id, Jezik jezik);
        void Delete(int id);    
    }
}
