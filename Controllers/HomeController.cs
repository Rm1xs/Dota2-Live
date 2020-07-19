using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dota2Api.Models;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Nancy.Json;
using System.Security;
using System.Runtime.InteropServices;

namespace Dota2Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            List<GameList> meny_data2 = new List<GameList>();
            const string url = "https://api.steampowered.com/IDOTA2Match_570/GetTopLiveGame/v1/?key=A936A9076BEB4894258B4CB51EFC4A58&partner=1";
            HttpClient client = new HttpClient();
            Encoding.GetEncoding("ISO-8859-1");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            var data = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            List<Root> locations = new List<Root> { JsonConvert.DeserializeObject<Root>(data) };
            foreach (var a in locations)
            {
                if (locations != null)
                {
                    foreach (var b in a.game_list)
                    {
                        if (b.team_name_dire != null && b.team_name_radiant != null)
                        {
                            meny_data2.Add(new GameList { activate_time = b.activate_time, average_mmr = b.average_mmr, building_state = b.building_state, deactivate_time = b.deactivate_time, delay = b.delay, dire_score = b.dire_score, game_mode = b.game_mode, game_time = b.game_time, last_update_time = b.last_update_time, league_id = b.league_id, lobby_id = b.lobby_id, lobby_type = b.lobby_type, match_id = b.match_id, players = b.players, radiant_lead = b.radiant_lead, radiant_score = b.radiant_score, series_id = b.series_id, server_steam_id = b.server_steam_id, sort_score = b.sort_score, spectators = b.spectators, team_id_dire = b.team_id_dire, team_id_radiant = b.team_id_radiant, team_logo_dire = b.team_logo_dire, team_logo_radiant = b.team_logo_radiant, team_name_dire = b.team_name_dire, team_name_radiant = b.team_name_radiant, dir_url_logo = GetTeeamLogo(b.team_logo_dire.ToString()), red_url_logo = GetTeeamLogo(b.team_logo_radiant.ToString()) });
                        }
                    }
                }
            }
            return View(meny_data2);
        }

        public string GetTeeamLogo(string id)
        {
            string url = "http://api.steampowered.com/ISteamRemoteStorage/GetUGCFileDetails/v1/?key=A936A9076BEB4894258B4CB51EFC4A58&appid=570&ugcid=" + id;
            string imgtodwld = "";
            HttpClient client = new HttpClient();
            Encoding.GetEncoding("ISO-8859-1");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            var data = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            List<RootLogo> locations = new List<RootLogo> { JsonConvert.DeserializeObject<RootLogo>(data) };
            if (locations != null)
            {
                foreach (var a in locations)
                {
                    if (a.data != null)
                    {
                        imgtodwld = a.data.url;
                    }

                    else
                    {
                        imgtodwld = "";
                    }
                }
            }
            return imgtodwld;
        }
        //test(slow loading)
        public string GetLeagueName(int id)
        {
            string result;
            string url = "https://api.steampowered.com/IDOTA2Match_205790/GetLeagueListing/v0001/?key=A936A9076BEB4894258B4CB51EFC4A58";
            HttpClient client = new HttpClient();
            Encoding.GetEncoding("ISO-8859-1");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            var data = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            List<Root3> locations = new List<Root3> { JsonConvert.DeserializeObject<Root3>(data) };
            List<LeagueName> leagues = new List<LeagueName>();
            foreach(var a in locations)
            {
                foreach(var b in a.result.leagues)
                {

                    leagues.Add(new LeagueName { leagueid = b.leagueid, name = b.name});
                }
            }

            if (leagues.Exists(item => item.leagueid == id))
            {
                result = leagues.Find(item => item.leagueid == id).name.ToString();
            }
            else
            {
                result = "Unkonwn League";
            }
            return result;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
