using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FikiSite.VKApi.Models.Commands;
using FikiSite.VKApi.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FikiSite.VkApi.Controllers
{
    [Route("vkapi/[controller]")]
    [ApiController]
    public class CallbackController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CallbackController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Callbacks()
        {
            using (StreamReader reader = new StreamReader(Request.Body))
            {

                var commands = Commands.Get();
                var client = new VKClient { Token = _configuration["VKConfig:Token"], Uri = new Uri(_configuration["VKConfig:Uri"]) };

                string strRequest = await reader.ReadToEndAsync();
                JToken responseObject = JToken.Parse(strRequest);
                switch (responseObject.Value<string>("type"))
                {
                    case "confirmation":
                        Confirmation conf = JsonConvert.DeserializeObject<Confirmation>(strRequest);
                        return Ok(_configuration["VKConfig:Confirmation"]);
                    case "message_new":
                        Message msg = JsonConvert.DeserializeObject<Message>(strRequest);
                        var command = commands.FirstOrDefault(x => x.Contains(msg.users.Body));
                        if (command == null)
                        {
                            return Ok("ok");
                        }
                        command.Execute(client, new VKMessage { User_Id = msg.users.Id, Body = ""});

                        return Ok("ok");
                    default:
                        return Ok("ok");
                }
            }
        }
    }
}
