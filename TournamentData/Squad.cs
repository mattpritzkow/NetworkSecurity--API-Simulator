using API_Simulator.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Simulator.TournamentData
{
    public class Squad
    {
        public IList<Player> Players { get; }
        public int SquadNumber { get; }

        public Squad(int squadNumber)
        {
            Players = new List<Player>();
            SquadNumber = squadNumber;
        }

        public void AddPlayers(IList<Tuple<int, string>> players)
        {
            foreach (var player in players)
            {
                Players.Add(new Player(player.Item2, player.Item1.ToString(), SquadNumber.ToString()));
            }
        }

        public void AddMatch(long utcStart, long utcEnd, Random random)
        {
            foreach (var player in Players)
            {
                player.AddMatch(utcStart, utcEnd, random);
            }
        }

        public Player GetPlayer(string username)
        {
            foreach (var player in Players)
            {
                if (player.Username.Equals(username))
                {
                    Console.WriteLine("player found");
                    return player;
                }
            }

            return null;
            
        }
    }
}
