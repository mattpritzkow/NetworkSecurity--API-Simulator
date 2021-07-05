using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace API_Simulator.Generation
{
    public class WarzoneGenerator
    {
        public int NumSquads { get; set; }

        public int SquadSize { get; set; }

        public int MaxTimeBetweenGames { get; set; }

        public int MatchDuration { get; set; }

        public long TourneyStart { get; set; }

        public long TourneyDuration { get; set; }

        public int MatchesPerSquad { get; set; }

        public WarzoneGenerator()
        {
            NumSquads = 25;
            SquadSize = 4;
            MatchDuration = 1200;
            TourneyStart = 5;
            TourneyDuration = 12000;
            MaxTimeBetweenGames = 180;
            MatchesPerSquad = 8;
        }

        public Tournament Generate()
        {
            var tourney = new Tournament();
            long currentTime = (long)(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds;

            Console.WriteLine(JsonConvert.SerializeObject(this));

            tourney.GenerateSquads(SquadSize, NumSquads);
            tourney.GenerateMatches(MatchDuration, MaxTimeBetweenGames, MatchesPerSquad, TourneyStart + currentTime, TourneyDuration + TourneyStart + currentTime);

            return tourney;

        }

    }
}
