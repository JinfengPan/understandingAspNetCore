using FishTank.Models;
using FishTank.Services;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishTank.Controllers.Api
{
    public class HistoryDataController : Controller
    {
        private readonly ISensorDataService sensorDataService;

        public HistoryDataController(ISensorDataService sensorDataService)
        {
            this.sensorDataService = sensorDataService;
        }

        public IEnumerable<IntHistoryModel> GetWaterTemperatureHistory()
        {
            return sensorDataService
                .GetWaterTemperatureFahrenheitHistory();
        }

        public IEnumerable<IntHistoryModel> GetFishMotionPercentageHistory()
        {
            return sensorDataService
                .GetFishMotionPercentageHistory();
        }
        public IEnumerable<IntHistoryModel> GetWaterOpacityPercentageHistory()
        {
            return sensorDataService
                .GetWaterOpacityPercentageHistory();
        }
        public IEnumerable<IntHistoryModel> GetLightIntensityLumensHistory()
        {
            return sensorDataService
                .GetLightIntensityLumensHistory();
        }

    }
}
