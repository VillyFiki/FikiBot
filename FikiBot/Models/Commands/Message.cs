using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FikiSite.VKApi.Models.Commands
{
    public class VKClient
    {
        public string Token { get; set; }
        public Uri Uri { get; set; }

        public async Task SendMessage(VKMessage message)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = Uri;
            await client.GetAsync($"?user_id={message.User_Id}&random_id={message.Random_Id}&message={message.Body}&access_token={Token}&v=5.126");

            //https://api.vk.com/method/messages.send?user_id=541412571&random_id=745779223&message=Test&access_token=7d6f6c7173f0db4fddd1d8224cd9c0a24a049e3bf723a5d6c5dac63fba278f0f57a20c4c6ac943b3850ad&v=5.126

        }
    }
    public class VKMessage
    {
        public long User_Id { get; set; }
        public int Random_Id
        {
            get
            {
                Random rnd = new Random();
                return rnd.Next(0, 999999999);
            }
        }
        public string Body { get; set; }
    }
}
