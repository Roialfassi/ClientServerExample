using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSideExample
{
    public struct AssetEntry
    {
        public string AssetName { get; }
        public DateTime DateTime { get; }
        public double BidPrice { get; }
        public double AskPrice { get; }

        public AssetEntry(string assetName, DateTime dateTime, double bidPrice, double askPrice)
        {
            AssetName = assetName;
            DateTime = dateTime;
            BidPrice = bidPrice;
            AskPrice = askPrice;
        }

        public static AssetEntry Gen(string name, Random rnd)//Creating Entry
        {
            var year = 2019;
            var month = rnd.Next(1, 13);
            var day = rnd.Next(1, 28);
            var hour = rnd.Next(1, 23);
            var min = rnd.Next(60);
            var sec = rnd.Next(60);
            var time = new DateTime(year, month, day, hour, min, sec);
            return new AssetEntry(name, time, rnd.NextDouble(), rnd.NextDouble());
        }

        public static readonly string[] AssetNames = new[] { "Teva", "Perigo", "Isramco", "OpkoHealth" };//Stocks

        public string AsString()
        {
            var dateString = DateTime.ToString().Replace(" ", "-");
            var bidString = BidPrice.ToString("0.00000");
            var askString = AskPrice.ToString("0.00000");
            return $"{AssetName} {dateString} {bidString} {askString}";
        }
    }
}
