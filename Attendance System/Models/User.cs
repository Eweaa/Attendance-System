namespace Attendance_System.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string? ImgPath { get; set; }
        public bool Verified { get; set; }
        public int? IntakeID { get; set; }
        public virtual Intake? Intake { get; set; }
        public int? DepartmentID { get; set; }
        public virtual Department? Department { get; set; }
    }
}
