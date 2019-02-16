using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pannel.api.Models;

namespace pannel.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PannelController : ControllerBase
    {


        private List<PannelListEntry> _pannels;

        public PannelController()

        {
            _pannels = new List<PannelListEntry>();

        }
        [HttpGet]
      async  public Task<IActionResult> list()
        {
            return  Ok(_pannels);
        }
    }
}