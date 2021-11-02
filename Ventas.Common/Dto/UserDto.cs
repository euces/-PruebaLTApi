using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Common.Dto
{
    [JsonObject(Title = "userDto")]
    public class UserDto
    {
        [JsonProperty(PropertyName = "id")]
        public decimal Id { get; set; }
        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "rollId")]
        public int RollId { get; set; }
        [JsonProperty(PropertyName = "statusId")]
        public int StatusId { get; set; }
        [JsonProperty(PropertyName = "passwordDefault")]
        public string PasswordDefault { get; set; }

        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
    }
}
