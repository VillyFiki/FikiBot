using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FikiBot.Models.Response
{
    public interface IRequest
    {
        public string Type { get; set; }
    }

    public class Confirmation : IRequest
    {
        public string Type { get; set; }
        public string Group_ID { get; set; }
    }
}
