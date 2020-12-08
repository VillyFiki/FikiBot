using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FikiSite.VKApi.Models.Commands
{
    public class SampleCommand : Command
    {
        public override string Name => "SampleCommand";
        public async override void Execute(VKClient client, VKMessage message)
        {
            message.Body = "Test";
            await client.SendMessage(message);
        }
    }
}
