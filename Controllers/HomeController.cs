using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Random_Password.Models;

namespace Random_Password.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("Counter", 1);
            ViewBag.Count = HttpContext.Session.GetInt32("Counter");
            var stringChars = new char[14];
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            ViewBag.Passcode = finalString;
            return View();
        }

        [HttpPost("/add")]
        public IActionResult Add()
        {
            int? c = HttpContext.Session.GetInt32("Counter");
            HttpContext.Session.SetInt32("Counter", (int)c + 1);
            System.Console.WriteLine(c);

            var stringChars = new char[14];
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            ViewBag.Passcode = finalString;


            ViewBag.Count = HttpContext.Session.GetInt32("Counter");
            return View("Index");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
