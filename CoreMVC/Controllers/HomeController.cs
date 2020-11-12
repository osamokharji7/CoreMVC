using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dbBackend.Models;
using System.Text.Json.Serialization;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using dbBackend.Repositories;

namespace dbBackend.Controllers
{
    public class HomeController : Controller
    {
        private UoW unitOfwork= new UoW();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public string AddEmployee([FromBody] Employee post_emp)
        {

            return UoW.employeeRepository.AddT(post_emp);
        }

        [HttpPost]
        public string UpdateEmployee([FromBody] Employee post_emp)
        {

            return UoW.employeeRepository.UpdateT(post_emp);
        }

        [HttpPost]
        public string DeleteEmployee([FromBody] Employee post_emp)
        {
            return UoW.employeeRepository.DeleteT(post_emp);
        }

        [HttpPost]
        public string GetEmployees()
        {
            return UoW.employeeRepository.GetTs();
        }
        public string GetEmployeeById([FromBody] HelperModels post_data)
        {
            //return JsonConvert.SerializeObject(post_data);
            return UoW.employeeRepository.GetTById(1);
        }

        public IActionResult Index()
        {
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
