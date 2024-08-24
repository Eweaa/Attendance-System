namespace Attendance_System.Models
{
    public class Intake
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<Department>? Departments { get; set; } = [];
    }
}
