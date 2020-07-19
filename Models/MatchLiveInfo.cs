
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2Api.Models
{
    public class MatchLiveInfo
    {
        public ResultLive result { get; set; }
    }
    public class Player
    {
        public int account_id { get; set; }
        public string name { get; set; }
        public int hero_id { get; set; }
        public int team { get; set; }

    }

    public class RadiantTeam
    {
        public string team_name { get; set; }
        public int team_id { get; set; }
        public object team_logo { get; set; }
        public bool complete { get; set; }

    }

    public class DireTeam
    {
        public string team_name { get; set; }
        public int team_id { get; set; }
        public object team_logo { get; set; }
        public bool complete { get; set; }

    }

    public class Pick
    {
        public int hero_id { get; set; }

    }

    public class Ban
    {
        public int hero_id { get; set; }

    }

    public class Player2
    {
        public int player_slot { get; set; }
        public int account_id { get; set; }
        public int hero_id { get; set; }
        public int kills { get; set; }
        public int death { get; set; }
        public int assists { get; set; }
        public int last_hits { get; set; }
        public int denies { get; set; }
        public int gold { get; set; }
        public int level { get; set; }
        public int gold_per_min { get; set; }
        public int xp_per_min { get; set; }
        public int ultimate_state { get; set; }
        public int ultimate_cooldown { get; set; }
        public int item0 { get; set; }
        public int item1 { get; set; }
        public int item2 { get; set; }
        public int item3 { get; set; }
        public int item4 { get; set; }
        public int item5 { get; set; }
        public int respawn_timer { get; set; }
        public double position_x { get; set; }
        public double position_y { get; set; }
        public int net_worth { get; set; }

    }

    public class Ability
    {
        public int ability_id { get; set; }
        public int ability_level { get; set; }

    }

    public class Radiant
    {
        public int score { get; set; }
        public int tower_state { get; set; }
        public int barracks_state { get; set; }
        public List<Pick> picks { get; set; }
        public List<Ban> bans { get; set; }
        public List<Player2> players { get; set; }
        public List<Ability> abilities { get; set; }

    }

    public class Pick2
    {
        public int hero_id { get; set; }

    }

    public class Ban2
    {
        public int hero_id { get; set; }

    }

    public class Player3
    {
        public int player_slot { get; set; }
        public int account_id { get; set; }
        public int hero_id { get; set; }
        public int kills { get; set; }
        public int death { get; set; }
        public int assists { get; set; }
        public int last_hits { get; set; }
        public int denies { get; set; }
        public int gold { get; set; }
        public int level { get; set; }
        public int gold_per_min { get; set; }
        public int xp_per_min { get; set; }
        public int ultimate_state { get; set; }
        public int ultimate_cooldown { get; set; }
        public int item0 { get; set; }
        public int item1 { get; set; }
        public int item2 { get; set; }
        public int item3 { get; set; }
        public int item4 { get; set; }
        public int item5 { get; set; }
        public int respawn_timer { get; set; }
        public double position_x { get; set; }
        public double position_y { get; set; }
        public int net_worth { get; set; }

    }

    public class Ability2
    {
        public int ability_id { get; set; }
        public int ability_level { get; set; }

    }

    public class Dire
    {
        public int score { get; set; }
        public int tower_state { get; set; }
        public int barracks_state { get; set; }
        public List<Pick2> picks { get; set; }
        public List<Ban2> bans { get; set; }
        public List<Player3> players { get; set; }
        public List<Ability2> abilities { get; set; }

    }

    public class Scoreboard
    {
        public double duration { get; set; }
        public int roshan_respawn_timer { get; set; }
        public Radiant radiant { get; set; }
        public Dire dire { get; set; }

    }

    public class Game
    {
        public List<LiveLead> lead { get; set; }
        public List<Player> players { get; set; }
        public RadiantTeam radiant_team { get; set; }
        public DireTeam dire_team { get; set; }
        public long lobby_id { get; set; }
        public long match_id { get; set; }
        public int spectators { get; set; }
        public int league_id { get; set; }
        public int league_node_id { get; set; }
        public int stream_delay_s { get; set; }
        public int radiant_series_wins { get; set; }
        public int dire_series_wins { get; set; }
        public int series_type { get; set; }
        public Scoreboard scoreboard { get; set; }

    }
    public class LiveLead
    {
        public long lead { get; set; }

        public long lobid {get;set;}
        public int id { get; set; }
}

public class ResultLive
{
    public List<Game> games { get; set; }
    public int status { get; set; }

}
}
