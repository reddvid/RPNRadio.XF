using System;
using System.Collections.Generic;
using System.Text;

namespace RPNRadio.Core.Models
{
    public class Station
    {
        const string MAIN_IP = "87.98.130.255";
        const string CEBU_IP = "178.32.62.172";

        public string Name { get; set; }
        public int Port { get; set; }
        public string Url { get; set; }
        public string ShortName => Name.Replace(Name.Substring(0, 4), string.Empty).Trim();

        public Station(string name, int port)
        {
            Name = name;
            Port = port;

            if (name.Contains("Cebu")) Url = $"http://{CEBU_IP}:{port}/stream";
            else if (name.Contains("Test")) Url = "http://149.56.147.197:9079/stream";
            else Url = $"http://{MAIN_IP}:{port}/stream";

            Url += ".mp3";
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
