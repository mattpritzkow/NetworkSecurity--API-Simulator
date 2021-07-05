using API_Simulator.Exceptions;
using API_Simulator.TournamentData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Simulator
{
    public class Tournament
    {
		public IList<Squad> Squads { get; set; }

        public Tournament()
        {
            Squads = new List<Squad>();
        }

        public void GenerateSquads(int squadSize, int numTeams)
        {
            //Grab instance of IdGen to define each player in team
            PlayerIdGen playerIdGen = PlayerIdGen.Instance;
            for (var i = 0; i < numTeams; i++)
            {
                var players = new List<Tuple<int, string>>();
                for (var _ = 0; _ < squadSize; _++)
                {
                    players.Add(playerIdGen.GetNewPlayerInfo());
                }
                var squad = new Squad(i);
                squad.AddPlayers(players);
                Squads.Add(squad);
            }
        }

        //TODO: Make match time non-standard
        //TOOD: Allow adding match to specific squad
        /// <summary>
        /// Generates list set number of matches for each player in tournament.
        /// </summary>
        /// <param name="matchDuration">Represents amount of time for each users' game, in seconds.</param>
        /// <param name="timeBetweenGames">Time user takes between games, in seconds.</param>
        /// <param name="matchesPerSquad">How many matches each squad will play.</param>
        /// <param name="tournamentStart">UTC time in seconds the tounament starts.</param>
        /// <param name="tournamentEnd">UTC time in seconds the tournament will end.</param>
        public void GenerateMatches(int matchDuration, int timeBetweenGames, int matchesPerSquad, long tournamentStart, long tournamentEnd)
        {
            long utcTime = tournamentStart;
            Random random = new Random();
            foreach (int _ in Enumerable.Range(0, matchesPerSquad))
            {
                long end = utcTime + matchDuration;
                foreach (var squad in Squads)
                {
                    squad.AddMatch(utcTime, end, random);
                }
                utcTime += (matchDuration + timeBetweenGames);
            }
        }

        public string GetPlayerDataJSON(string targetPlayer, string authKey)
        {
            foreach (var squad in Squads)
            {
                    Player player = squad.GetPlayer(targetPlayer);
                    if (player != null && player.Uno == authKey)
                    {
                        return player.GetJSONData();
                    }
            }

            return "Error - Player not found and/or Incorrect AuthKey provided";
        }
    }
}
