using System;
using NUnit.Framework;
using CapabilityTest;
using CapabilityTest.Coordinates;

namespace CapabilityTest_UnitTests
{
    //comparing tests against https://www.geodatasource.com/distance-calculator
    public class DistanceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Within11Miles()
        {
            IDistanceCalculator calculator = new DistanceInMilesCalculator();

            var baseLocation = new Coordinate( -0.118092f, 51.509865f);
            
            var userLocation = new Coordinate(-0.374243f, 51.502539f);

            var value = calculator.GetDistance( baseLocation, userLocation);

            Assert.AreEqual(11.0, value, 0.5f);
        }
        
        [Test]
        public void Within21Miles()
        {
            IDistanceCalculator calculator = new DistanceInMilesCalculator();

            var baseLocation = new Coordinate( -0.118092f, 51.509865f);
            
            var userLocation = new Coordinate(0.423114f, 51.438095f);

            var value = calculator.GetDistance(baseLocation, userLocation);
            
            Assert.AreEqual(23.8, value, 0.5f);
        }
        
        [Test]
        public void Within37Miles()
        {
            IDistanceCalculator calculator = new DistanceInMilesCalculator();

            var baseLocation = new Coordinate( -0.118092f, 51.509865f);
            
            var userLocation = new Coordinate(0.219620f, 52.016023f);

            var value = calculator.GetDistance(baseLocation, userLocation);
            
            Assert.AreEqual(37.8, value, 0.5f);
        }
        
        [Test]
        public void Within230Miles()
        {
            IDistanceCalculator calculator = new DistanceInMilesCalculator();

            var baseLocation = new Coordinate( -0.118092f, 51.509865f);
            
            var userLocation = new Coordinate(0.380950f, 54.887292f);

            var value = calculator.GetDistance(baseLocation, userLocation);
            
            Assert.AreEqual(234.2, value, 0.5f);
        }
    }
}