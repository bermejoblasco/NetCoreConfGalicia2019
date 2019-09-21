using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetCoreConf.Galicia._2019.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        // GET api/request
        [HttpGet]
        public async Task<ActionResult<string>> GetAsync()
        {
            string ret;

            var client = new HttpClient();
            ret = await client.GetStringAsync("http://xxx.azurewebsites.net/api/values");

            return ret;
        }
    }
}
