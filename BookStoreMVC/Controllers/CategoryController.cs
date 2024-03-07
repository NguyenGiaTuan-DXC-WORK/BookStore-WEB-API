using Microsoft.AspNetCore.Mvc;

namespace BookStoreMVC.Controllers
{
    [Route("Category")]
    public class CategoryController : Controller
    {
        [Route("Index")]
        [Route("")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
