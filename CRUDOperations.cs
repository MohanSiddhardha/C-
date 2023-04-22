// CRUD methods for MySQL and SQLite

using System;
using MySql.Data.MySqlClient;


public class cCRUD
{
	public void AddStudent()
	{
		try
		{
	        Console.WriteLine("Enter student pin: ");
	        Pin = Console.ReadLine();
	        Console.WriteLine("Enter student name: ");
	        Name = Console.ReadLine();
	        Console.WriteLine("Enter student branch: ");
	        Branch = Console.ReadLine();
	        InsertQuery = "INSERT INTO Student(" + Pin + ", '" + Name + "', '" + Branch + "');"
	        MySqlCommand command = new MySqlCommand(InsertQuery, connection);
	        command.ExecuteNonQuery();
		}
		catch(SqlException e)
		{
			Console.WriteLine(e);
		}
	}
}