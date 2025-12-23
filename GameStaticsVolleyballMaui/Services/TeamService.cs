using GameStaticsVolleyballMaui.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GameStaticsVolleyballMaui.Services
{
    public class TeamService
    {
        private readonly ApiClient _api;

        public TeamService(ApiClient api)
        {
            _api = api;
        }

        public async Task<List<TeamDto>> GetAllAsync()
        {
            return await _api.Client
                .GetFromJsonAsync<List<TeamDto>>("api/team");
        }

        public async Task<TeamDto> GetByIdAsync(int id)
        {
            return await _api.Client
                .GetFromJsonAsync<TeamDto>($"api/team/{id}");
        }

        public async Task<TeamDto> CreateAsync(TeamDto dto)
        {
            var response = await _api.Client
                .PostAsJsonAsync("api/team", dto);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content
                .ReadFromJsonAsync<TeamDto>();
        }

        public async Task<TeamDto> UpdateAsync(TeamDto dto)
        {
            var response = await _api.Client
                .PutAsJsonAsync($"api/team/{dto.Id}", dto);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content
                .ReadFromJsonAsync<TeamDto>();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _api.Client
                .DeleteAsync($"api/team/{id}");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Ошибка удаления команды");
        }
    }
}
