using GameStaticsVolleyballMaui.Services;
using MAUIStatsApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameStaticsVolleyballMaui.ViewModel
{
    public class PlayerEditViewModel : BindableObject
    {
        private readonly PlayerService _service;

        private int _id;
        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        private string _fullName;
        public string FullName
        {
            get => _fullName;
            set { _fullName = value; OnPropertyChanged(); }
        }

        private int _number;
        public int Number
        {
            get => _number;
            set { _number = value; OnPropertyChanged(); }
        }

        private int _height;
        public int Height
        {
            get => _height;
            set { _height = value; OnPropertyChanged(); }
        }

        private int _width;
        public int Width
        {
            get => _width;
            set { _width = value; OnPropertyChanged(); }
        }

        private string _teamName;
        public string TeamName
        {
            get => _teamName;
            set { _teamName = value; OnPropertyChanged(); }
        }

        private string _positionName;
        public string PositionName
        {
            get => _positionName;
            set { _positionName = value; OnPropertyChanged(); }
        }

        public ICommand SaveCommand { get; }
        public ICommand BackCommand { get; }

        public PlayerEditViewModel(PlayerService service)
        {
            _service = service;

            SaveCommand = new Command(async () => await SaveAsync());
            BackCommand = new Command(async () => await BackAsync());
        }

        public async Task LoadAsync(PlayerDto player)
        {
            if (player == null) return;

            Id = player.Id;
            FullName = player.FullName;
            Number = player.Number;
            Height = player.Height;
            Width = player.Width;
            TeamName = player.TeamName;
            PositionName = player.PositionName;
        }

        private async Task SaveAsync()
        {
            if (string.IsNullOrWhiteSpace(FullName))
                return;

            var dto = new PlayerDto
            {
                Id = Id,
                FullName = FullName,
                Number = Number,
                Height = Height,
                Width = Width,
                TeamName = TeamName,
                PositionName = PositionName
            };

            if (Id == 0)
                await _service.CreateAsync(dto);
            else
                await _service.UpdateAsync(dto);

            await BackAsync();
        }

        private async Task BackAsync()
        {
            await Shell.Current.GoToAsync("///PlayersPage");
        }
    }
}
