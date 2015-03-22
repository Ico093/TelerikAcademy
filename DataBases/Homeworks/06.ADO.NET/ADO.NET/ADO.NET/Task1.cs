using System;
using System.Data.SqlClient;
using ADO.NET;

class Task1
{
    static void Main()
    {
        SqlConnection dbCon = new SqlConnection(Settings.Default.DBConnectionString);
        dbCon.Open();
        using (dbCon)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM CATEGORIES", dbCon);
            int numberOfRows = (int)command.ExecuteScalar();
            Console.WriteLine("Number of rows: {0}", numberOfRows);
        }
        dbCon.Close();
    }
}
