using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FikiBot.Models.Commands
{
    public class Ping : Command
    {
        public override string Name => "ping";
        public async override void Execute(VKClient client, VKMessage message)
        {
            message.Body = "pong";
            await client.SendMessage(message);
        }
    }
}
