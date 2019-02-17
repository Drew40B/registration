using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pannel.api.Models;
using System;

namespace pannel.api.Controllers
{
    [Route("api/v1/pannel")]
    [ApiController]
    public class PannelController : ControllerBase
    {


        private List<Panel> _pannels;

        public PannelController()

        {
            _pannels = new List<Panel>();

            _pannels.Add(new Panel()
            {
                pannelId = 1,
                title = "Pannel-ology",
                shortDescriptiom = "Disuccion on why pannels are so important",
                longDescription = "Some realy long description on the advent of the study of panels",
                startDateTime = new DateTime(DateTime.Now.Year, 01, 20, 9, 0, 0),
                endDateTime = new DateTime(DateTime.Now.Year, 01, 20, 9, 0, 0)
            });

        }

        /// <summary>
        /// Lists all pannels
        /// </summary>
        /// <returns>Array of pannels</returns>
        [HttpGet]
        [ProducesResponseType(typeof(PannelListEntry[]), 200)]


        async public Task<IActionResult> list()
        {
            return Ok(_pannels.ToArray());
        }
    }
}