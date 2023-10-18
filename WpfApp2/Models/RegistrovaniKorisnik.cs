using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    [Serializable]
    public class RegistrovaniKorisnik : IDataErrorInfo, ICloneable
    {
        public int Id { get; set; } 
        public string Email { get; set; }   
        public string Password { get; set; }    
        public string FirstName { get; set; }   
        public string LastName { get; set; }    
        public string JMBG { get; set; }    
        public EPol Pol { get; set; }   
        public ETipKorisnika TipKorisnika { get; set; } 
        public string Street { get; set; }  
        public string StreetNumber { get; set; }    
        public string City { get; set; }    
        public string Country { get; set; }

        private Skola skola;

        public bool IsDeleted { get; set; } 
        
        public bool IsValid{ get; set; }    

        public int? SchoolId { get; set; }
        
        public List<Jezik> jezici { get; set; }

        public Skola Skola
        {
            get => skola;
            set
            {
                skola = value;
                SchoolId = skola?.Id;
            }
        }

        public RegistrovaniKorisnik()
        {
            IsDeleted = false;  
            jezici = new List<Jezik>();
        }

        public override string ToString()
        {
            return FirstName;
        }

        public object Clone()
        {
            return new RegistrovaniKorisnik
            {
                Id = Id,
                Email = Email,
                Password = Password,
                FirstName = FirstName,
                LastName = LastName,
                JMBG = JMBG,
                TipKorisnika = TipKorisnika,
                Pol = Pol,
                IsDeleted = IsDeleted,
                Skola = Skola?.Clone() as Skola,
                Street = Street,
                StreetNumber = StreetNumber,
                City = City,
                Country = Country,


            };
        }
        public string Error
        {
            get
            {
                if (string.IsNullOrEmpty(Email))
                {
                    return "email ne moze biti prazan";
                }
                else if (string.IsNullOrEmpty(Password))
                {
                    return "sifra ne moze biti prazna";
                }
                else if (string.IsNullOrEmpty(FirstName))
                {
                    return "ime ne moze biti prazno";
                }
                else if (string.IsNullOrEmpty(LastName))
                {
                    return "prezime ne moze biti prazno";
                }
                else if (string.IsNullOrEmpty(JMBG))
                {
                    return "jmbg ne moze biti prazan";
                }

                return "";
            }
        }
        public string this[string columnName]
        {
            get
            {
                IsValid = true;
                if (columnName == "Email" && string.IsNullOrEmpty(Email))
                {
                    IsValid = false;
                    return "email ne moze biti prazan";
                }
                if (columnName == "Password" && string.IsNullOrEmpty(Password))
                {
                    IsValid = false;
                    return "sifra ne moze biti prazna";
                }
                if (columnName == "FirstName" && string.IsNullOrEmpty(FirstName))
                {
                    IsValid = false;
                    return "ime ne moze biti prazno";
                }
                if (columnName == "LastName" && string.IsNullOrEmpty(LastName))
                {
                    IsValid = false;
                    return "prezime ne moze biti prazno";
                }
                if (columnName == "JMBG" && string.IsNullOrEmpty(JMBG))
                {
                    IsValid = false;
                    return "prezime ne moze biti prazno";
                }
                return "";
            }
        }





    }
}

