using ENSEK.Helpers;
using ENSEK.Models;
using ENSEK.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ENSEK.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    public class EnsekController : ControllerBase
    {
        private readonly ILogger<EnsekController> _logger;

        public EnsekController(ILogger<EnsekController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("api/[controller]/create")]
        public IActionResult Create([FromForm] IFormFile file)
        {
            var meterService = new MeterService();
            var meterStatus = meterService.SaveMeterReaderList(file);

            return Ok(meterStatus);
        }
    
    }
}
