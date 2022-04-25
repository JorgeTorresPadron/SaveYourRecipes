using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SaveYourRecipes.Features.AcercaDe
{
    public class AcercaDeViewModel
    {
        public AcercaDeViewModel()
        {
            TapGitHubCommand = new Command<string>(async (url) => await Launcher.OpenAsync(url));
            TapXamarinCommand = new Command<string>(async (url) => await Launcher.OpenAsync(url));
            TapSQLiteCommand = new Command<string>(async (url) => await Launcher.OpenAsync(url));
        }

        public ICommand TapGitHubCommand { get; set; }
        public ICommand TapXamarinCommand { get; set; }
        public ICommand TapSQLiteCommand { get; set; }
    }
}
