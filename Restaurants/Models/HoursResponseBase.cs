using Restaurants.Models.validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurants.Models
{
    public abstract class HoursResponseBase
    {
        public HoursResponseBase(KeyValuePair<string, List<WorkingHoursValueType>> data)
        {
            Day = data.Key;
           
        }

        public string Day { get; set; }

        public List<string> OpeningHours { get; set; } = new List<string>();
        private void ExtractOpeningHourTimeInHumanUnderstandableFormat(WorkingHoursValueType workingHours, string type)
        {
            var datTime = new DateTime(1970, 01, 01, 0, 0, 0, System.DateTimeKind.Utc);
            datTime = datTime.AddSeconds(workingHours.value);
            OpeningHours.Add($"{type} : {datTime.ToShortTimeString()}");
        }

        public  void UnixTimeToDateTime(List<WorkingHoursValueType> workingHours, string day)
        {
            foreach (var time in workingHours)
            {
                var validationResult = new WorkingHoursValueTypeValidator().Validate(time);

                if (validationResult.Errors.Count > 0)
                    throw new Exceptions.ValidationException(validationResult);

                if (time.type.ToLower().Equals("open"))
                {
                    ExtractOpeningHourTimeInHumanUnderstandableFormat(time, "open");

                }

                if (time.type.ToLower().Equals("close"))
                {
                    ExtractOpeningHourTimeInHumanUnderstandableFormat(time, "close");


                }



            }

        }
    }
}
