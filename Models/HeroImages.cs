using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2Api.Models
{
    public class HeroImages
    {
        public ResultHImage result { get; set; }
    }
    public class Hero
    {
        public string name { get; set; }
        public int id { get; set; }

    }

    public class ResultHImage
    {
        public List<Hero> heroes { get; set; }
        public int status { get; set; }
        public int count { get; set; }

    }
}
