using System;
using System.Net.Security;

namespace OPG5TCP
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start();
        }
    }
}
