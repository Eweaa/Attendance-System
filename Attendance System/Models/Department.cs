namespace Attendance_System.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<Intake>? Intakes { get; set; } = [];
        public virtual List<User>? Students { get; set; } = [];
    }
}
