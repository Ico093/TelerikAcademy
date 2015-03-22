using System;
using System.Data;
using System.Data.SqlClient;
using ADO.NET;

class Task8
{
    static void Main()
    {
        SqlConnection dbCon = new SqlConnection(Settings.Default.DBConnectionString);
        dbCon.Open();
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();
        name = name.Replace("'", "!'");
        name = name.Replace("%", "!%");
        name = name.Replace("_", "!_");
        name = name.Replace("\\", "!\\");

        Console.WriteLine("----------------\n\n");
        using (dbCon)
        {
            SqlCommand cmdSelectProject = new SqlCommand("SELECT ProductName FROM PRODUCTS WHERE ProductName LIKE @name ESCAPE '!'", dbCon);
            cmdSelectProject.Parameters.AddWithValue("@name", "%" + name + "%");
            SqlDataReader reader = cmdSelectProject.ExecuteReader();
           
            while (reader.Read())
            {
                Console.WriteLine("Name of Product: {0}\n----------------", (string)reader["ProductName"]);
            }
        }
        dbCon.Close();
    }
}
