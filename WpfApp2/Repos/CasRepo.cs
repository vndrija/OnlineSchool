using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.Repos
{
    class CasRepo : ICasRepo
    {
        RegistrovaniKorisnikRepo registrovaniKorisnik = new RegistrovaniKorisnikRepo();
        public int Add(Casovi casovi)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"insert into Cas(className, dateOfClass, classTime, statusId, isDeleted, professorId, studentId)
                output inserted.classId            
                values (@className, @dateOfClass, @classTime, @statusId, @isDeleted, @professorId, @studentId)";

                command.Parameters.Add(new SqlParameter("className", casovi.Name));
                command.Parameters.Add(new SqlParameter("dateOfClass", casovi.DateOfClass));
                command.Parameters.Add(new SqlParameter("classTime", casovi.ClassTime));
                command.Parameters.Add(new SqlParameter("statusId", casovi.Status.ToString()));
                command.Parameters.Add(new SqlParameter("isDeleted", casovi.IsDeleted));
                command.Parameters.Add(new SqlParameter("professorId", (object)casovi.ProfessorId ?? DBNull.Value)); // vidi
                command.Parameters.Add(new SqlParameter("studentId", (object)casovi.StudentId ?? DBNull.Value)); // vidi

                return (int)command.ExecuteScalar();
            }
        }
        public void Update(int id, Casovi casovi)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();                                                                                                                             /* professorId = @professorId*/
                command.CommandText = "update Cas set className = @className, dateOfClass = @dateOfClass, classTime = @classTime, statusId = @statusId where classId = @classId";

                command.Parameters.Add(new SqlParameter("className", casovi.Name));
                command.Parameters.Add(new SqlParameter("dateOfClass", casovi.DateOfClass));
                command.Parameters.Add(new SqlParameter("classTime", casovi.ClassTime));
                command.Parameters.Add(new SqlParameter("statusId", casovi.Status.ToString()));
                command.Parameters.Add(new SqlParameter("classId", id));

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open(); 

                SqlCommand command = conn.CreateCommand();
                command.CommandText = "update Cas set isDeleted=1 where classId=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.ExecuteNonQuery();
            }
        }
        
        public List<Casovi> GetAll()
        {
            List<Casovi> casovi = new List<Casovi>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "select * from Cas";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Cas");

                foreach (DataRow row in ds.Tables["Cas"].Rows)
                {
                    var cas = new Casovi()
                    {
                        Id = (int)row["classId"],
                        ProfessorId = (int)row["professorId"],
                        Name = (string)row["className"],
                        DateOfClass = DateTime.Parse((string)row["dateOfClass"]),
                        ClassTime = (string)row["classTime"],
                        Status = (EStatus)Enum.Parse(typeof(EStatus), (string)row["statusId"]),
                        StudentId = Convert.IsDBNull(row["studentId"]) ? null : (int?)row["studentId"],
                        IsDeleted = (bool)row["isDeleted"],

                    };

                    cas.Professor = registrovaniKorisnik.GetById(cas.ProfessorId);
                    if (cas.StudentId != null)
                    {
                        cas.Student = registrovaniKorisnik.GetById(cas.StudentId);
                    }

                    casovi.Add(cas);
                }
            }
            return casovi;
        }

        public Casovi GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from Cas where classId = {id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Cas");
                if (ds.Tables["Cas"].Rows.Count > 0)
                {
                    var row = ds.Tables["Cas"].Rows[0];

                    var cas = new Casovi
                    {
                        Id = (int)row["classId"],
                        ProfessorId = (int)row["professorId"],
                        Name = (string)row["className"],
                        DateOfClass = (DateTime)row["dateOfClass"],
                        ClassTime = (string)row["classTime"],
                        Status = (EStatus)Enum.Parse(typeof(EStatus), (string)row["statusId"]),
                        StudentId = Convert.IsDBNull(row["studentId"]) ? null : (int?)row["studentId"],
                        IsDeleted = (bool)row["isDeleted"]
                    };

                    return cas;
                }
            }

            return null;
        }

     

        public void Update2(int id, Casovi casovi)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();                                                                                                                             /* professorId = @professorId*/
                command.CommandText = "update Cas set className = @className, dateOfClass = @dateOfClass, classTime = @classTime, statusId = @statusId, studentId = @studentId where classId = @classId";

                command.Parameters.Add(new SqlParameter("className", casovi.Name));
                command.Parameters.Add(new SqlParameter("dateOfClass", casovi.DateOfClass));
                command.Parameters.Add(new SqlParameter("classTime", casovi.ClassTime));
                command.Parameters.Add(new SqlParameter("statusId", casovi.Status.ToString()));
                command.Parameters.Add(new SqlParameter("studentId", (object)casovi.StudentId ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("classId", id));

                command.ExecuteNonQuery();
            }
        }

        public List<Casovi> Search(string sting)
        {
            throw new NotImplementedException();
        }

    }
}
