using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Models;
using Restaurants.Models.Exceptions;
using Restaurants.Models.validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurants.Controllers
{
    [Route("api/openinghours")]
    [ApiController]
    [Produces("application/json")]
    public class WorkTimelineController : ControllerBase
    {
        public WorkTimelineController()
        {

        }



        [HttpPost("new")]
        public async Task<IActionResult> PostWorkingDays([FromBody] Dictionary<string,List<WorkingHoursValueType>> keyValues)
        {

            try
            {
                var result = new List<WorkingHoursResponse>();
                foreach (var kvp in keyValues)
                {

                    result.Add(new WorkingHoursResponse(kvp));

                }
                return StatusCode(StatusCodes.Status200OK, new ClientResponse(true,"success",null,result));
                
            }
            catch (Exception exceptions)
            {
                if (exceptions is ValidationException)
                {
                    var ex = exceptions as ValidationException;
                    return StatusCode(StatusCodes.Status500InternalServerError, new ClientResponse(false, "failed", ex.ValidationErrors, null));
                }

                return StatusCode(StatusCodes.Status500InternalServerError, new ClientResponse(true, "failed", exceptions.Message, null));
            }
           


        }
    }
}
