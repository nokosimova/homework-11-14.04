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
            Console.WriteLine("//----------------Добро пожаловать в работу с таблицей Person-------------//");
            Console.WriteLine("Выберите команду: ");
            Console.WriteLine("Добавить ------------ 1");
            Console.WriteLine("Выбрать всё --------- 2");
            Console.WriteLine("Выбрать один по id -- 3");
            Console.WriteLine("Обновить ------------ 4");
            Console.WriteLine("Удалить ------------- 5");
            int command  = int.Parse(Console.ReadLine());
            int id;
            string firstname, lastname, middlename, datetime;
            switch(command)
            {
                case 1:
                    Console.Write("фамилия: ");
                    firstname = Console.ReadLine();
                    Console.Write("имя: ");
                    lastname = Console.ReadLine();
                    Console.Write("отчество: ");
                    middlename = Console.ReadLine();
                    Console.Write("ДР в формате (yy-mm-dd hh:mm:ss) ");
                    datetime = Console.ReadLine();
                    Insert(con, firstname, lastname, middlename, datetime);
                    break;
                case 2:
                    SelectAll(con);
                    break;
                case 3:
                    Console.Write("Выберите id: ");
                    id = int.Parse(Console.ReadLine());
                    SelectById(con, id);
                    break;
                case 4:
                    Console.Write("Выберите id: ");
                    id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Новые данные: ");
                    Console.Write("фамилия: ");
                    firstname = Console.ReadLine();
                    Console.Write("имя: ");
                    lastname = Console.ReadLine();
                    Console.Write("отчество: ");
                    middlename = Console.ReadLine();
                    Console.Write("ДР в формате (yy-mm-dd hh:mm:ss) ");
                    datetime = Console.ReadLine();
                    Update(con, id, firstname, lastname, middlename, datetime);
                    break;
                case 5:
                    Console.Write("Выберите id: ");
                    id = int.Parse(Console.ReadLine());
                    DeleteById(con, id);
                    break;
                default:
                    break;
            }
            Console.WriteLine("----------");
            con.Close();

        }
        
 /*-----------------INSERT - FUNCTION----------------- */
        static void Insert(SqlConnection con, string firstname, string lastname, string middlename, string datetime)
        {
            string insertSqlCommand = string.Format($"insert into Person([FirstName],[LastName],[MiddleName],[BirthDate]) Values('{firstname}', '{lastname}','{middlename}','{datetime}')");
            SqlCommand command = new SqlCommand(insertSqlCommand, con);
            var result = command.ExecuteNonQuery();
            if (result > 0) {
                Console.WriteLine("Данные успешно добавлены!");
            }
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
            var result = command.ExecuteNonQuery();
            if (result > 0) {
                Console.WriteLine("Данные успешно удалены!");
            }

        }
    }
}
