namespace CapabilityTest.Coordinates
{
    public interface IDistanceCalculator
    {
        bool IsWithinDistance(float maxDistance, Coordinate coordinateA, Coordinate coordinateB);
        double GetDistance(Coordinate locationCoordinate, Coordinate userCoordinate);
    }
}