using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FikiSite.VKApi.Models.Commands
{
    public class Commands
    {
        public static List<Command> Get()
        {
            List<Command> commands = new List<Command> 
            {
                new SampleCommand()

                //More commands
            };

            return commands;
        } 
    }
}
