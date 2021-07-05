using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Simulator.GameInfo.Warzone
{
    public sealed class Modes
    {
        public static IList<string> ModeList
        {
            get
            {
                return new List<string>(new string[]
                {
                    "br_zxp_zmbroy",
                    "br_brduos"
                });
            }
        }

        public static string GetRandom()
        {
            Random rand = new Random();
            return ModeList[rand.Next(ModeList.Count)];
        }
    }
}
