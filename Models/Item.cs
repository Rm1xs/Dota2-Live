using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2Api.Models
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public int cost { get; set; }
        public int secret_shop { get; set; }
        public int side_shop { get; set; }
        public int recipe { get; set; }

    }

    public class ResultItem
    {
        public List<Item> items { get; set; }
        public int status { get; set; }

    }

    public class RootItem
    {
        public ResultItem result { get; set; }

    }
}
