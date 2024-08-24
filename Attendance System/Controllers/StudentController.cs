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

        public IActionResult AttendanceReportForm()
        {
            var res = student.GetById(2);
            //DateOnly Start = new(2024, 08, 01);
            //DateOnly End = new(2024, 08, 24);
            //int Days = student.AttendanceReport(1, Start, End);
            //return Content($"This student was absent for {Days} Days");
            return View(res);
        }

        //[HttpPost]
        public IActionResult AttendanceReport(int Id, DateOnly Start, DateOnly End)
        {
            //DateOnly Start = new(2024, 08, 01);
            //DateOnly End = new(2024, 08, 24);
            var std = student.GetById(Id);
            var days = student.AttendanceReport(2, Start, End);
            ViewBag.Days = days;
            return View(std);
        }
    }
}
