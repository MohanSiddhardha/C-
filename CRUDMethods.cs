// MySQL class to connnect to the MySQL database

using System;
using MySql.Data.MySqlClient;
using College;
using System.Data;

public class cMySQLConnection: iCRUD
{
    public MySqlConnection Connection;
    public cMySQLConnection()
    {
        try
        {
            string ConnectionString = "Server = 138.68.140.83; Database = dbMohan; Uid = Mohan; Pwd = Mohan@123;";
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }
        catch (Exception e)
        {
            System.Console.Write(e);
        }
    }

    public void AddStudent()
    {
        try
        {
            System.Console.Write("Enter student pin: ");
            int Pin = System.Convert.ToInt32(System.Console.ReadLine());
            System.Console.Write("Enter student name: ");
            string Name = System.Console.ReadLine();
            System.Console.Write("Enter student branch: ");
            string Branch = System.Console.ReadLine();
            string InsertQuery = "INSERT INTO Student(Pin, Name, Branch) VALUES('" + Pin + "', '" + Name + "', '" + Branch + "')";
            MySqlCommand Command = new MySqlCommand(InsertQuery, Connection);
            Command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            System.Console.Write(e);
        }
    }

    // public void ShowAllStudents()
    // {
    //     try
    //     {
    //         string SelectQuery = "SELECT * FROM Student;";
    //         MySqlCommand Command = new MySqlCommand(SelectQuery, Connection);
    //         Console.WriteLine("Pin\tName\t\tBranch");
    //         using (MySqlDataReader Reader = Command.ExecuteReader())
    //         {
    //             while ( Reader.Read())
    //             {
    //                 Console.WriteLine(Reader["Pin"] + "\t" + Reader["Name"] + "\t\t" + Reader["Branch"]);   
    //             }
    //             Reader.Close();
    //         }
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e);
    //     }
    // }

    public void ShowAllStudents()
    {
        try
        {
            string SelectQuery = "SELECT * FROM Student;";
            MySqlCommand Command = new MySqlCommand(SelectQuery, Connection);
            MySqlDataAdapter Adapter = new MySqlDataAdapter(Command);
            DataTable Table = new DataTable();
            Adapter.Fill(Table);
            Console.WriteLine("Pin\tName\t\tBranch");
            foreach (DataRow CurrentRecord in Table.Rows)
            {
                Console.WriteLine("{0}\t{1}\t\t{2}", CurrentRecord["Pin"], CurrentRecord["Name"], CurrentRecord["Branch"]);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void UpdateStudentName()
    {
        try
        {
            Console.Write("Enter student pin: ");
            int GivenPin = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter new name: ");
            string NewName = Console.ReadLine();
            string UpdateQuery = "UPDATE Student SET Name = '" + NewName + "' WHERE Pin = " + GivenPin + ";";
            MySqlCommand Command = new MySqlCommand(UpdateQuery, Connection);
            Command.ExecuteNonQuery();
            Console.WriteLine("Update successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void CloseConnection()
    {
        Connection.Close();
    }
}
