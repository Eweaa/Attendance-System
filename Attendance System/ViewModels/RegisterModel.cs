using System.ComponentModel.DataAnnotations;

namespace Attendance_System.ViewModels
{
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public string Email { get; set; }
        public string? ImgPath { get; set; }
        public int? DepartmentID { get; set; }
    }
}
