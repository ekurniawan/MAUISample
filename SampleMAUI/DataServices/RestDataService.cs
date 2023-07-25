using System;
using System.Text.Json;
using SampleMAUI.Models;

namespace SampleMAUI.DataServices
{
	public class RestDataService : IRestDataService
	{
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RestDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ?
                "http://10.0.2.2:5072" : "http://localhost:5072";
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

        }

        public Task AddToDoAsync(ToDo toDo)
        {
            throw new NotImplementedException();
        }

        public Task DeleteToDoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ToDo>> GetAllToDosAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateToDoAsync(ToDo toDo)
        {
            throw new NotImplementedException();
        }
    }
}

