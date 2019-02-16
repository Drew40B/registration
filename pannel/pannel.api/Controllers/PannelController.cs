using System.Collections.Generic;
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
        public ActionResult<IEnumerable<PannelListEntry>> list()
        {
            return _pannels;
        }
    }
}