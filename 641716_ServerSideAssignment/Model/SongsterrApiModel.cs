using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _641716_ServerSideAssignment.Model
{
    //I use songsterr api to look up songs that has the name of the colour. It's not 100% accurate but it always finds a song name by an artist.
    // I used  'https://json2csharp.com/' to convert this class into json.
    public class SongsterrApiModel
    {
        public int id { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public Artist artist { get; set; }
        public bool chordsPresent { get; set; }
        public List<string> tabTypes { get; set; }
    }
    public class Artist
    {
        public int id { get; set; }
        public string type { get; set; }
        public string nameWithoutThePrefix { get; set; }
        public bool useThePrefix { get; set; }
        public string name { get; set; }
    }
}
