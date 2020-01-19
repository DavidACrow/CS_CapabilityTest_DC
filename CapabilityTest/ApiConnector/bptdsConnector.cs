using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using CapabilityTest.Coordinates;
using CapabilityTest.Models;
using Newtonsoft.Json;
using RestSharp;

namespace CapabilityTest.ApiConnector
{
    public class bptdsConnector : IConnector
    {
        private const string API_ADDRESS = "http://bpdts-test-app.herokuapp.com";
        private readonly RestClient _client;
        public bptdsConnector()
        {
            _client = new RestClient(API_ADDRESS);
        }
        
        /// <summary>
        /// Use coordinates city and distance to search for users who are currently from or within London
        /// </summary>
        /// <param name="city"></param>
        /// <param name="baseCoordinate"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        public List<UserModel> GetUsersWithinOrCloseToCity(string city, Coordinate baseCoordinate, float distance)
        {
            var request = new RestRequest("users", Method.GET);

            var response = _client.Execute(request);

            if ((!response.IsSuccessful))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            
            var allUsers = JsonConvert.DeserializeObject<List<UserModel>>(response.Content);

            var usersWithinCity = GetUsersWithinCity(city);

            IDistanceCalculator calculator = new DistanceInMilesCalculator();
            
            //LINQ query to pull users whose current position is within 50 miles of London, or who are listed as being from London
            //and then return as a list
            return (from user in allUsers let userCurrentLocation = new Coordinate(user.longitude, user.latitude) 
                where calculator.IsWithinDistance(distance, baseCoordinate, userCurrentLocation) ||
                      usersWithinCity.Contains(user.id) select user).ToList();
        }
        
        /// <summary>
        /// Call API to return all users located in the requested city. THis only needs to return the user IDs as a
        /// list of integers
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        private IEnumerable<int> GetUsersWithinCity(string city)
        {
            var request = new RestRequest($"city/{city}/users", Method.GET);

            var response = _client.Execute(request);
            
            if ((!response.IsSuccessful))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            
            var users = JsonConvert.DeserializeObject<List<UserModel>>(response.Content);

            return users.Select(user => user.id).ToList();
        }
    }
}