using Microsoft.AspNetCore.Mvc;

namespace BookStoreMVC.Controllers
{
    [Route("Book")]
    public class BookController : Controller
    {
        [Route("Index")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
