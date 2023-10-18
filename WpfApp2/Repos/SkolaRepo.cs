using WpfApp2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WpfApp2.Repos
{
    public class SkolaRepo : ISkolaRepo 
    { 

    public int Add(Skola skola) 
    {
        using (SqlConnection connection = new SqlConnection(Config.CONNECTION_STRING))
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"insert into Skola(schoolName, isDeleted,Street, StreetNumber, City, Country)
            output inserted.schoolId
            values (@schoolName, @isDeleted, @Street, @StreetNumber, @City, @Country)";

            command.Parameters.Add(new SqlParameter("schoolName", skola.Name));
            command.Parameters.Add(new SqlParameter("isDeleted", skola.IsDeleted));
            command.Parameters.Add(new SqlParameter("Street", skola.Street));
            command.Parameters.Add(new SqlParameter("StreetNumber", skola.StreetNumber));
            command.Parameters.Add(new SqlParameter("City", skola.City));
            command.Parameters.Add(new SqlParameter("Country", skola.Country));

            return (int)command.ExecuteScalar();


        }
    }

    public void Update(int id, Skola skola)
    {
        using (SqlConnection connection = new SqlConnection(Config.CONNECTION_STRING))
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "update Skola set schoolName = @schoolName, Street = @Street, StreetNumber = @StreetNumber, City = @City, Country = @Country where schoolId=@SchoolId";
            command.Parameters.Add(new SqlParameter("schoolName", skola.Name));
            command.Parameters.Add(new SqlParameter("Street", skola.Street));
            command.Parameters.Add(new SqlParameter("StreetNumber", skola.StreetNumber));
            command.Parameters.Add(new SqlParameter("City", skola.City));
            command.Parameters.Add(new SqlParameter("Country", skola.Country));
            command.Parameters.Add(new SqlParameter("schoolId", id));


                command.ExecuteScalar();
        }
    }
    public void Delete(int id)
    {
        using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
        {
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = "update Skola set isDeleted = 1 where schoolId=@id";

            command.Parameters.Add(new SqlParameter("id", id));
            command.ExecuteNonQuery();


         
        }
    }

    public List<Skola> GetAll()
    {
        List<Skola> skole = new List<Skola>();

        using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
        {
            string commandText = "select * from Skola";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

            DataSet ds = new DataSet();

            dataAdapter.Fill(ds, "skola");
            foreach (DataRow row in ds.Tables["Skola"].Rows)
            {
                var skola = new Skola
                {
                    Id = (int)row["schoolId"],
                    Name = (string)row["schoolName"],
                    IsDeleted = (bool)row["IsDeleted"],
                    Street = (string)row["Street"],
                    StreetNumber = (string)row["StreetNumber"],
                    City = (string)row["City"],
                    Country = (string)row["Country"],

                };

                skole.Add(skola);
            }
        }
        return skole;
    }
    public Skola GetById(int? id)
    {
        using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
        {
            string commandText = $"select * from Skola where schoolId={id}";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

            DataSet ds = new DataSet();

            dataAdapter.Fill(ds, "Skola");
            if (ds.Tables["Skola"].Rows.Count>0)
            {
                var row = ds.Tables["Skola"].Rows[0];

                var skola = new Skola
                {
                    Id = (int)row["schoolId"],
                    Name = (string)row["schoolName"],
                    IsDeleted = (bool)row["IsDeleted"],
                    Street = (string)row["Street"],
                    StreetNumber = (string)row["StreetNumber"],
                    City = (string)row["City"],
                    Country = (string)row["Country"],
                };
                return skola;
            }
        }
        return null;
    }
}
}
