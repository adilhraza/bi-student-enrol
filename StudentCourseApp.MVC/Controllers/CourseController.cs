using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NLog;
using StudentCourseApp.Services;
using StudentCourseApp.Shared.Models;

namespace StudentCourseApp.MVC.Controllers
{
    public class CourseController : Controller
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: Course
        public ActionResult Index()
        {
            return View(_courseService.GetAll().ToList());
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var courseModel = _courseService.Get(id.Value);
            if (courseModel == null)
            {
                return HttpNotFound();
            }
            return View(courseModel);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CourseCode,CourseName,TeacherName,StartDate,EndDate")] CourseModel courseModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _courseService.AddNew(courseModel);
                    return RedirectToAction("Index");

                }
                catch (Exception e)
                {
                    _logger.Error(e);
                }
            }

            return View(courseModel);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var courseModel = _courseService.Get(id.Value);
            if (courseModel == null)
            {
                return HttpNotFound();
            }
            return View(courseModel);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourseCode,CourseName,TeacherName,StartDate,EndDate")] CourseModel courseModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _courseService.UpdateCourse(courseModel);
                    return RedirectToAction("Index");

                }
                catch (Exception e)
                {
                    _logger.Error(e);
                }
            }
            return View(courseModel);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var courseModel = _courseService.Get(id.Value);
            if (courseModel == null)
            {
                return HttpNotFound();
            }
            return View(courseModel);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _courseService.RemoveCourse(id);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                _logger.Error(e);
            }
        }
    }
}
