using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NLog;
using StudentCourseApp.Services;
using StudentCourseApp.Shared.Models;

namespace StudentCourseApp.MVC.Controllers
{
    public class StudentController : Controller
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly IStudentService _studentService;
        private readonly IStudentCourseService _studentCourseService;

        public StudentController(IStudentService studentService, IStudentCourseService studentCourseService)
        {
            _studentService = studentService;
            _studentCourseService = studentCourseService;
        }

        // GET: Student
        public ActionResult Index()
        {
            return View(_studentService.GetAll().ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var studentModel = _studentService.Get(id.Value);
            if (studentModel == null)
            {
                return HttpNotFound();
            }
            return View(studentModel);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Gender,DateOfBirth,AddressLine1,AddressLine2,AddressLine3")] StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _studentService.AddNew(studentModel);
                    return RedirectToAction("Index");

                }
                catch (Exception e)
                {
                    _logger.Error(e);
                }
            }

            return View(studentModel);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var studentModel = _studentService.Get(id.Value);
            if (studentModel == null)
            {
                return HttpNotFound();
            }
            return View(studentModel);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Gender,DateOfBirth,AddressLine1,AddressLine2,AddressLine3")] StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _studentService.UpdateStudent(studentModel);
                    return RedirectToAction("Index");

                }
                catch (Exception e)
                {
                    _logger.Error(e);
                }
            }
            return View(studentModel);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var studentModel = _studentService.Get(id.Value);
            if (studentModel == null)
            {
                return HttpNotFound();
            }
            return View(studentModel);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _studentService.RemoveStudent(id);
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }
            return RedirectToAction("Index");
        }

        public ActionResult RemoveCourse(int courseId, int studentId)
        {
            try
            {
                _studentCourseService.RemoveCourseFromStudent(courseId, studentId);
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }
            return RedirectToAction("Index");
        }

    }
}
