
using GameStaticsVolleyballMaui.Models;
using GameStaticsVolleyballMaui.ViewModel;
using MAUIStatsApi.DTO;

namespace GameStaticsVolleyballMaui.View;

[QueryProperty(nameof(Player), "player")]
public partial class PlayerEditPage : ContentPage
{
    private readonly PlayerEditViewModel _viewModel;

    public PlayerEditPage(PlayerEditViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
    private PlayerDto _player;
    public PlayerDto Player
    {
        get => _player;
        set
        {
            _player = value;
            _ = _viewModel.LoadAsync(value);
        }
    }
}