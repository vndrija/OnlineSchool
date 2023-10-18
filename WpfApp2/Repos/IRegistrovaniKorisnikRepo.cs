using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.Repos
{
    interface IRegistrovaniKorisnikRepo
    {
        List<RegistrovaniKorisnik> GetAll();
        RegistrovaniKorisnik GetById(int? id);
        List<RegistrovaniKorisnik> GetByUserType(string type);
        int Add(RegistrovaniKorisnik registrovaniKorisnik);
        void Update(int id, RegistrovaniKorisnik registrovaniKorisnik);
        void Delete(int id);
    }
}
