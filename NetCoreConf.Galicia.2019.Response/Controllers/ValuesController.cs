using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;

namespace NetCoreConf.Galicia._2019.Response.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            Thread.Sleep(1000);
            return new string[] { "value1", "value2" };
        }
    }
}
