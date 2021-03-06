﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using BlazorRScard.Models;

namespace BlazorRScard.Client.Services
{
    public class ApiService : IApiService
    {
        public HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Experience>> GetExperiencesAsync(int pageIndex, int pageSize)
        {
            var response = await _httpClient.GetAsync("Experience/?pageIndex=" + pageIndex + "&pageSize=" + pageSize);
            response.EnsureSuccessStatusCode();

            using var responseContent = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return await JsonSerializer.DeserializeAsync<List<Experience>>(responseContent, options);
        }
    }
}
