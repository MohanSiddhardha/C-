// Interface for student

namespace College
{
    public interface iCRUD
    {
        void AddStudent();
        void ShowAllStudents();
        void UpdateStudentName();
        // void DeleteStudentRecord();
        // void SearchStudent();
        void CloseConnection();
    }
}