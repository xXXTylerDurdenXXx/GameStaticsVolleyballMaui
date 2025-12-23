using GameStaticsVolleyballMaui.DTO;
using GameStaticsVolleyballMaui.ViewModel;
using GameStatisticsVolleball.Models;

namespace GameStaticsVolleyballMaui.View;

[QueryProperty(nameof(Team), "team")]
public partial class TeamEditPage : ContentPage
{
    private readonly TeamEditViewModel _viewModel;
    public TeamEditPage(TeamEditViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
    private TeamDto _team;
    public TeamDto Team
    {
        get => _team;
        set
        {
            _team = value;
            _ = _viewModel.LoadAsync(value);
        }
    }
}