using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoApp.DataAccess;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult error()
        {
            return View();
        }



    }
}
