using Restaurants.Models.Exceptions;
using Restaurants.Models.validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurants.Models
{
    public class WorkingHoursResponse: HoursResponseBase
    {
        public WorkingHoursResponse(KeyValuePair<string, List<WorkingHoursValueType>> data):base(data)
        {
            
            if(data.Value.Count > 0) 
                this.UnixTimeToDateTime(data.Value, data.Key);
            else
                OpeningHours.Add("closed");

        }
        
    }
}
