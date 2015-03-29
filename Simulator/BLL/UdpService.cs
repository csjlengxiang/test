using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    class UdpService
    {
        UdpClient udp;
        IPEndPoint sendHost;
        public UdpService(string localIP, string localPort, string sendIP, string sendPort)
        {
            udp = new UdpClient(new IPEndPoint(IPAddress.Parse(localIP), Convert.ToInt32(localPort)));

            sendHost = new IPEndPoint(IPAddress.Parse(sendIP), Convert.ToInt32(sendPort));

            ThreadPool.QueueUserWorkItem(new WaitCallback((m) =>
                {
                    IPEndPoint from = null;
                    while (true)
                    {
                        byte[] b = udp.Receive(ref from);
                        string str = Encoding.UTF8.GetString(b, 0, b.Length);

                    }
                }
            ));
        }
        public void Send(string msg)
        {
            byte[] b = Encoding.UTF8.GetBytes(msg);
            udp.Send(b, b.Length, sendHost);
        }

    }
}
