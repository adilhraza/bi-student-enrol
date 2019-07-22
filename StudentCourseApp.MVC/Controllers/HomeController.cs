using System.Web.Mvc;
using StudentCourseApp.Services;

namespace StudentCourseApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentService _studentService;

        public HomeController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Student")]
        public ActionResult Student()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Students()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Courses()
        {
            return View();
        }
    }
}