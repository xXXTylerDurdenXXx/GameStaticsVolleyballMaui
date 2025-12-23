using GameStaticsVolleyballMaui.DTO;
using GameStaticsVolleyballMaui.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameStaticsVolleyballMaui.ViewModel
{
    public class TeamEditViewModel : BindableObject
    {
        private readonly TeamService _service;

        private int _id;
        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        private string _coachName;
        public string CoachName
        {
            get => _coachName;
            set { _coachName = value; OnPropertyChanged(); }
        }

        private string _city;
        public string City
        {
            get => _city;
            set { _city = value; OnPropertyChanged(); }
        }

        public ICommand SaveCommand { get; }
        public ICommand BackCommand { get; }

        public TeamEditViewModel(TeamService service)
        {
            _service = service;

            SaveCommand = new Command(async () => await SaveAsync());
            BackCommand = new Command(async () => await BackAsync());
        }

        public async Task LoadAsync(TeamDto team)
        {
            if (team == null) return;

            Id = team.Id;
            Name = team.Name;
            CoachName = team.CoachName;
            City = team.City;
        }

        private async Task SaveAsync()
        {
            if (string.IsNullOrWhiteSpace(Name))
                return;

            var dto = new TeamDto
            {
                Id = Id,
                Name = Name,
                CoachName = CoachName,
                City = City
            };

            if (Id == 0)
                await _service.CreateAsync(dto);
            else
                await _service.UpdateAsync(dto);

            await BackAsync();
        }

        private async Task BackAsync()
        {
            await Shell.Current.GoToAsync("///TeamsPage");
        }
    }
}
