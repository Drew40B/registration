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
                endDateTime = new DateTime(DateTime.Now.Year, 01, 20, 10, 0, 0)
            });

            _pannels.Add(new Panel()
            {
                pannelId = 2,
                title = "Pannel-ology 2",
                shortDescriptiom = "Continuation of disuccion on why pannels are so important",
                longDescription = "Some realy long description on the advent of the study of panels",
                startDateTime = new DateTime(DateTime.Now.Year, 01, 20, 10, 0, 0),
                endDateTime = new DateTime(DateTime.Now.Year, 01, 20, 11, 0, 0)
            });


        }

        /// <summary>
        /// Lists all pannels
        /// </summary>
        /// <returns>Array of pannels</returns>
        [HttpGet()]
        [ProducesResponseType(typeof(PannelListEntry[]), 200)]
        async public Task<IActionResult> list()
        {
            return Ok(_pannels.ToArray());
        }

        /// <summary>
        /// Gets a specific panel
        /// </summary>
        /// <param name="id">id of the panel to find</param>
        /// <returns>pannel or not found</returns>

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Panel[]), 200)]
        [ProducesResponseType(404)]
        async public Task<IActionResult> get(int id)
        {
            var panel = _pannels.Find((entry) => entry.pannelId == id);

            if (panel == null)
            {
                return NotFound();
            }

            return Ok(panel);
        }
    }
}