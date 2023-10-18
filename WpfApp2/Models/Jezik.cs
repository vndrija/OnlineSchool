using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    public class Jezik : ICloneable
    {
        public int Id { get; set; } 

        public string LanguageName { get; set; }   

        public bool IsDeleted { get; set; }   

        public bool isValid { get; set; }

        public object Clone()
        {
            return new Jezik()
            {
                Id = Id,
                LanguageName = LanguageName,
                IsDeleted = IsDeleted,
                isValid = isValid,

            };
        }
    }
}
