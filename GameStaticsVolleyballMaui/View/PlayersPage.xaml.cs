using GameStaticsVolleyballMaui.ViewModel;

namespace GameStaticsVolleyballMaui.View;

public partial class PlayersPage : ContentPage
{
    public PlayersPage(PlayerViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as PlayerViewModel)?.LoadCommand.Execute(null);
    }
}