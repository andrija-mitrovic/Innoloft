using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class UserRequestService : IUserRequestService
    {
        IHttpClientFactory _clientFactory;

        public UserRequestService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<UserDetailDto> GetUser(int userId)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://jsonplaceholder.typicode.com/users/{userId}");
            if (response.IsSuccessStatusCode)
            {
                var userString = await response.Content.ReadAsStringAsync();
                var objectified = JsonConvert.DeserializeObject<UserDetailDto>(userString);
                return objectified;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<UserListDto>> GetUsers()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://jsonplaceholder.typicode.com/users");
            if (response.IsSuccessStatusCode)
            {
                var userString = await response.Content.ReadAsStringAsync();
                var objectified = JsonConvert.DeserializeObject<List<UserListDto>>(userString);
                return objectified;
            }
            else
            {
                return null;
            }
        }
    }
}
