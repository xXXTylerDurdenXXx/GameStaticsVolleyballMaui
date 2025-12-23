using GameStaticsVolleyballMaui.ViewModel;

namespace GameStaticsVolleyballMaui.View;

public partial class TeamsPage : ContentPage
{
	public TeamsPage(TeamViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as TeamViewModel)?.LoadCommand.Execute(null);
    }
}