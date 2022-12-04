using _641716_ServerSideAssignment.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _641716_ServerSideAssignment.PublicApi
{
    public class SongsterrApi
    {
        public async static Task<string> GetSongAndArtistName(string colorName, HttpClient httpClient)
        {         
                var httpResponse = await httpClient.GetAsync($"https://www.songsterr.com/a/ra/songs.json?pattern={colorName}");
                string content = await httpResponse.Content.ReadAsStringAsync();
                List<SongsterrApiModel> songsterModels = JsonConvert.DeserializeObject<List<SongsterrApiModel>>(content);
                if(songsterModels.Count>0)
                    return String.Format($"{songsterModels[0].title} by {songsterModels[0].artist.name}");
                else
                    return $"No song found with: {colorName}";                     
        }
    }
}
