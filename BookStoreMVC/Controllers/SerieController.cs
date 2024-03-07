using BookStoreMVC.Interfaces;
using BookStoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreMVC.Controllers
{
    [Route("Serie")]
    public class SerieController : Controller
    {
        private ISerieService _serieService;
        public SerieController(ISerieService serieService) 
        {
            _serieService = serieService;
        }
        [Route("Index")]
        [Route("")]
        public IActionResult Index()
        {
            var series = _serieService.Series.ToList();
            if(series != null)
            {
                ViewBag.series =series; 
            }
            else
            {
                ViewBag.series = null;
            }
            return View();
        }
    }
}
