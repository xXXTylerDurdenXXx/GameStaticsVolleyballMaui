using GameStaticsVolleyballMaui.Services;
using MAUIStatsApi.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameStaticsVolleyballMaui.ViewModel
{
    public class PlayerViewModel : BindableObject
    {
        private readonly PlayerService _service;

        public ObservableCollection<PlayerDto> Players { get; } = new();

        public ICommand LoadCommand { get; }
        public ICommand CreateCommand { get; }
        public ICommand SelectCommand { get; }
        public ICommand DeleteCommand { get; }

        public PlayerViewModel(PlayerService service)
        {
            _service = service;

            LoadCommand = new Command(async () => await LoadAsync());
            CreateCommand = new Command(async () => await CreateAsync());
            SelectCommand = new Command<PlayerDto>(async p => await EditAsync(p));
            DeleteCommand = new Command<PlayerDto>(async p => await DeleteAsync(p));
        }

        private async Task LoadAsync()
        {
            Players.Clear();
            var items = await _service.GetAllAsync();
            foreach (var item in items)
                Players.Add(item);
        }

        private async Task CreateAsync()
        {
            await Shell.Current.GoToAsync("///PlayerEditPage");
        }

        private async Task EditAsync(PlayerDto player)
        {
            if (player == null) return;

            await Shell.Current.GoToAsync("///PlayerEditPage", new Dictionary<string, object>
            {
                ["player"] = player
            });
        }

        private async Task DeleteAsync(PlayerDto player)
        {
            if (player == null) return;

            await _service.DeleteAsync(player.Id);
            Players.Remove(player);
        }
    }
}
