using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;
using WpfApp2.MyExceptions;
using WpfApp2.Repos;

namespace WpfApp2.Services
{
    class KorisnikService : IKorisnikService
    {
        private RegistrovaniKorisnikRepo registrovaniKorisnikRepo;

        public KorisnikService()
        {
            registrovaniKorisnikRepo = new RegistrovaniKorisnikRepo();
        }

        public List<RegistrovaniKorisnik> GetByUserType(string type)
        {
            return registrovaniKorisnikRepo.GetByUserType(type);
        }
        public List<RegistrovaniKorisnik> GetActiveUsers()
        {
            return registrovaniKorisnikRepo.GetAll().Where(p => p.IsDeleted == false).ToList();
        }

        public List<RegistrovaniKorisnik> GetAll()
        {
            return registrovaniKorisnikRepo.GetAll();
        }

        public void Add(RegistrovaniKorisnik registrovaniKorisnik)
        {
            registrovaniKorisnikRepo.Add(registrovaniKorisnik);
        }

        public void AddRegistered(RegistrovaniKorisnik registrovaniKorisnik)
        {
            registrovaniKorisnikRepo.AddRegistered(registrovaniKorisnik);
        }

        public void Update(int id, RegistrovaniKorisnik registrovaniKorisnik)
        {
            registrovaniKorisnikRepo.Update(id, registrovaniKorisnik);
        }

        public void Delete(int id)
        {
            registrovaniKorisnikRepo.Delete(id);
        }
    }
}
