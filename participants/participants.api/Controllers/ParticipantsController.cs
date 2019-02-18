using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using participants.api.Models;
using participants.api.Services;
namespace participants.api.Controllers
{
    /// <summary>
    /// Participant Managemnt 
    /// </summary>
    [Route("api/v1/participants")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {

        private ParticipantService _service;


        public ParticipantsController(ParticipantService service)
        {
            _service = service;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participant>>> List()
        {

            var list = await _service.List();
            return Ok(list);
        }
    }
}