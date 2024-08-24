namespace Attendance_System.Models
{
    public class Attendance
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public bool Attended { get; set; }
    }
}
