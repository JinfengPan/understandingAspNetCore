using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishTank.Models
{
    public class IntHistoryModel
    {
        public IntHistoryModel(DateTime timeStamp, int value)
        {
            timeStamp = timeStamp;
            value = value;
        }

        public DateTime TimeStamp { get; set; }
        public int Value { get; set; }
    }
}
