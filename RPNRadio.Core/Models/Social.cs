using System;
using System.Collections.Generic;
using System.Text;

namespace RPNRadio.Core.Models
{
    public class Facebook
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Twitter
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Youtube
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Social
    {
        public string name { get; set; }
        public string callsign { get; set; }
        public Facebook facebook { get; set; }
        public Twitter twitter { get; set; }
        public Youtube youtube { get; set; }
    }

    public class RootObject
    {
        public List<Social> social { get; set; }
    }
}
