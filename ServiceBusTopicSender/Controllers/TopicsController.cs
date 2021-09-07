using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceBusTopicSender.Models;
using ServiceBusTopicSender.Services;

namespace ServiceBusTopicSender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly IAzureTopics _busService;

        public TopicsController(IAzureTopics busService)
        {

            _busService = busService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(Topics message)
        {
            await _busService.SendMessageAsync(message, "servicequeue");
            return Ok(message);
        }
    }
}
