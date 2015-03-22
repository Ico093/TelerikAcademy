using System;
using System.Data.SqlClient;
using ADO.NET;

class Task3
{
    static void Main()
    {
        SqlConnection dbCon = new SqlConnection(Settings.Default.DBConnectionString);
        dbCon.Open();
        using (dbCon)
        {
            SqlCommand command = new SqlCommand("SELECT p.ProductName, c.CategoryName "+
                                                "FROM CATEGORIES c LEFT JOIN PRODUCTS p ON c.CategoryID=p.CategoryID "+
                                                "ORDER BY c.CategoryName", dbCon);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                Console.WriteLine("Name of Product: {0}\nName of Category: {1}\n---------------", (string)data["ProductName"], 
                                                                                                 (string)data["CategoryName"]);
            }
        }
        dbCon.Close();
    }
}
