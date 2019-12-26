using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ClientSideGrid
{
    class ClientSide
    {

        static void Main(string[] args)
        {
            Dictionary<String, DateEntry> itemsByName = new Dictionary<string, DateEntry>();
            string line = "";
            DateEntry parsedItem;

            using (var client = new TcpClient("127.0.0.1", 9999))   // Server

            using (var stream = client.GetStream()) // Closes everything safely in the end
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8)) 
            while (true)
                {
                    try
                    {
                        line = reader.ReadLine();
                        Console.WriteLine(line);//Checking what we get from server

                        parsedItem = DateEntry.ParseLine(line);
                        if (itemsByName.ContainsKey(parsedItem.assetName))
                            itemsByName.Remove(parsedItem.assetName);
                        itemsByName.Add(parsedItem.assetName, parsedItem);

                        DateEntry.PrintGrid(itemsByName);
                    }
                    catch
                    { }
                }
        }
    }
}
