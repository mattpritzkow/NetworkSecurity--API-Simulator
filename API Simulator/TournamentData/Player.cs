using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Simulator.TournamentData
{
    public class Player
    {
        public IList<Match> Matches { get; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Uno { get; set; }
        [JsonIgnore]
        public string Team { get; set; }

        public Player(string username, string uno, string team)
        {
            Matches = new List<Match>();
            Username = username;
            Uno = uno;
            Team = team;
        }

        public void AddMatch(long utcStart, long utcEnd, Random random)
        {
            if (utcStart > utcEnd)
            {
                throw new ArgumentException("End time must be later than start time.");
            }
            Matches.Add(new Match(utcStart, utcEnd, Username, Team, Uno, random));
        }

        public string GetJSONData()
        {
            long currentTime = (long)(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds;
            Player tempInstance = new Player(Username, Uno, Team);
            foreach (var match in Matches)
            {
                if (match.UTCEnd < currentTime) {
                    tempInstance.Matches.Add(match);
                }
            }

            Console.WriteLine(this.Matches.Count);
            Console.WriteLine(tempInstance.Matches.Count);

            return JsonConvert.SerializeObject(tempInstance);
        }

    }
}
