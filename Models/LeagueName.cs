using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2Api.Models
{
    public class LeagueName
    {
        public string name { get; set; }
        public int leagueid { get; set; }
        public string description { get; set; }
        public string tournament_url { get; set; }
        public int itemdef { get; set; }
    }
    public class Result
    {
        public List<LeagueName> leagues { get; set; }

    }

    public class Root3
    {
        public Result result { get; set; }

    }
}
