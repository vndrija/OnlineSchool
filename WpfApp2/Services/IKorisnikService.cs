using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.Services
{
    interface IKorisnikService
    {
        List<RegistrovaniKorisnik> GetAll();
        List<RegistrovaniKorisnik> GetActiveUsers();
        List<RegistrovaniKorisnik> GetByUserType(string type);
        void Add(RegistrovaniKorisnik registrovaniKorisnik);
        void AddRegistered(RegistrovaniKorisnik registrovaniKorisnik);
        void Update(int ud, RegistrovaniKorisnik registrovaniKorisnik);
        void Delete(int id);
    }
}

