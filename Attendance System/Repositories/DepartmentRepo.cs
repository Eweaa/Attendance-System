using Attendance_System.Context;
using Attendance_System.Interfaces;
using Attendance_System.Models;

namespace Attendance_System.Repositories
{
    public class DepartmentRepo : IDepartment
    {
        private readonly ITIContext db;
        public DepartmentRepo(ITIContext _db)
        {
            db = _db;
        }

        public void Add(Department department)
        {
            db.Add(department);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var dept = GetById(id);
            db.Departments.Remove(dept);
            db.SaveChanges();
        }

        public List<Department> GetAll()
        {
            var res = db.Departments.ToList();
            return res;
        }

        public Department GetById(int id)
        {
            var res = db.Departments.SingleOrDefault(d => d.ID == id);
            return res;
        }

        public void Update(int id, Department department)
        {
            Department dept = GetById(id);
            dept.Name = department.Name;
            db.SaveChanges();
        }
    }
}
