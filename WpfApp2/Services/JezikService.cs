using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;
using WpfApp2.Repos;

namespace WpfApp2.Services
{
    public class JezikService : IJezikService
    {
        private IJezikRepo jezikRepo;

        public JezikService()
        {
            jezikRepo = new JezikRepo();
        }

        public void Add(Jezik jezik)
        {
            jezikRepo.Add(jezik);
        }

        public void Delete(int id)
        {
            jezikRepo?.Delete(id);
        }

        public List<Jezik> GetActiveSchools()
        {
            return jezikRepo.GetAll().Where(p => p.IsDeleted == false).ToList();
        }

        public List<Jezik> GetAll()
        {
            return jezikRepo.GetAll();
        }

        public Jezik GetById(int id)
        {
            return jezikRepo.GetById(id);
        }

        public void Update(int id, Jezik jezik)
        {
            jezikRepo.Update(id, jezik);
        }
    }
}