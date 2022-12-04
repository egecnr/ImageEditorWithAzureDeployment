using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _641716_ServerSideAssignment.Model
{
    public class ImageProperties
    {
        public string imgId { get; set; }
        public string colorText1 { get; set; }
        public string colorText2 { get; set; }
        public string colorHex1 { get; set; }
        public string colorHex2 { get; set; }
        public string color1 { get; set; }
        public string color2 { get; set; }

        public byte[] imgByte { get; set; }
    }
}
