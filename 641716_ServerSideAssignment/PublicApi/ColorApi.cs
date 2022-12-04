using _641716_ServerSideAssignment.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _641716_ServerSideAssignment.publicapi
{
    public class ColorApi
    {
        public async static Task<string> ConvertHexToColorName(string hex, HttpClient httpClient)
        {
            var httpResponse = await httpClient.GetAsync($"https://www.thecolorapi.com/id?hex={hex}");
            string content = await httpResponse.Content.ReadAsStringAsync();
            ColorApiModel colorApiModel = JsonConvert.DeserializeObject<ColorApiModel>(content);
            return colorApiModel.name.value;
        }
    }
}
