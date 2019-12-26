using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ServerSideExample.AssetEntry;

namespace ServerSideExample
{
    class ServerMain
    {
        private static readonly string NewLine = "\r\n";//program format
        static void WriteLineUtf8(string data, Stream stream)
        {
            var chs = (data + NewLine).ToCharArray();
            var bytes = Encoding.UTF8.GetBytes(chs);
            stream.Write(bytes, 0, bytes.Length);

        }

        static void Main(string[] args)
        {
            var rnd = new Random();
            Int32 port = 9999;//To match exercise port
            try
            {
                var server = new TcpListener(IPAddress.Any, port);//create server
                server.Start();
                using (var client = server.AcceptTcpClient())
                using (var stream = client.GetStream())
                {
                    while (true)
                    {
                        WriteLineUtf8(Gen(AssetNames[rnd.Next(AssetNames.Length)], rnd).AsString(), stream);
                        Console.Write(Gen(AssetNames[rnd.Next(AssetNames.Length)], rnd).AsString() + NewLine); // ECHO
                        Thread.Sleep(200);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
            }
        }
    }
}
