using System;
using System.Data;
using System.Data.SqlClient;

namespace PersonTableSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            const string conString  = @"Data source=KosimovaNodira; Initial catalog = Alif_Academy; Integrated Security=True"; 
            SqlConnection con = new SqlConnection(conString);

            con.Open();//open connection 

            //INSERT realization:
            string insertSqlCommand = string.Format($"insert into Person([FirstName],[LastName],[BirthDate]) Values('{"Testov"}', '{"Test"}','{"2020-04-15 00:00:00"}')");
            SqlCommand command = new SqlCommand(insertSqlCommand, con);
            var result = command.ExecuteNonQuery();

            //SELECT ALL realization:
            string commandText = "Select * from Person";
            command = new SqlCommand(commandText, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                System.Console.WriteLine($"id :{reader.GetValue("id")} | {reader.GetValue("FirstName")} | {reader.GetValue("LastName")} | {reader.GetValue("MiddleName")} | {reader.GetValue("BirthDate")}");
            }
            reader.Close();

            //SELECT BY ID realization:
            commandText = $"Select * from Person where Person.id = {8}";
            command = new SqlCommand(commandText, con);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                System.Console.WriteLine($"id :{reader.GetValue("id")} | {reader.GetValue("FirstName")} | {reader.GetValue("LastName")} | {reader.GetValue("MiddleName")} | {reader.GetValue("BirthDate")}");
            }
            reader.Close();

            //UPDATE realization:
            commandText = $"Update Person set FirstName = 'Tomiris', MiddleName = 'Shukurova' where Person.id = {8}";
            command = new SqlCommand(commandText, con);
            reader = command.ExecuteReader();
            reader.Close();

            //DELETE by id realization:
            commandText = $"Delete from Person where Person.id = {9}";
            command = new SqlCommand(commandText, con);
            reader = command.ExecuteReader();
            reader.Close();
        }
    }
}
