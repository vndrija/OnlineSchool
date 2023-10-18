using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;
using WpfApp2.MyExceptions;
using WpfApp2.Repos;

namespace WpfApp2.Services
{
    internal class CasoviService : ICasoviService
    {
        private ICasRepo casRepo;

        public CasoviService()
        {
            casRepo = new CasRepo();
        }
        public void Add(Casovi casovi)
        {
            casRepo.Add(casovi);
        }

        public void Delete(int id)
        {
            casRepo.Delete(id);
        }

        public List<Casovi> GetAll()
        {
            return casRepo.GetAll();
        }
        public Casovi GetById(int id)
        {
            return casRepo.GetById(id);
        }

        public void Set(List<Casovi> casovi)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Casovi casovi)
        {
            casRepo.Update(id, casovi);
        }

        public void Update2(int id, Casovi casovi)
        {
            casRepo.Update2(id, casovi);
        }
    }
}