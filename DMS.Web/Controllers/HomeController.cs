using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace VHR.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/Account/Login");
           
        }


        [Route("/Dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }



        [Route("/Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
