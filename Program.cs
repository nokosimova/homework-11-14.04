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
            
            string commandText = "Select * from Person";
            SqlCommand command = new SqlCommand(commandText,con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ID:{reader.GetValue(0)}, FirstName: {reader.GetValue(1)},LastName: {reader.GetValue(2)}");
            }


        }
    }
}
