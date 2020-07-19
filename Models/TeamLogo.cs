using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2Api.Models
{
    public class TeamLogo
    {
        public string filename { get; set; }
        public string url { get; set; }
        public int size { get; set; }
    }
    public class RootLogo
    {
        public TeamLogo data { get; set; }

    }
}
