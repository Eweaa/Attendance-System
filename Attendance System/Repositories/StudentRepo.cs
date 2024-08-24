using Attendance_System.Context;
using Attendance_System.Interfaces;
using Attendance_System.Models;
using OfficeOpenXml;
using System.Security.Cryptography;
using System.Text;


namespace Attendance_System.Repositories
{
    public class StudentRepo : IStudent
    {
        private readonly ITIContext db;
        public StudentRepo(ITIContext _db)
        {
            db = _db;
        }

        public User GetById(int id)
        {
            var res = db.Users.SingleOrDefault(s => s.ID == id);
            return res;
        }

        public List<User> GetUnVerifiedStudents()
        {
            var res = db.Users.Where(u => u.Role == "Student" && u.Verified == false).ToList();
            return res;
        }

        public List<User> GetVerifiedStudents()
        {
            var res = db.Users.Where(u => u.Role == "Student" && u.Verified == true).ToList();
            return res;
        }


        public void VerifyStudent(int id)
        {
            var user = db.Users.SingleOrDefault(u => u.ID == id);
            user.Verified = true;
            db.SaveChanges();
        }

        public void ReadExcel(string path)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var students = new List<User>();

            using(var package = new ExcelPackage(new FileInfo(path)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                for (int row = 2; row < worksheet.Dimension.End.Row + 1; row++)
                {
                    var student = new User
                    {
                        Name = worksheet.Cells[row, 1].Text,
                        Email = worksheet.Cells[row, 2].Text,
                        Password = HashPassword(worksheet.Cells[row, 3].Text),
                        Role = "Student",
                        Verified = true
                    };

                    students.Add(student);
                }
            }

            db.Users.AddRange(students);
            db.SaveChanges();
        }


        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convert the input string to a byte array
                byte[] bytes = Encoding.UTF8.GetBytes(password);

                // Compute the hash
                byte[] hashBytes = sha256.ComputeHash(bytes);

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public int AttendanceReport(int id, DateOnly start, DateOnly End)
        {
            var res = db.Attendances.Where(a => a.UserID == 2 && a.Attended == false);

            List<DateOnly> FinalRes = new List<DateOnly>();

            foreach (var a in res) 
            {
                if(a.Date > start && a.Date < End)
                {
                    FinalRes.Add(a.Date);
                }
            }

            return FinalRes.Count;


            //List<DateOnly> dates = new List<DateOnly>();
            //DateOnly CurrentDate = start;

            //while (CurrentDate <= End)
            //{
            //    dates.Add(CurrentDate);
            //    CurrentDate = CurrentDate.AddDays(1);
            //}

            //foreach (DateOnly date in dates)
            //{
            //    Console.WriteLine(date.ToString());
            //}
        }
    }
}
