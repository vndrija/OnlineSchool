using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using WpfApp2.Services;

namespace WpfApp2.Models
{
    public class Data
    {
        private static Data instance;
        
        public RegistrovaniKorisnik UlogovanKorisnik { get; set; }

        static Data() { }

        private Data()
        {
            UlogovanKorisnik = new RegistrovaniKorisnik();
        }

        public static Data Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Data();  
                }
                return instance;
            }

            private set => instance = value;
        }
    }
}
