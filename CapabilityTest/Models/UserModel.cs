using System;

namespace CapabilityTest.Models
{
    /// <summary>
    /// Model to match the JSON object recieved from the API
    /// </summary>
    public struct UserModel
    {
        public int id { get; set; } 
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string ip_address { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
    }
}