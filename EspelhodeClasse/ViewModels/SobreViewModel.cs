using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace EspelhodeClasse.ViewModels;

internal class SobreViewModel
{
    public string Title => AppInfo.Name;
    public string Version => AppInfo.VersionString;
    public string MoreInfoUrl => "https://aka.ms/maui";
    public string Message => "Este aplicativo foi escrito em XAML e C# com .NET MAUI";
    public ICommand ShowMoreInfoCommand { get; }
    public SobreViewModel()
    {
        ShowMoreInfoCommand = new AsyncRelayCommand(ShowMoreInfo);
    }
    private async Task ShowMoreInfo() =>
        await Launcher.Default.OpenAsync(MoreInfoUrl);

}
