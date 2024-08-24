using Attendance_System.Models;
using Attendance_System.ViewModels;

namespace Attendance_System.Interfaces
{
    public interface IUser
    {
        bool Login(string Name, string Password);
        void RegisterStudent(RegisterModel model);
        void RegisterHR(RegisterModel model);
        User GetById(int id);
        User GetByName(string Name);
    }
}
