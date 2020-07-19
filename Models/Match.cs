using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace Dota2Api.Models
{
    public class Match
    {
        public int account_id { get; set; }
        public int hero_id { get; set; }
    }
    public class GameList
    {
        public int activate_time { get; set; }
        public int deactivate_time { get; set; }
        public object server_steam_id { get; set; }
        public long lobby_id { get; set; }
        public int league_id { get; set; }
        public int lobby_type { get; set; }
        public int game_time { get; set; }
        public int delay { get; set; }
        public int spectators { get; set; }
        public int game_mode { get; set; }
        public int average_mmr { get; set; }
        public object match_id { get; set; }
        public int series_id { get; set; }
        public string team_name_radiant { get; set; }
        public string team_name_dire { get; set; }
        public object team_logo_radiant { get; set; }
        public object team_logo_dire { get; set; }
        public int team_id_radiant { get; set; }
        public int team_id_dire { get; set; }
        public int sort_score { get; set; }
        public int last_update_time { get; set; }
        public int radiant_lead { get; set; }
        public int radiant_score { get; set; }
        public int dire_score { get; set; }
        public List<Match> players { get; set; }
        public int building_state { get; set; }
        public string red_url_logo { get; set; }
        public string dir_url_logo { get; set; }
    }

    public class Root
    {
        public List<GameList> game_list { get; set; }

    }
}
