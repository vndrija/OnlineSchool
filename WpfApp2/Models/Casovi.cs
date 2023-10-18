using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    public class Casovi : ICloneable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfClass { get; set; }

        public string ClassTime { get; set; }

        public EStatus Status { get; set; }

        private RegistrovaniKorisnik professor { get; set; }

        private RegistrovaniKorisnik student { get; set; }

        public bool IsDeleted { get; set; }

        public int? ProfessorId { get; set; }

        public int? StudentId { get; set; }

        public RegistrovaniKorisnik Professor
        {
            get => professor;
            set
            {
                professor = value;
                ProfessorId = professor?.Id;
            }
        }

        public RegistrovaniKorisnik Student
        {
            get => student;
            set
            {
                student = value;
                StudentId = student?.Id;
            }
        }

        public Casovi()
        {
            IsDeleted = true;
        }
        public object Clone()
        {
            return new Casovi
            {
                Id = Id,
                Name = Name,
                DateOfClass = DateOfClass,
                ClassTime = ClassTime,
                Status = Status,
                Professor = Professor?.Clone() as RegistrovaniKorisnik,
                Student = Student?.Clone() as RegistrovaniKorisnik,
                IsDeleted = IsDeleted,
            };
        }
    }
}
