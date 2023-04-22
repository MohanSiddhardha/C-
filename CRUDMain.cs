// Main class for CRUD
// csc /out:CRUDMethods.exe /r:College.dll,MySql.Data.dll CRUDMain.cs CRUDMethods.cs

using System;
using MySql.Data.MySqlClient;

class CRUD
{
    public static void Main(string[] args)
    {
        try
        {
            string choice = "";
            cMySQLConnection oCRUD  = new cMySQLConnection();
            // var oCRUD = (iCRUD)Activator.CreateInstance(Type.GetType(className));
            while (true)
            {
                Console.Write("....Menu....\n1. Add student\n2. Show all students\n3. Update student name\n4. Search a student record\n5. Delete a student record\n6. Exit\nEnter your choice: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        oCRUD.AddStudent();
                        break;
                    case "2":
                        oCRUD.ShowAllStudents();
                        break;
                    case "3":
                        oCRUD.UpdateStudentName();
                        break;
                    case "4":
                        // oCRUD.SearchStudent();
                        break;
                    case "5":
                        // oCRUD.DeleteStudentRecord();
                        break;
                    case "6":
                        oCRUD.CloseConnection();
                        return;
                    default:
                        Console.Write("Entered invalid choice.");
                        break;
                }
            }
        }
        catch (Exception e)
        {
            Console.Write(e);
        }
    }
}
