using PlayAroundConsole.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayAroundConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var d365Connect = new Dynamics365Connect();
            d365Connect.Connect();
        }
    }
}
