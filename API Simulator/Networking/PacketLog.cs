using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Simulator.Networking
{
    public class PacketLog
    {
        public int Occurences { get; set; }
        public IList<DateTime> ReceivalTime { get; set; }

        public PacketLog()
        {
            ReceivalTime = new List<DateTime>();
            Occurences = 0;
        }

        public void AddPacket(DateTime recv)
        {
            ReceivalTime.Add(recv);
            Occurences++;
        }

        public int GetNumRecentRequests(int seconds)
        {
            int recentRequests = 0;
            foreach (var request in ReceivalTime)
            {
                if (DateTime.Now < request.AddSeconds(seconds))
                {
                    recentRequests++;
                }
                
            }
            return recentRequests;
        }
    }
}
