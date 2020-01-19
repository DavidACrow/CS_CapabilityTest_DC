using System;
using NUnit.Framework;
using CapabilityTest;
using CapabilityTest.Coordinates;

namespace CapabilityTest_UnitTests
{
    //comparing tests against googles angle to radeon calculator
    public class CoordinateTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CoordinateLatitudeTest()
        {
            var userLocation = new Coordinate(-0.374243, 51.502539);

            var latitudeAsRad = userLocation.GetLatitudeInRad();

            Assert.AreEqual(0.898888878685, latitudeAsRad, 0.00001);
        }
        
        [Test]
        public void CoordinateLongitudeTest()
        {
            var userLocation = new Coordinate(-0.374243, 51.502539);

            var longitudeAsRad = userLocation.GetLongitudeInRad();

            Assert.AreEqual(-0.0065317725525, longitudeAsRad, 0.00001);
        }
        
        [Test]
        public void CoordinateLongitudeComparisonTest()
        {
            var locationA = new Coordinate( -0.118092, 51.509865);
            
            var locationB = new Coordinate(-0.374243, 51.502539);
            
            var longitudeAsRad = locationA.GetLongitudeDistanceComparisonInRad(locationB);

            Assert.AreEqual(0.0044706781703780004017, longitudeAsRad, 0.00001);
        }
        
        [Test]
        public void CoordinateLatitudeComparisonTest()
        {
            var locationA = new Coordinate( -0.118092, 51.509865);
            
            var locationB = new Coordinate(-0.374243, 51.502539);
            
            var longitudeAsRad = locationA.GetLatitudeDistanceComparisonInRad(locationB);

            Assert.AreEqual(0.0001278317323234863, longitudeAsRad, 0.00001);
        }
    }
}