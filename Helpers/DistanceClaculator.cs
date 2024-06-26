using DevUpLink.Constants;

namespace DevUpLink.Helpers
{

    public class DistanceClaculator
    {

        public static double CalculateDistance(double startLatitude, double startLongitude, double endLatitude, double endLongitude)
        {
            // Convert degrees to radians
            startLatitude = RadianCalculator.DegreesToRadians(startLatitude);
            startLongitude = RadianCalculator.DegreesToRadians(startLongitude);
            endLatitude = RadianCalculator.DegreesToRadians(endLatitude);
            endLongitude = RadianCalculator.DegreesToRadians(endLongitude);

            double deltaLon = endLongitude - startLongitude;
            double centralAngle = Math.Acos(Math.Sin(startLatitude) * Math.Sin(endLatitude) +
              Math.Cos(startLatitude) * Math.Cos(endLatitude) * Math.Cos(deltaLon));

            // Calculate the distance
            return GlobalConstants.EarthRadiusKm * centralAngle;
        }

    }
}