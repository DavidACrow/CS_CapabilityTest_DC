using System.Collections.Generic;
using CapabilityTest.Coordinates;
using CapabilityTest.Models;

namespace CapabilityTest.ApiConnector
{
    public interface IConnector
    {
        List<UserModel> GetUsersWithinOrCloseToCity(string city, Coordinate baseCoordinate, float distance);
    }
}