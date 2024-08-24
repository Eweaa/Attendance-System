namespace Attendance_System.Models
{
    public class Program
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<Intake>? Intakes { get; set; } = [];
    }
}
