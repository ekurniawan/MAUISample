using System;
using System.Diagnostics;
using System.Text.Json;
using SampleMAUI.Models;

namespace SampleMAUI.DataServices
{
	public class RestDataService : IRestDataService
	{
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RestDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ?
                "http://10.0.2.2:5072" : "http://localhost:5072";
            _url = $"{_baseAddress}/api";
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

        public async Task<List<ToDo>> GetAllToDosAsync()
        {
            List<ToDo> toDos = new List<ToDo>();
            if(Connectivity.Current.NetworkAccess!=NetworkAccess.Internet)
            {
                Debug.WriteLine("Tidak ada koneksi Internet...");
                return toDos;
            }
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/todo");
                if(response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    toDos = JsonSerializer.Deserialize<List<ToDo>>(content, _jsonSerializerOptions);
                }
                else
                {
                    Debug.WriteLine("--> Kesalahan bukan 200 status");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Kesalahan {ex.Message}");
            }
            return toDos;
        }

        public Task UpdateToDoAsync(ToDo toDo)
        {
            throw new NotImplementedException();
        }
    }
}

