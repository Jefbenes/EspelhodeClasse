using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace EspelhodeClasse.ViewModels;

class Sala2DViewModel// : IQueryAttributable
{
    public ICommand ConfigCommand { get; }

    public Sala2DViewModel()
    {
        ConfigCommand = new AsyncRelayCommand(ConfigSalaAsync);
    }
    private async Task ConfigSalaAsync()
    {
        await Shell.Current.GoToAsync(nameof(Views.ConfigSala));
    }
}
