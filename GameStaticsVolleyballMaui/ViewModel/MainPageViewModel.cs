using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameStaticsVolleyballMaui.ViewModel
{

    public class MainPageViewModel: BindableObject
    {
        public ICommand OpenPlayersCommand { get; }
        public ICommand OpenTeamsCommand { get; }

        public MainPageViewModel()
        {

            OpenPlayersCommand = new Command(async () =>
                await Shell.Current.GoToAsync("///PlayersPage"));

            OpenTeamsCommand = new Command(async () =>
                await Shell.Current.GoToAsync("///TeamsPage"));
        }
    }
}
