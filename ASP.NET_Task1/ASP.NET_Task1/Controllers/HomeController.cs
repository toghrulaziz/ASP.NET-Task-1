using ASP.NET_Task1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.NET_Task1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // ViewResult 
        public IActionResult Index()
        {
            return View();
        }

        // ViewResult 
        public IActionResult Privacy()
        {
            return View();
        }

        // JsonResult 
        public IActionResult GetJsonData()
        {
            var jsonData = new { Name = "Hakuna", Surname = "Matata", Age = 42 };
            return Json(jsonData);
        }

        // RedirectResult 
        public IActionResult RedirectToAnotherPage()
        {
            return Redirect("https://www.google.com");
        }

        // EmptyResult 
        public IActionResult NoContent()
        {
            return new EmptyResult();
        }

        // JavaScriptResult 
        public IActionResult GetJavaScriptFile()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", "js10.js");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/javascript");
        }


        // ContentResult 
        public IActionResult GetTextContent()
        {
            return Content("Hakuna Matata");
        }


        // FileContentResult 
        public IActionResult GetTextFile()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", "Hakuna Matata.txt");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            string fileContent = System.IO.File.ReadAllText(filePath);
            return Content(fileContent, "text/plain");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}