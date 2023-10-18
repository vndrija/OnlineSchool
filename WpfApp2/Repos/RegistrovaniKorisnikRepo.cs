using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.Repos
{
    class RegistrovaniKorisnikRepo : IRegistrovaniKorisnikRepo
    {
        SkolaRepo skolaRepo = new SkolaRepo();

        public int Add(RegistrovaniKorisnik registrovaniKorisnik)
        {
            using (SqlConnection connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"insert into Korisnici(email,password, firstName, lastName, jmbg, GenderId, UserType, Street, StreetNumber, City, Country, SchoolId,IsDeleted)
                output inserted.userId
                values (@email, @password, @firstName, @lastName, @jmbg, @GenderId, @UserType, @Street, @StreetNumber, @City, @Country, @SchoolId, @IsDeleted)";

                command.Parameters.Add(new SqlParameter("email", registrovaniKorisnik.Email));
                command.Parameters.Add(new SqlParameter("password", registrovaniKorisnik.Password));
                command.Parameters.Add(new SqlParameter("firstName", registrovaniKorisnik.FirstName));
                command.Parameters.Add(new SqlParameter("lastName", registrovaniKorisnik.FirstName));
                command.Parameters.Add(new SqlParameter("jmbg", registrovaniKorisnik.JMBG));
                command.Parameters.Add(new SqlParameter("GenderId", registrovaniKorisnik.Pol.ToString()));
                command.Parameters.Add(new SqlParameter("UserType", registrovaniKorisnik.TipKorisnika.ToString()));
                command.Parameters.Add(new SqlParameter("Street", registrovaniKorisnik.Street));
                command.Parameters.Add(new SqlParameter("StreetNumber", registrovaniKorisnik.StreetNumber));
                command.Parameters.Add(new SqlParameter("City", registrovaniKorisnik.City));
                command.Parameters.Add(new SqlParameter("Country", registrovaniKorisnik.Country));
                command.Parameters.Add(new SqlParameter("SchoolId", (object)registrovaniKorisnik.SchoolId ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("IsDeleted", registrovaniKorisnik.IsDeleted));

                return (int)command.ExecuteScalar();





            }
        }
        public void Update(int id, RegistrovaniKorisnik registrovaniKorisnik)
        {
            using (SqlConnection connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "update Korisnici set email=@email, password=@password, firstName=@firstName, lastName=@lastName, jmbg=@jmbg, GenderId=@GenderId,UserType=@UserType,Street=@Street,StreetNumber=@StreetNumber,City=@City,Country = @Country, SchoolId = @SchoolId where userId =@userId";


                command.Parameters.Add(new SqlParameter("email", registrovaniKorisnik.Email));
                command.Parameters.Add(new SqlParameter("password", registrovaniKorisnik.Password));
                command.Parameters.Add(new SqlParameter("firstName", registrovaniKorisnik.FirstName));
                command.Parameters.Add(new SqlParameter("lastName", registrovaniKorisnik.LastName));
                command.Parameters.Add(new SqlParameter("jmbg", registrovaniKorisnik.JMBG));
                command.Parameters.Add(new SqlParameter("GenderId", registrovaniKorisnik.Pol.ToString()));
                command.Parameters.Add(new SqlParameter("UserType", registrovaniKorisnik.TipKorisnika.ToString()));
                command.Parameters.Add(new SqlParameter("Street", registrovaniKorisnik.Street));
                command.Parameters.Add(new SqlParameter("StreetNumber", registrovaniKorisnik.StreetNumber));
                command.Parameters.Add(new SqlParameter("City", registrovaniKorisnik.City));
                command.Parameters.Add(new SqlParameter("Country", registrovaniKorisnik.Country));
                command.Parameters.Add(new SqlParameter("SchoolId", (object)registrovaniKorisnik.SchoolId ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("userId", id));

                command.ExecuteNonQuery();

            }
        }
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "update Korisnici set IsDeleted = 1 where userId=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.ExecuteNonQuery();
            }
        }
        public List<RegistrovaniKorisnik> GetAll()
        {
            List<RegistrovaniKorisnik> registrovaniKorisnici = new List<RegistrovaniKorisnik>();
            using (SqlConnection connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "select * from Korisnici";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, connection);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Korisnici");
                foreach (DataRow row in ds.Tables["Korisnici"].Rows)
                {
                    var registrovaniKorisnik = new RegistrovaniKorisnik
                    {
                        Id = (int)row["userId"],
                        Email = (string)row["email"],
                        Password = (string)row["password"],
                        FirstName = (string)row["firstName"],
                        LastName = (string)row["lastName"],
                        JMBG = (string)row["jmbg"],
                        Pol = (EPol)Enum.Parse(typeof(EPol), (string)row["GenderId"]),
                        TipKorisnika = (ETipKorisnika)Enum.Parse(typeof(ETipKorisnika), (string)row["UserType"]),
                        Street = (string)row["Street"],
                        StreetNumber = (string)row["StreetNumber"],
                        City = (string)row["City"],
                        Country = (string)row["Country"],
                        SchoolId = (Convert.IsDBNull(row["SchoolId"]) ? null : (int?)row["schoolId"]),
                        IsDeleted = (bool)row["IsDeleted"]

                    };
                    if (registrovaniKorisnik.TipKorisnika == ETipKorisnika.PROFESOR)
                    {
                        registrovaniKorisnik.Skola = skolaRepo.GetById((int)registrovaniKorisnik.SchoolId);
                    }

                    registrovaniKorisnici.Add(registrovaniKorisnik);
                }
            }
            return registrovaniKorisnici;
        }
        public RegistrovaniKorisnik GetById(int? id)
        {
            using (SqlConnection connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from Korisnici where userId = {id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, connection);

                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "Korisnici");
                if (ds.Tables["Korisnici"].Rows.Count > 0)
                {
                    var row = ds.Tables["Korisnici"].Rows[0];

                    var registrovaniKorisnik = new RegistrovaniKorisnik
                    {
                        Id = (int)row["userId"],
                        Email = (string)row["email"],
                        Password = (string)row["password"],
                        FirstName = (string)row["firstName"],
                        LastName = (string)row["lastName"],
                        JMBG = (string)row["jmbg"],
                        Pol = (EPol)Enum.Parse(typeof(EPol), (string)row["GenderId"]),
                        TipKorisnika = (ETipKorisnika)Enum.Parse(typeof(ETipKorisnika), (string)row["UserType"]),
                        Street = (string)row["Street"],
                        StreetNumber = (string)row["StreetNumber"],
                        City = (string)row["City"],
                        Country = (string)row["Country"],
                        SchoolId = (Convert.IsDBNull(row["SchoolId"]) ? null : (int?)row["SchoolId"]),
                        IsDeleted = (bool)row["IsDeleted"]
                    };
                    if (registrovaniKorisnik.TipKorisnika == ETipKorisnika.PROFESOR)
                    {
                        registrovaniKorisnik.Skola = skolaRepo.GetById((int)registrovaniKorisnik.SchoolId);

                    }
                    return registrovaniKorisnik;
                }
            }

            return null;
        }

        public List<RegistrovaniKorisnik> GetByUserType(string type)
        {
            List<RegistrovaniKorisnik> registrovaniKorisnici = new List<RegistrovaniKorisnik>();

            using (SqlConnection connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from Korisnici where UserType = {type} and isDeleted= 0";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, connection);

                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "Korisnici");
                if (ds.Tables["Korisnici"].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables["Korisnici"].Rows)
                    {
                        var registrovaniKorisnik = new RegistrovaniKorisnik
                        {
                            Id = (int)row["userId"],
                            Email = (string)row["email"],
                            Password = (string)row["password"],
                            FirstName = (string)row["firstName"],
                            LastName = (string)row["lastName"],
                            JMBG = (string)row["jmbg"],
                            Pol = (EPol)Enum.Parse(typeof(EPol), (string)row["GenderId"]),
                            TipKorisnika = (ETipKorisnika)Enum.Parse(typeof(ETipKorisnika), (string)row["UserType"]),
                            Street = (string)row["Street"],
                            StreetNumber = (string)row["StreetNumber"],
                            City = (string)row["City"],
                            Country = (string)row["Country"],
                            SchoolId = (Convert.IsDBNull(row["SchoolId"]) ? null : (int?)row["SchoolId"]),
                            IsDeleted = (bool)row["isDeleted"]
                        };
                        int? korisnik1 = registrovaniKorisnik.SchoolId;
                        if (registrovaniKorisnik.TipKorisnika == ETipKorisnika.PROFESOR)
                        {
                            

                            //if (korisnik1 == null)
                            //{
                                registrovaniKorisnik.Skola = skolaRepo.GetById(korisnik1);
                           //}
                            ////else
                            //{
                            //    korisnik1 = korisnik1;
                            //}
                        }
                        registrovaniKorisnici.Add(registrovaniKorisnik);
                    }
                }
                return registrovaniKorisnici;
            }
        }

        public int AddRegistered(RegistrovaniKorisnik registrovaniKorisnik)
        {
            using (SqlConnection connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"insert into Korisnici(email, passwordd, firstName, lastName, jmbg, GenderId, UserType, Street, StreetNumber, City, Country, IsDeleted)
                output inserted.userId               
                values (@email, @passwordd, @firstName, @lastName, @jmbg, @GenderId, @UserType, @Street, @StreetNumber, @City, @Country, @IsDeleted)";

                command.Parameters.Add(new SqlParameter("email", registrovaniKorisnik.Email));
                command.Parameters.Add(new SqlParameter("password", registrovaniKorisnik.Password));
                command.Parameters.Add(new SqlParameter("firstName", registrovaniKorisnik.FirstName));
                command.Parameters.Add(new SqlParameter("lastName", registrovaniKorisnik.LastName));
                command.Parameters.Add(new SqlParameter("jmbg", registrovaniKorisnik.JMBG));
                command.Parameters.Add(new SqlParameter("GenderId", registrovaniKorisnik.Pol.ToString()));
                command.Parameters.Add(new SqlParameter("UserType", registrovaniKorisnik.TipKorisnika.ToString()));
                command.Parameters.Add(new SqlParameter("Street", registrovaniKorisnik.Street));
                command.Parameters.Add(new SqlParameter("StreetNumber", registrovaniKorisnik.StreetNumber));
                command.Parameters.Add(new SqlParameter("City", registrovaniKorisnik.City));
                command.Parameters.Add(new SqlParameter("Country", registrovaniKorisnik.Country));
                command.Parameters.Add(new SqlParameter("IsDeleted", registrovaniKorisnik.IsDeleted));

                return (int)command.ExecuteScalar();
            }
        }

        public void AddLanguage(RegistrovaniKorisnik registrovaniKorisnik)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"insert into Usеrs(email, password, firstName, lastName, jmbg, GenderId, UserType, Street, StreetNumber, City, Country, SchoolId, IsDeleted)
                output inserted.userId               
                values (@email, @passwordd, @firstName, @lastName, @jmbg, @GenderId, @UserType, @Street, @StreetNumber, @City, @Country, @SchoolId, @IsDeleted)";

                command.Parameters.Add(new SqlParameter("email", registrovaniKorisnik.Email));
                command.Parameters.Add(new SqlParameter("password", registrovaniKorisnik.Password));
                command.Parameters.Add(new SqlParameter("firstName", registrovaniKorisnik.FirstName));
                command.Parameters.Add(new SqlParameter("lastName", registrovaniKorisnik.LastName));
                command.Parameters.Add(new SqlParameter("jmbg", registrovaniKorisnik.JMBG));
                command.Parameters.Add(new SqlParameter("GenderId", registrovaniKorisnik.Pol.ToString()));
                command.Parameters.Add(new SqlParameter("UserType", registrovaniKorisnik.TipKorisnika.ToString()));
                command.Parameters.Add(new SqlParameter("Street", registrovaniKorisnik.Street));
                command.Parameters.Add(new SqlParameter("StreetNumber", registrovaniKorisnik.StreetNumber));
                command.Parameters.Add(new SqlParameter("City", registrovaniKorisnik.City));
                command.Parameters.Add(new SqlParameter("Country", registrovaniKorisnik.Country));
                command.Parameters.Add(new SqlParameter("SchoolId", (object)registrovaniKorisnik.SchoolId ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("IsDeleted", registrovaniKorisnik.IsDeleted));

                command.ExecuteScalar();

                if (registrovaniKorisnik.TipKorisnika == ETipKorisnika.PROFESOR)
                {
                    foreach (Jezik jezici in registrovaniKorisnik.jezici)
                    {
                        SqlCommand command1 = conn.CreateCommand();
                        command1.CommandText = @"insert into UserLanguage(UserId, LanguageId) values(@UserId, @LanguageId)";

                        command1.Parameters.Add("UserId", registrovaniKorisnik.Id);
                        command1.Parameters.Add("LanguageId", registrovaniKorisnik.Id);

                        command1.ExecuteScalar();
                    }
                }
            }
        }
        public void UpdateLanguages(int id, RegistrovaniKorisnik registrovaniKorisnik)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = "update Usеrs set email = @email, passwordd = @passwordd, firstName = @firstName, lastName = @lastName, jmbg = @jmbg, GenderId = @GenderId, UserType = @UserType, Street = @Street, StreetNumber = @StreetNumber, City = @City, Country = @Country, SchoolId = @SchoolId where userId = @userId";

                command.Parameters.Add(new SqlParameter("email", registrovaniKorisnik.Email));
                command.Parameters.Add(new SqlParameter("password", registrovaniKorisnik.Password));
                command.Parameters.Add(new SqlParameter("firstName", registrovaniKorisnik.FirstName));
                command.Parameters.Add(new SqlParameter("lastName", registrovaniKorisnik.LastName));
                command.Parameters.Add(new SqlParameter("jmbg", registrovaniKorisnik.JMBG));
                command.Parameters.Add(new SqlParameter("GenderId", registrovaniKorisnik.Pol));
                command.Parameters.Add(new SqlParameter("UserType", registrovaniKorisnik.TipKorisnika.ToString()));
                command.Parameters.Add(new SqlParameter("Street", registrovaniKorisnik.Street));
                command.Parameters.Add(new SqlParameter("StreetNumber", registrovaniKorisnik.StreetNumber));
                command.Parameters.Add(new SqlParameter("City", registrovaniKorisnik.City));
                command.Parameters.Add(new SqlParameter("Country", registrovaniKorisnik.Country));
                command.Parameters.Add(new SqlParameter("SchoolId", (object)registrovaniKorisnik.SchoolId ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("userId", id));

                command.ExecuteNonQuery();

                SqlCommand command1 = conn.CreateCommand();
                command1.CommandText = $"delete from UserLanguage where UserId = {id}";

                command1.ExecuteScalar();

                if (registrovaniKorisnik.TipKorisnika == ETipKorisnika.PROFESOR)
                {
                    foreach (Jezik jezik in registrovaniKorisnik.jezici)
                    {
                        SqlCommand command2 = conn.CreateCommand();
                        command2.CommandText = @"insert into UserLanguage(UserId, LanguageId) values(@UserId, @LanguageId)";
                        command2.Parameters.Add(new SqlParameter("UserId", registrovaniKorisnik.Id));
                        command2.Parameters.Add(new SqlParameter("LanguageId", registrovaniKorisnik.Id));

                        command2.ExecuteScalar();
                    }
                }
            }
        }
    }
}
