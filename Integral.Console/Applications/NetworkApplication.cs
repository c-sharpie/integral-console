using System;
using System.Net;
using Integral.Abstractions;
using Integral.Collections;

namespace Integral.Applications
{
    public abstract class NetworkApplication : InteractiveApplication
    {
        private readonly ListedCollection<DnsEndPoint> dnsEndPoints = new ListedCollection<DnsEndPoint>();

        private readonly ListedCollection<IPEndPoint> ipEndPoints = new ListedCollection<IPEndPoint>();

        private readonly bool client = true;

        private readonly bool server = true;

        protected NetworkApplication(string[] arguments)
        {
            foreach (string argument in arguments)
            {
                switch (argument.ToLower())
                {
                    case "disable-client":
                        client = false;
                        break;
                    case "disable-server":
                        server = false;
                        break;
                    case var endPoint when endPoint.Contains(":"):
                        try
                        {
                            if (IPEndPoint.TryParse(endPoint, out IPEndPoint ipEndPoint))
                            {
                                ipEndPoints.Add(ipEndPoint);
                            }
                            else
                            {
                                string[] parts = endPoint.Split(":");
                                dnsEndPoints.Add(new DnsEndPoint(parts[0], ushort.Parse(parts[1])));
                            }
                        }
                        catch
                        {
                            Console.WriteLine($"Invalid EndPoint: {endPoint}");
                        }

                        break;
                }
            }

            if (dnsEndPoints.Count == 0)
            {
                dnsEndPoints.Add(new DnsEndPoint(DefaultAddress.ToString(), DefaultPort));
            }

            if (ipEndPoints.Count == 0)
            {
                ipEndPoints.Add(new IPEndPoint(DefaultAddress, DefaultPort));
            }
        }

        protected IPAddress DefaultAddress { get; set; } = IPAddress.Loopback;

        protected ushort DefaultPort { get; set; } = 5000;

        public override void Execute()
        {
            if (server)
            {
                ExecuteServer(ipEndPoints);
            }

            if (client)
            {
                ExecuteClient(dnsEndPoints);
            }

            base.Execute();
        }

        protected abstract void ExecuteClient(Enumerable<DnsEndPoint> endPoints);

        protected abstract void ExecuteServer(Enumerable<IPEndPoint> endPoints);
    }
}