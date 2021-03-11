using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OPG5TCP
{
    public class Server
    {
        private static List<Beer> _beers = new List<Beer>()
        {
            new Beer{Name = "Heineken",Adv = 5,ID = 1,Price = 10},
            new Beer{Name = "Carlsberg",ID = 2, Price = 11.95,Adv = 4.6}
        };

        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 4646);
            server.Start();
            Console.WriteLine("Server is running...");
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Client is connected to the server...");
                Task.Run(() =>
                {
                    TcpClient tempSocket = client;
                    DoClient(tempSocket);
                });
            }
        }

        private void DoClient(TcpClient tempSocket)
        {
            Stream ns = tempSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;
            string message = sr.ReadLine();
            while (message != " " && message != "stop")
            {
                switch (message)
                {
                    case "GetAll":
                        sw.WriteLine(JsonConvert.SerializeObject(_beers));
                        break;
                    case "Get": 
                        int id = Convert.ToInt32(sr.ReadLine());
                        sw.WriteLine(_beers.Find(beer => beer.ID == id));
                        break;
                    case "Save":
                        string json = sr.ReadLine();
                        Beer savedBeer = JsonConvert.DeserializeObject<Beer>(json);
                        _beers.Add(savedBeer);
                        break;
                }
                message = sr.ReadLine();
            }
            ns.Close();
            tempSocket.Close();
        }
    }
}