using API_Simulator.GameInfo.Warzone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Simulator.TournamentData
{
    public class Match
    {
        public long UTCStart { get; set; }
        public long UTCEnd { get; set; }
        public string Map { get; set; }
        public string Mode { get; set; }
        public string MatchID
        {
            get
            {
                return "18164626024821554661";
            }
        }
        public long Duration
        {
            get
            {
                return UTCEnd - UTCStart;
            }
        }
        public string PlaylistName
        {
            get
            {
                return null;
            }
        }
        public int Version
        {
            get
            {
                return 1;
            }
        }
        public string GameType
        {
            get
            {
                return "wz";
            }
        }
        public int PlayerCount
        {
            get
            {
                return 150;
            }
        }
        public PlayerStats PlayerStats { get; set; }
        public PlayerData PlayerData { get; set; }
        public int TeamCount
        {
            get
            {
                return 50;
            }
        }
        public string RankedTeams
        {
            get
            {
                return null;
            }
        }
        public bool Draw
        {
            get
            {
                return false;
            }
        }
        //Potentially make this return true 5% of the time in future?
        public bool PrivateMatch
        {
            get
            {
                return false;
            }
        }

        public Match(long utcStart, long utcEnd, string playerName, string team, string uno, Random random)
        {
            PlayerStats = new PlayerStats(random);
            PlayerData = new PlayerData(playerName, team, uno);
            UTCStart = utcStart;
            UTCEnd = utcEnd;
            Map = Maps.GetRandom();
            Mode = Modes.GetRandom();
        }

    }
}
