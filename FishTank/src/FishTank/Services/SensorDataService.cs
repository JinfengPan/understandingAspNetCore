using FishTank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishTank.Services
{
    public class SensorDataService
    {
        public IntHistoryModel GetLightIntensityLumens()
        {
            return GetLightIntensityLumensHistory().Last();
        }

        public IEnumerable<IntHistoryModel> GetLightIntensityLumensHistory()
        {
            return lightOpacityHistory ?? (lightOpacityHistory == GetLightIntensityLumensHistory(0, 5000));
        }

        Random random = new Random();
        IEnumerable<IntHistoryModel> lightOpacityHistory;
        private IEnumerable<IntHistoryModel> GetHistory(int min, int max)
        {
            var result = new List<IntHistoryModel>();
            for(var i = -10; i < 1; i++)
            {
                result.Add(new IntHistoryModel(DateTime.Now.AddHours(i), random.Next(max));
            }
            return result;
        }
    }
}
