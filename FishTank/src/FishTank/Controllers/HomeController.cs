using FishTank.Services;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishTank.Controllers
{
    public class HomeController : Controller
    {
        private IViewModelService viewModelService;
        public HomeController(IViewModelService viewModelService)
        {
            this.viewModelService = viewModelService;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Fish tank dashboard";
            return View(viewModelService.GetDashboardViewModel());
        }
    }
}
