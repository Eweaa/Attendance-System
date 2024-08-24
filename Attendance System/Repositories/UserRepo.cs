using Attendance_System.Context;
using Attendance_System.Interfaces;
using Attendance_System.Models;
using Attendance_System.ViewModels;
//using Microsoft.CodeAnalysis.Elfie.Extensions;
using System.Security.Cryptography;
using System.Text;

namespace Attendance_System.Repositories
{
    public class UserRepo : IUser
    {
        private readonly ITIContext db;
        public UserRepo(ITIContext _db)
        {
            db = _db;
        }

        public bool Login(string Name, string Password)
        {
            User DbUser = db.Users.SingleOrDefault(u => u.Name == Name);
            //string ClientPassword = Password.ToSHA256String();
            string ClientPassword = HashPassword(Password);

            if (DbUser == null)
            {
                return false;
            }

            return (DbUser.Password == ClientPassword) ? true : false;

        }

        public void RegisterStudent(RegisterModel model)
        {
            User user = new User();

            user.Name = model.UserName;
            user.Email = model.Email;
            //user.Password = model.Password.ToSHA256String();
            user.Password = HashPassword(model.Password);
            user.Role = "Student";
            user.DepartmentID = model.DepartmentID;
            user.Verified = false;

            db.Users.Add(user);
            db.SaveChanges();
        }

        public void RegisterHR(RegisterModel model)
        {
            User user = new User();

            user.Name = model.UserName;
            user.Email = model.Email;
            //user.Password = model.Password.ToSHA256String();
            user.Password = HashPassword(model.Password);
            user.Role = "HR";
            user.DepartmentID = model.DepartmentID;
            user.Verified = true;

            db.Users.Add(user);
            db.SaveChanges();
        }

        public User GetById(int id)
        {
            return db.Users.SingleOrDefault(u => u.ID == id);
        }

        public User GetByName(string Name)
        {
            return db.Users.SingleOrDefault(U => U.Name == Name);
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
    }
}
