using System;
using System.Data.SqlClient;
using ADO.NET;

class Task4
{
    static void Main()
    {
        SqlConnection dbCon = new SqlConnection(Settings.Default.DBConnectionString);
        dbCon.Open();
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();
        using (dbCon)
        {
            SqlCommand cmdSelectProject = new SqlCommand("INSERT INTO Products (ProductName) VALUES (@name)", dbCon);
            cmdSelectProject.Parameters.AddWithValue("@name", name);
            cmdSelectProject.ExecuteNonQuery();
        }
        dbCon.Close();
    }
}
