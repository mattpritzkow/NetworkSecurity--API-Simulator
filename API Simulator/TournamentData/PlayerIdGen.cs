using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Simulator.TournamentData
{
    public sealed class PlayerIdGen
    {
        private static readonly Lazy<PlayerIdGen>
            lazy = new Lazy<PlayerIdGen>
            (() => new PlayerIdGen());

        private string BasePlayerId { get; set; } = "Player";

        private int CurrentId { get; set; } = 0;

        private int CurrentUid { get; set; }

        private Random Rand { get; set; }

        public static PlayerIdGen Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private PlayerIdGen()
        {
            Rand = new Random();
        }

        public Tuple<int, string> GetNewPlayerInfo()
        {
            CurrentId++;
            CurrentUid = Rand.Next(0, int.MaxValue);
            return new Tuple<int, string>(CurrentUid, $"{BasePlayerId}{CurrentId}");
        }
        
    }
}
