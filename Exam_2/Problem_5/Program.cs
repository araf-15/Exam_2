using System;
using System.Data.SqlClient;

namespace Problem_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=DESKTOP-V3GHE7O\\MSSQLSERVER2019;Database=Exam_2;User Id=Araf;Password=araf.hasan;";


            //-----------------CRUD Operations Using ADO.NET-------------
            CreateData(connectionString);
            //ReadData(connectionString);
            //UpdateData(connectionString);
            //DeleteData(connectionString);
        }

        public static void CreateData(string connString)
        {
            try
            {
                using var connection = new SqlConnection(connString);
                connection.Open();

                using var sqlCommand = new SqlCommand("INSERT INTO dbo.Employees(Name, Contact, Email, ManagerId) VALUES('Kallol Hasan', '01864352434', 'kallol@gmail.com', '1')", connection);
                sqlCommand.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine("Problem Occurs"+e.Message);
            }
        }

        public static void ReadData(string ConnString)
        {
            try
            {
                using var connection = new SqlConnection(ConnString);
                connection.Open();

                using var sqlCommand = new SqlCommand("SELECT * FROM dbo.Employees", connection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("Name: "+reader["Name"]);
                    Console.WriteLine("Contact: "+reader["Contact"]);
                    Console.WriteLine("Email: "+reader["Email"]);
                    Console.WriteLine();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Problem Occurs"+e.Message);
            }
        }

        public static void UpdateData(string connString)
        {
            try
            {
                using var connection = new SqlConnection(connString);
                connection.Open();

                using var sqlCommand = new SqlCommand("UPDATE dbo.Employees SET Name = 'Helal' WHERE Id = 2", connection);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem Occurs" + e.Message);
            }
        }
        public static void DeleteData(string connString)
        {
            try
            {
                using var connection = new SqlConnection(connString);
                connection.Open();

                using var sqlCommand = new SqlCommand("DELETE FROM dbo.Employees WHERE Id = 5", connection);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem Occurs" + e.Message);
            }
            
        }
    }
}
