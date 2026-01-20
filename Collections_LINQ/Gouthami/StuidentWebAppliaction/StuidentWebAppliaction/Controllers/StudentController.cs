using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentWebAppliaction.Models;
using StudentWebAppliaction.student;

namespace StudentWebAppliaction.Controllers
{
    public class StudentController : Controller
    {
        private  StudentADODB _studentADODB;

        public StudentController(StudentADODB _obj)
        {
            _studentADODB = _obj;

        }

        public ActionResult List()
        {
            var x = _studentADODB.GetAllStudents();
            var y = new List<StudentModel>();
            foreach (var item in x)
            {
                var student = new StudentModel();
                student.StudentId = item.StudentId;
                student.StudentName = item.StudentName;
                student.FatherName = item.FatherName;
                student.Email = item.Email;
                student.MobileNumber = item.MobileNumber;
                student.IsActive = item.IsActive;
                y.Add(student);

            }
            return View(y);
        }
        public ActionResult Add()
        {


            return View();
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
