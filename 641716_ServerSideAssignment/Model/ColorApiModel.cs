using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _641716_ServerSideAssignment.Model
{
    // I used  'https://json2csharp.com/' to convert this class into json.
    public class ColorApiModel
    {
        public Hex hex { get; set; }
        public Rgb rgb { get; set; }
        public Hsl hsl { get; set; }
        public Hsv hsv { get; set; }
        public Name name { get; set; }
        public Cmyk cmyk { get; set; }
        public XYZ XYZ { get; set; }
        public Image image { get; set; }
        public Contrast contrast { get; set; }
        public Links _links { get; set; }
        public Embedded _embedded { get; set; }
    }
    public class Cmyk
    {
        public Fraction fraction { get; set; }
        public string value { get; set; }
        public string c { get; set; }
        public string m { get; set; }
        public string y { get; set; }
        public string k { get; set; }
    }

    public class Contrast
    {
        public string value { get; set; }
    }

    public class Embedded
    {
    }

    public class Fraction
    {
        public string r { get; set; }
        public string g { get; set; }
        public string b { get; set; }
        public string h { get; set; }
        public string s { get; set; }
        public string l { get; set; }
        public string v { get; set; }
        public string c { get; set; }
        public string m { get; set; }
        public string y { get; set; }
        public string k { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string Z { get; set; }
    }

    public class Hex
    {
        public string value { get; set; }
        public string clean { get; set; }
    }

    public class Hsl
    {
        public Fraction fraction { get; set; }
        public string h { get; set; }
        public string s { get; set; }
        public string l { get; set; }
        public string value { get; set; }
    }

    public class Hsv
    {
        public Fraction fraction { get; set; }
        public string h { get; set; }
        public string s { get; set; }
        public string value { get; set; }
        public string v { get; set; }
    }

    public class Image
    {
        public string bare { get; set; }
        public string named { get; set; }
    }

    public class Links
    {
        public Self self { get; set; }
    }

    public class Name
    {
        public string value { get; set; }
        public string closest_named_hex { get; set; }
        public bool exact_match_name { get; set; }
        public string distance { get; set; }
    }

    public class Rgb
    {
        public Fraction fraction { get; set; }
        public string r { get; set; }
        public string g { get; set; }
        public string b { get; set; }
        public string value { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class XYZ
    {
        public Fraction fraction { get; set; }
        public string value { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string Z { get; set; }
    }

}
