using GameStaticsVolleyballMaui.DTO;
using GameStaticsVolleyballMaui.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameStaticsVolleyballMaui.ViewModel
{
    public class TeamViewModel : BindableObject
    {
        private readonly TeamService _service;

        public ObservableCollection<TeamDto> Teams { get; } = new();

        public ICommand LoadCommand { get; }
        public ICommand CreateCommand { get; }
        public ICommand SelectCommand { get; }
        public ICommand DeleteCommand { get; }

        public TeamViewModel(TeamService service)
        {
            _service = service;

            LoadCommand = new Command(async () => await LoadAsync());
            CreateCommand = new Command(async () => await CreateAsync());
            SelectCommand = new Command<TeamDto>(async t => await EditAsync(t));
            DeleteCommand = new Command<TeamDto>(async t => await DeleteAsync(t));
        }

        private async Task LoadAsync()
        {
            Teams.Clear();
            var items = await _service.GetAllAsync();
            foreach (var item in items)
                Teams.Add(item);
        }

        private async Task CreateAsync()
        {
            await Shell.Current.GoToAsync("///TeamEditPage");
        }

        private async Task EditAsync(TeamDto team)
        {
            if (team == null) return;

            await Shell.Current.GoToAsync("///TeamEditPage", new Dictionary<string, object>
            {
                ["team"] = team
            });
        }

        private async Task DeleteAsync(TeamDto team)
        {
            if (team == null) return;

            await _service.DeleteAsync(team.Id);
            Teams.Remove(team);
        }
    }
}
