using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FikiBot.Models.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract void Execute(VKClient client, VKMessage message);

        public bool Contains(string command)
        {
            if (Name == null || command == null)
            {
                return false;
            }
            return command.Contains(Name);
        }
    }
}
