using Microsoft.AspNetCore.Mvc;

namespace MovieGalleryApp.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
