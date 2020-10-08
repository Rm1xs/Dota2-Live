using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dota2Api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dota2Api.Controllers
{
    public class MatchesController : Controller
    {
        List<LiveLead> live = new List<LiveLead>();

        public void GetLead()
        {
            //get lead of 1 team
            const string url2 = "https://api.steampowered.com/IDOTA2Match_570/GetTopLiveGame/v1/?key=A936A9076BEB4894258B4CB51EFC4A58&partner=1";
            HttpClient client2 = new HttpClient();
            Encoding.GetEncoding("ISO-8859-1");
            client2.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            var data2 = client2.GetAsync(url2).Result.Content.ReadAsStringAsync().Result;
            List<Root> locations2 = new List<Root> { JsonConvert.DeserializeObject<Root>(data2) };
            foreach (var getInf in locations2)
            {
                foreach (var getVal in getInf.game_list)
                {
                    if (getVal.radiant_lead >= 0)
                    {
                        live.Add(new LiveLead { lead = getVal.radiant_lead, lobid = getVal.lobby_id, id = 1 });
                    }
                    else
                    {
                        string val = getVal.radiant_lead.ToString();
                        string s4 = val.Trim(new char[] { '-' });
                        long l = long.Parse(s4);
                        live.Add(new LiveLead { lead = l, lobid = getVal.lobby_id, id = 2 });
                    }
                }
            }
        }
        //Get all live matches
        public IActionResult Index(long id)
        {
            const string url = "https://api.steampowered.com/IDOTA2Match_570/GetLiveLeagueGames/v1/?key=A936A9076BEB4894258B4CB51EFC4A58&partner=1";
            HttpClient client = new HttpClient();
            Encoding.GetEncoding("ISO-8859-1");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            var data = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            List<MatchLiveInfo> locations = new List<MatchLiveInfo> { JsonConvert.DeserializeObject<MatchLiveInfo>(data) };
            List<Game> games = new List<Game>();
            GetLead();
            foreach (var a in locations)
            {
                foreach (var b in a.result.games)
                {
                    if (b.match_id == id)
                    {
                        games.Add(new Game { dire_team = b.dire_team, match_id = b.match_id, players = b.players, radiant_team = b.radiant_team, scoreboard = b.scoreboard, lead = live, lobby_id = b.lobby_id });
                    }
                }
            }
            //games.OrderByDescending(f => f.scoreboard.dire.players);
            return View(games);
        }

        public IActionResult UpdatePage(long id)
        {
            const string url = "https://api.steampowered.com/IDOTA2Match_570/GetLiveLeagueGames/v1/?key=A936A9076BEB4894258B4CB51EFC4A58&partner=1";
            HttpClient client = new HttpClient();
            Encoding.GetEncoding("ISO-8859-1");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            var data = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            List<MatchLiveInfo> locations = new List<MatchLiveInfo> { JsonConvert.DeserializeObject<MatchLiveInfo>(data) };
            List<Game> games = new List<Game>();
            GetLead();
            foreach (var a in locations)
            {
                foreach (var b in a.result.games)
                {
                    if (b.match_id == id)
                    {
                        games.Add(new Game { dire_team = b.dire_team, match_id = b.match_id, players = b.players, radiant_team = b.radiant_team, scoreboard = b.scoreboard, lead = live, lobby_id = b.lobby_id });
                    }
                }
            }
            //games.OrderByDescending(f => f.scoreboard.dire.players);
            return View(games);
        }

        public string GetImageChar(int id)
        {

            string result = "";
            const string url = "https://api.steampowered.com/IEconDOTA2_570/GetHeroes/v0001/?key=A936A9076BEB4894258B4CB51EFC4A58";
            HttpClient client = new HttpClient();
            Encoding.GetEncoding("ISO-8859-1");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            var data = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            List<HeroImages> locations = new List<HeroImages> { JsonConvert.DeserializeObject<HeroImages>(data) };
            foreach (var a in locations)
            {
                foreach (var b in a.result.heroes)
                {
                    if (b.id == id)
                    {
                        b.name = b.name.Replace("npc_dota_hero_", "");
                        result = "http://cdn.dota2.com/apps/dota2/images/heroes/" + b.name + "_sb.png";
                    }
                }
            }
            return result;
        }

        public string GetImageItem(int id)
        {
            string result = "";
            const string url = "https://api.steampowered.com/IEconDOTA2_570/GetGameItems/V001/?key=A936A9076BEB4894258B4CB51EFC4A58";
            HttpClient client = new HttpClient();
            Encoding.GetEncoding("ISO-8859-1");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            var data = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            List<RootItem> locations = new List<RootItem> { JsonConvert.DeserializeObject<RootItem>(data) };
            foreach (var a in locations)
            {
                foreach (var t in a.result.items)
                {
                    if (t.id == id)
                    {
                        t.name = t.name.Replace("item_", "");
                        result = "http://cdn.dota2.com/apps/dota2/images/items/" + t.name + "_lg.png";
                    }
                }
            }
            return result;
        }


    }
}