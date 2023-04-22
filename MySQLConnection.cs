// MySQL class to connnect to the MySQL database

using System;
using MySql.Data.MySqlClient;

class cMySQLConnection: cCRUD implements iCRUD
{
    cMySQLConnection()
    {
        try
        {
	        string connectionString = "Server = 138.68.140.83; Database = dbMohan; Uid = Mohan; Pwd = Mohan@123;";
	        MySqlConnection connection = new MySqlConnection(connectionString);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: {0}", ex.ToString());
        }
    }
}