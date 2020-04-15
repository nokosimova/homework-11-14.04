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

            Insert(con,"Mirov","Muhammad","Maqsudovich","2000-12-12 05:45:48");

            SelectAll(con);

            //SELECT BY ID realization:
            string  commandText = $"Select * from Person where Person.id = {8}";
            SqlCommand command = new SqlCommand(commandText, con);
            var reader = command.ExecuteReader();
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
        
 /*-----------------INSERT - FUNCTION----------------- */
        static void Insert(SqlConnection con, string firstname, string lastname, string middlename, string datetime)
        {
            string insertSqlCommand = string.Format($"insert into Person([FirstName],[LastName],[MiddleName],[BirthDate]) Values('{firstname}', '{lastname}','{middlename}','{datetime}')");
            SqlCommand command = new SqlCommand(insertSqlCommand, con);
            var result = command.ExecuteNonQuery();
        } 
/*------------------SELECT ALL - FUNCTION------------- */
        static void SelectAll(SqlConnection con)
        {
            string commandText = "Select * from Person";
            SqlCommand command = new SqlCommand(commandText, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                System.Console.WriteLine($"id :{reader.GetValue("id")} | {reader.GetValue("FirstName")} | {reader.GetValue("LastName")} | {reader.GetValue("MiddleName")} | {reader.GetValue("BirthDate")}");
            }
            reader.Close();
        }
/*-----------------SELECT by ID - FUNCTION----------------- */
        static void SelectById(SqlConnection con, int id)
        {
            string  commandText = $"Select * from Person where Person.id = {id}";
            SqlCommand command = new SqlCommand(commandText, con);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                System.Console.WriteLine($"id :{reader.GetValue("id")} | {reader.GetValue("FirstName")} | {reader.GetValue("LastName")} | {reader.GetValue("MiddleName")} | {reader.GetValue("BirthDate")}");
            }
            reader.Close();
        }
/*-----------------UPDATE - FUNCTION----------------- */
        static void Update(SqlConnection con, int id, string firstname, string lastname, string middlename, string datetime)
        {
            string commandText = $"Update Person set FirstName = '{firstname}', LastName = '{lastname}',MiddleName = '{middlename}', BirthDate = '{datetime}' where Person.id = {id}";
            SqlCommand command = new SqlCommand(commandText, con);
            var  reader = command.ExecuteReader();
            reader.Close();
        }    
/*-----------------DELETE by ID - FUNCTION----------------- */
        static void DeleteById(SqlConnection con, int id)
        {
            string commandText = $"Delete from Person where Person.id = {id}";
            SqlCommand command = new SqlCommand(commandText, con);
            var reader = command.ExecuteReader();
            reader.Close();

        }
    }
}
