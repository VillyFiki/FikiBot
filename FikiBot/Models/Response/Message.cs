﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FikiBot.Models.Response
{
    public class Message : IRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("object")]
        public Users users { get; set; }
        [JsonProperty("group_id")]
        public long Group_id { get; set; }
        [JsonProperty("secret")]
        public string Secret { get; set; }
    }

    public class Users
    {
        [JsonProperty("user_id")]
        public long Id { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
        [JsonProperty("date")]
        public int Date { get; set; }
        [JsonProperty("out")]
        public int Out { get; set; }
        [JsonProperty("read_state")]
        public int Read_State { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
