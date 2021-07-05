using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Simulator.GameInfo.Warzone
{
    public sealed class Maps
    {
        public static IList<string> MapList
        {
            get
            {
                return new List<string>(new string[]
                {
                    "mp_kstenod",
                    "mp_don3"
                });
            }
        }

        public static string GetRandom()
        {
            Random rand = new Random();
            return MapList[rand.Next(MapList.Count)];
        }
    }
}
