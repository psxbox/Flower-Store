using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FlowerStore.Api.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class TestApiController : ControllerBase
    {
        [HttpGet]
        public string Get() => "API Version 2.";
    }
}