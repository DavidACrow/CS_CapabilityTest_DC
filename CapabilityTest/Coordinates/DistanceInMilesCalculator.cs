using System;

namespace CapabilityTest.Coordinates
{
    /// <summary>
    /// Calculate distance between two map coordinates in Miles using the haversine formula
    /// </summary>
    public class DistanceInMilesCalculator : IDistanceCalculator
    {
        private const double AVERAGE_SIZE_OF_PLANET_KM = 6378.16;
        private const double MILES_MULTIPLIER = 0.621371;
        
        /// <summary>
        /// Returns a bool - if the user coordinate is within the requested distance of the location coordinate
        /// </summary>
        /// <param name="maxDistance"></param>
        /// <param name="locationCoordinate"></param>
        /// <param name="userCoordinate"></param>
        /// <returns>boolean flag</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public bool IsWithinDistance(float maxDistance, Coordinate locationCoordinate, Coordinate userCoordinate)
        {
            if (locationCoordinate == null || userCoordinate == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            var calculatedDistance = GetDistance( locationCoordinate, userCoordinate);

            return calculatedDistance <= maxDistance;
        }
        
        /// <summary>
        /// Calculates the distance between two coordinates in miles using haversine formula
        /// </summary>
        /// <param name="locationCoordinate"></param>
        /// <param name="userCoordinate"></param>
        /// <returns>distance as double in miles</returns>
        public double GetDistance(Coordinate locationCoordinate, Coordinate userCoordinate)
        {
            var longitudeDistance = locationCoordinate.GetLongitudeDistanceComparisonInRad(userCoordinate);
            var latitudeDistance = locationCoordinate.GetLatitudeDistanceComparisonInRad(userCoordinate);
            
            //using haversine formula which has a 0.5% margin for error to calculate distance of two sets of coordinates
            //a = sin²(ΔlatDifference/2) + cos(lat1).cos(lt2).sin²(ΔlonDifference/2)
            //c = 2.atan2(√a, √(1−a))
            //d = R.c
            
            var haversineValueA = (Math.Sin(latitudeDistance / 2) * Math.Sin(latitudeDistance / 2)) +
                                  Math.Cos(locationCoordinate.GetLatitudeInRad()) * Math.Cos(locationCoordinate.GetLatitudeInRad()) *
                                  Math.Sin(longitudeDistance / 2) * Math.Sin(longitudeDistance / 2);

            var haversineValueB = 2 * Math.Atan2(Math.Sqrt(haversineValueA), Math.Sqrt(1 - haversineValueA));

            var haversineDistance = (AVERAGE_SIZE_OF_PLANET_KM * haversineValueB) * MILES_MULTIPLIER;

            return haversineDistance;
        }
    }
}