using System;

namespace LoggingKata
{

    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
           

            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                logger.LogError("Array length is less than 3");
                return null;
            }

            var latitude = double.Parse(cells[0]);

            var longitude = double.Parse(cells[1]);

            var locationName = cells[2];

            var pointObject = new Point();
            pointObject.Latitude = latitude;
            pointObject.Longitude = longitude;

            var ourTacoBell = new TacoBell();
            ourTacoBell.Name = locationName;
            ourTacoBell.Location = pointObject;

            return ourTacoBell;



        }
    }
}
