using GameStaticsVolleyballMaui.Services;
using GameStaticsVolleyballMaui.View;
using GameStaticsVolleyballMaui.ViewModel;
using Microsoft.Extensions.Logging;

namespace GameStaticsVolleyballMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<ApiClient>();

            builder.Services.AddSingleton<AuthService>();
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<PlayerService>();
            builder.Services.AddSingleton<TeamService>();
            builder.Services.AddSingleton<AuthStateService>();

            builder.Services.AddSingleton<AuthViewModel>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<RegisterPage>();

            builder.Services.AddTransient<PlayersPage>();
            builder.Services.AddTransient<PlayerEditPage>();
            builder.Services.AddTransient<PlayerEditPage>();
            builder.Services.AddTransient<PlayerEditViewModel>();
            builder.Services.AddTransient<PlayerViewModel>();

            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddTransient<TeamsPage>();
            builder.Services.AddTransient<TeamEditPage>();
            builder.Services.AddTransient<TeamEditPage>();
            builder.Services.AddTransient<TeamEditViewModel>();
            builder.Services.AddTransient<TeamViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
