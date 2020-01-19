using System;

namespace CapabilityTest.Coordinates
{
    /// <summary>
    /// Class to hold longitude and latitude of a location, while allowing to convert to radeons
    /// </summary>
    public class Coordinate
    {
        private readonly double _longitude;
        public double Longitude()
        {
            return _longitude;
        }
        
        private readonly double _latitude;
        public double Latitude()
        {
            return _latitude;
        }
        
        
        public Coordinate(double longitude, double latitude)
        {
            this._longitude = longitude;
            this._latitude = latitude;
        }

        public double GetLatitudeInRad()
        {
            return DegreeToRad(Latitude());
        }

        public double GetLongitudeInRad()
        {
            return DegreeToRad(Longitude());
        }

        public double GetLatitudeDistanceComparisonInRad(Coordinate comparisonCoordinate)
        {
            return DegreeToRad(Latitude() - comparisonCoordinate.Latitude());
        }
        
        public double GetLongitudeDistanceComparisonInRad(Coordinate comparisonCoordinate)
        {
            return  DegreeToRad(Longitude() - comparisonCoordinate.Longitude());
        }
        
        private static double DegreeToRad(double degree)
        {
            return (Math.PI / 180) * (degree);
        }
    }
}