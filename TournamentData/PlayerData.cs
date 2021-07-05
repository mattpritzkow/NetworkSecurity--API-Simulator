using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Simulator.TournamentData
{
    public class PlayerData
    {
        //What does this refer to in game?
        public string Team { get; set; }
        //Important for scoring?
        public int Rank
        {
            get
            {
                return -1;
            }
        }
        public IList<string> Awards { get; set; }
        public string Username { get; set; }
        public string Uno { get; set; }
        public string Clantag
        {
            get
            {
                return "Clantag";
            }
        }
        //Is this important?
        public string BrMissionStats { get; set; }

        public PlayerData(string username, string team, string uno)
        {
            Username = username;
            Team = team;
            Uno = uno;
        }

    }
}
