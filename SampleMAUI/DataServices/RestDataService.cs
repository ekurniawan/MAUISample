using System;
using System.Diagnostics;
using System.Text;
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

        public async Task AddToDoAsync(ToDo toDo)
        {
            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet access");
                return;
            }

            try
            {
                string jsonToDo = JsonSerializer.Serialize<ToDo>(toDo, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonToDo, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/todo", content);
                if(response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("berhasil menambahkan todo");
                }
                else
                {
                    Debug.WriteLine("gagal tambah todo");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Kesalahan: {ex.Message}");
            }
            return;
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

