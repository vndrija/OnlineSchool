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
    public class JezikRepo : IJezikRepo
    {
        public int Add(Jezik jezik)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"insert into Jezici(languageName, isDeleted)
                output inserted.languageId               
                values (@languageName, @isDeleted)";

                command.Parameters.Add(new SqlParameter("languageName", jezik.LanguageName));
                command.Parameters.Add(new SqlParameter("isDeleted", jezik.IsDeleted));

                return (int)command.ExecuteScalar();
            }
        }
        public void Update(int id, Jezik jezik)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = "update Jezici set languageName = @languageName where languageId = @languageId";

                command.Parameters.Add(new SqlParameter("languageName", jezik.LanguageName));
                command.Parameters.Add(new SqlParameter("languageId", id));

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = "update Jezici set isDeleted = 1 where languageId=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.ExecuteNonQuery();
            }
        }

        public List<Jezik> GetAll()
        {
            List<Jezik> jezici = new List<Jezik>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "select * from Jezici";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Jezici");

                foreach (DataRow row in ds.Tables["Jezici"].Rows)
                {
                    var jezik = new Jezik
                    {
                        Id = (int)row["languageId"],
                        LanguageName = (string)row["languageName"],
                        IsDeleted = (bool)row["isDeleted"]
                    };

                    jezici.Add(jezik);
                }
            }
            return jezici;
        }

        public Jezik GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from Jezici where languageId = {id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Jezici");
                if (ds.Tables["Jezici"].Rows.Count > 0)
                {
                    var row = ds.Tables["Jezici"].Rows[0];

                    var jezik = new Jezik
                    {
                        Id = (int)row["languageId"],
                        LanguageName = (string)row["languageName"],
                        IsDeleted = (bool)row["isDeleted"]
                    };

                    return jezik;
                }
            }

            return null;
        }

  
    }
}