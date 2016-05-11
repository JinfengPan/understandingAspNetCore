using FishTank.ViewModels;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishTank.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult GetWaterTemperatureChart()
        {
            return View("Chart", new ChartViewModel
            {
                Title = "Water Temperature",
                DataUrl = Url.Action("GetWaterTemperatureHistory",
                "HistoryData")
            });
        }

        public IActionResult GetWaterOpacityPercentageChart()
        {
            return View("Chart", new ChartViewModel
            {
                Title = "Water opacity",
                DataUrl = Url.Action("GetWaterOpacityPercentageHistory",
                "HistoryData")
            });
        }

        public IActionResult GetLightIntensityLumensChart()
        {
            return View("Chart", new ChartViewModel
            {
                Title = "Light Intensity",
                DataUrl = Url.Action("GetLightIntensityLumensHistory",
                "HistoryData")
            });
        }
    }
}

