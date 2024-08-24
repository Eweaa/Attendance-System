using Attendance_System.Models;

namespace Attendance_System.Interfaces
{
    public interface IDepartment
    {
        public List<Department> GetAll();
        public Department GetById(int id);
        public void Add(Department department);
        public void Update(int id, Department department);
        public void Delete(int id);
    }
}
