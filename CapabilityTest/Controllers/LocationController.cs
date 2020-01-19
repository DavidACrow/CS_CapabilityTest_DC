using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CapabilityTest.ApiConnector;
using CapabilityTest.Coordinates;
using CapabilityTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using Newtonsoft.Json;
namespace CapabilityTest.Controllers
{
    /// <summary>
    /// Main API controller to pull information on users from London or within 50 miles of London
    /// </summary>
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly Coordinate _londonCoordinate = new Coordinate(-0.118092f, 51.509865f);

        private readonly IConnector _apiConnector = new bptdsConnector();

        /// <summary>
        /// Demo as requested to return users listed as living in London or whose current coordinates
        /// place them within London
        /// </summary>
        /// <returns>A list of user objects</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Route("[controller]/LondonDemo")]
        public List<UserModel> Get()
        {
            return _apiConnector.GetUsersWithinOrCloseToCity("London", _londonCoordinate, 50);
        }
        
        /// <summary>
        /// Optional function to allow any city, distance and coordinates to be used
        /// </summary>
        /// <param name="city"></param>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet] 
        [Route("[controller]/GetUsersWithinOrCloseToCity")]
        public List<UserModel> Get(string city, double longitude, double latitude, float distance)
        {
            return _apiConnector.GetUsersWithinOrCloseToCity(city, new Coordinate(longitude, latitude), distance);
        }
    }
}