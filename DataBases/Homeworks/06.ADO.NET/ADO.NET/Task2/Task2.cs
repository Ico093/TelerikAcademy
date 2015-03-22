using System;
using System.Data.SqlClient;
using ADO.NET;

class Task2
{
    static void Main()
    {
        SqlConnection dbCon = new SqlConnection(Settings.Default.DBConnectionString);
        dbCon.Open();
        using (dbCon)
        {
            SqlCommand command = new SqlCommand("SELECT CategoryName, Description FROM CATEGORIES", dbCon);
            SqlDataReader data = command.ExecuteReader();
            while(data.Read())
            {
                Console.WriteLine("Name: {0}\nDescription: {1}\n---------------",(string)data["CategoryName"],(string)data["Description"]);
            }
        }
        dbCon.Close();
    }
}
