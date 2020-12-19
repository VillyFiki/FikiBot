using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FikiBot.Models.Commands
{
    public class Commands
    {
        public static List<Command> Get()
        {
            List<Command> commands = new List<Command> 
            {
                new Ping()

                //More commands
            };

            return commands;
        } 
    }
}
