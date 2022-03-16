using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieGalleryApp.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
