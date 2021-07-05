using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Simulator.Exceptions
{
    public class PlayerNotFoundException : Exception
    {
        public PlayerNotFoundException()
        {

        }

        public PlayerNotFoundException(string name)
            : base(String.Format("Player {0} not found.", name))
        {

        }
    }
}
