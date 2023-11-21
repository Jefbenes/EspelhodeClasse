using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using EspelhodeClasse.Models;

namespace EspelhodeClasse.ViewModels;

internal class ConfigSalaViewModel
{
    public ICommand MaisColunasCommand { get; }
    public ICommand MenosColunasCommand { get; }

    public ConfigSalaViewModel()
    {
//        MaisColunasCommand = new AsyncRelayCommand(NewNoteAsync);
//        MenosColunasCommand = new AsyncRelayCommand(NewNoteAsync);

    }
}
