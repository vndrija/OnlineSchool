using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    
    public class Skola : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }


        public object Clone()
        {
            return new Skola
            {
                Id = Id,
                Name = Name,
                Street = Street,
                StreetNumber = StreetNumber,
                City = City,
                Country = Country,
                IsDeleted = IsDeleted,
            };

        }
        public override string ToString()
        {
            return Name;
        }

    }
}
