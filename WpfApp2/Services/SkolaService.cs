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
    public class SkolaService : ISkolaService
    {

        private ISkolaRepo skolaRepo;

        public SkolaService()
        {
            skolaRepo = new SkolaRepo();
        }


        public void Add(Skola skola)
        {
            skolaRepo.Add(skola);
        }

        public void Delete(int id)
        {
            skolaRepo.Delete(id);
        }

        public List<Skola> GetActiveSchools()
        {
            return skolaRepo.GetAll().Where(p => p.IsDeleted == false).ToList();
        }

        public List<Skola> GetAll()
        {
            return skolaRepo.GetAll();
        }

        public Skola GetById(int id)
        {
            return skolaRepo.GetById(id);
        }

        public void Update(int id, Skola skola)
        {
            skolaRepo.Update(id, skola);
        }
    }
}