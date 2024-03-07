using Microsoft.AspNetCore.Mvc;

namespace BookStoreMVC.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        [Route("Index")]
        [Route("")]
        [Route("~/")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
