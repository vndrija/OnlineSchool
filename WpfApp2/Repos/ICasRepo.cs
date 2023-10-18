using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.Repos
{
    interface ICasRepo
    {
        List<Casovi> GetAll();
        Casovi GetById(int id);
        int Add (Casovi casovi);    
        void Update (int id, Casovi casovi);
        void Update2(int id, Casovi casovi);
        void Delete (int id);
        List<Casovi> Search(string sting);

    }
}
