using System.Web.Mvc;

namespace StudentCourseApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}