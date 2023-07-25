using AdoNet.Models;
using AdoNet.Services.Implements;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdoNet.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index() 
        {
            var res = new StudentService();
            List<Student> data = await res.GetAll();
            return View(data); 
        }
        public async Task<IActionResult> IndexId(int id)
        {
            var res = new StudentService();
            var data = await res.Get(id);
            if(data == null)
            {
                return View("Error");
            }
            return View(data);
        }
    }
}