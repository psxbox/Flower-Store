using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FlowerStore.Api.Controllers.v1
{
    /// <summary>
    /// TestApi controller v1
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class TestApiController : ControllerBase
    {
        /// <summary>
        /// Test 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Get() => "API Version 1.";
    }
}