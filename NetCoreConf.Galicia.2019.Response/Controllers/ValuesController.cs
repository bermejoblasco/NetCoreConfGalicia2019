using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Mvc;
using NetCoreConf.Galicia._2019.Response.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NetCoreConf.Galicia._2019.Response.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private TelemetryClient telemetry;

        public ValuesController(TelemetryClient telemetry)
        {
            this.telemetry = telemetry;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            Thread.Sleep(1000);
            telemetry.TrackEvent("GetValues");
            return new string[] { "value1", "value2" };
        }


    }
}
