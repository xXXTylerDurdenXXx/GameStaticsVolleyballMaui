using MAUIStatsApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GameStaticsVolleyballMaui.Services
{
    public class PlayerService
    {
        private readonly ApiClient _api;

        public PlayerService(ApiClient api)
        {
            _api = api;
        }

        public async Task<List<PlayerDto>> GetAllAsync()
        {
            return await _api.Client
                .GetFromJsonAsync<List<PlayerDto>>("api/player");
        }

        public async Task<PlayerDto> GetByIdAsync(int id)
        {
            return await _api.Client
                .GetFromJsonAsync<PlayerDto>($"api/player/{id}");
        }

        public async Task<PlayerDto> CreateAsync(PlayerDto dto)
        {
            var response = await _api.Client
                .PostAsJsonAsync("api/player", dto);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content
                .ReadFromJsonAsync<PlayerDto>();
        }

        public async Task<PlayerDto> UpdateAsync(PlayerDto dto)
        {
            var response = await _api.Client
                .PutAsJsonAsync($"api/player/{dto.Id}", dto);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content
                .ReadFromJsonAsync<PlayerDto>();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _api.Client
                .DeleteAsync($"api/player/{id}");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Ошибка удаления игрока");
        }
    }
}
