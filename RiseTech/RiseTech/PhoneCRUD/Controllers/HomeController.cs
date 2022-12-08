using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PhoneCRUD.Entity;
using PhoneCRUD.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCRUD.Controllers
{
    public class HomeController : Controller
    {
        //loglama yapılan class.
        private readonly ILogger<HomeController> _logger;


        //context.
        private readonly Context _context;
        public HomeController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm] Phone phone)
        {
            _context.Add(phone);
            _context.SaveChanges();
            using (var httpClient = new HttpClient())
            {
                var tmpPhone = new
                {
                    phone = phone.PhoneNumber
                };
                var content = new StringContent(JsonConvert.SerializeObject(tmpPhone), Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync("https://localhost:44372/api/PhoneReport", content).GetAwaiter().GetResult();
                if (!response.IsSuccessStatusCode)
                {
                    throw new System.Exception("Hata Olustu");
                }
            }
            ViewData["isSuccess"] = "true";
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
