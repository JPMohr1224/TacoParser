using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {



            var lines = File.ReadAllLines(csvPath);

            if (lines.Length == 0)
            {
                logger.LogError("No data returned");
            }
            if (lines.Length == 1)
            {
                logger.LogWarning("Only partial data returned");
            }

         

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable tacobell1 = null;
            ITrackable tacobell2 = null;

            double distance = 0;

            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];

                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);

                for (int a = 0; a < locations.Length; a++)
                {
                    var locB = locations[a];
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    double newDistance = corA.GetDistanceTo(corB);
                    if (newDistance > distance)
                    {
                        distance = newDistance;
                        tacobell1 = locA;
                        tacobell2 = locB;
                    }
                }
            }

            Console.WriteLine($"The two Taco Bells farthest apart are {tacobell1.Name} and {tacobell2.Name}.");


        }
    }
}
