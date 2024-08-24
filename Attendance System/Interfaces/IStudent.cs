using Attendance_System.Models;

namespace Attendance_System.Interfaces
{
    public interface IStudent
    {
        List<User> GetVerifiedStudents();
        List<User> GetUnVerifiedStudents();
        User GetById(int id);
        void VerifyStudent(int id);
        void ReadExcel(string path);
    }
}
