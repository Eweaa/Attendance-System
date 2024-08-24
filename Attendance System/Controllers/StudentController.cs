using Attendance_System.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_System.Controllers
{
    [Authorize(Roles = "Admin, HR")]
    public class StudentController : Controller
    {
        private readonly IStudent student;
        public StudentController(IStudent _student)
        {
            student = _student;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ImportExcel(IFormFile ExcelFile)
        {
            //Console.WriteLine(ExcelFile.FileName);
            student.ReadExcel($"wwwroot/Excel/{ExcelFile.FileName}");
            return RedirectToAction("VerifiedStudents");
            //return View(ExcelFile);
        }

        public IActionResult VerifiedStudents()
        {
            var res = student.GetVerifiedStudents();
            return View(res);
        }

        public IActionResult UnVerifiedStudents()
        {
            var res = student.GetUnVerifiedStudents();
            return View(res);
        }

        public IActionResult Details(int id)
        {
            var res = student.GetById(id);
            return View(res);
        }

        public IActionResult VerifyStudentForm(int id)
        {
            var res = student.GetById(id);
            return View(res);
        }

        //[HttpPost]
        public IActionResult VerifyStudent(int id)
        {
            student.VerifyStudent(id);
            return RedirectToAction("VerifiedStudents");
        }
    }
}
