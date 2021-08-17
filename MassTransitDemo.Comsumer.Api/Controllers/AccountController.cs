using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MassTransit;
using MassTransitDemo.Events;

namespace MassTransitDemo.Producer.Api
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        readonly IPublishEndpoint _publishEndpoint;

        public AccountController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<ActionResult> Post()
        {
            await _publishEndpoint.Publish<AccountMessage>(new AccountMessage()
            {
                Id = 1,
                Name = "Billy",
                Email = "billy@gmail.com"
            });
            return Ok();
        }
    }
}
