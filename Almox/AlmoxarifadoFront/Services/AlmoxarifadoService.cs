using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using AlmoxarifadoModel;

namespace AlmoxarifadoFront.Services
{
    public class AlmoxarifadoService
    {
        private readonly HttpClient _httpClient;

        public AlmoxarifadoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Almoxarifado>> GetItems()
        {
            return await _httpClient.GetFromJsonAsync<List<Almoxarifado>>("api/almoxarifado");
        }

        public async Task<Almoxarifado> GetItemById(string id)
        {
            return await _httpClient.GetFromJsonAsync<Almoxarifado>($"api/almoxarifado/{id}");
        }

        public async Task AddItem(Almoxarifado obj)
        {
            await _httpClient.PostAsJsonAsync("api/almoxarifado", obj);
        }

        public async Task UpdateItem(Almoxarifado obj)
        {
            await _httpClient.PutAsJsonAsync($"api/almoxarifado/{obj.Id}", obj);
        }

        public async Task DeleteItem(string id)
        {
            await _httpClient.DeleteAsync($"api/almoxarifado/{id}");
        }
    }
}