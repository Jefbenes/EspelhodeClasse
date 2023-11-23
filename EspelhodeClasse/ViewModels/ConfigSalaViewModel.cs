using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using EspelhodeClasse.Models;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EspelhodeClasse.ViewModels;
internal class ConfigSalaViewModel : ObservableObject
{
    private Models.Sala _sala;

    private int _Colunas;
    private int _Linhas;
    public int Colunas
    {
        get { return _Colunas; }
        set
        {
            if (_Colunas != value)
            {
                _Colunas = value;
                OnPropertyChanged(nameof(Colunas));
            }
        }
    }
    public int Linhas
    {
        get { return _Linhas; }
        set
        {
            if (_Linhas != value)
            {
                _Linhas = value;
                OnPropertyChanged(nameof(Linhas));
            }
        }
    }
    public ICommand MaisColunasCommand { get; }
    public ICommand MenosColunasCommand { get; }
    public ICommand MaisLinhasCommand { get; }
    public ICommand MenosLinhasCommand { get; }

    private void MaisColunas()
    {
        if (Colunas < 10)
        {
            Colunas++;
            RefreshProperties();
        }
    }
    private void MenosColunas()
    {
        if (Colunas > 1)
        {
            Colunas--;
            RefreshProperties();
        }
    }
    private void MaisLinhas()
    {
        if (Linhas < 10)
        {
            Linhas++;
            RefreshProperties();
        }
    }
    private void MenosLinhas()
    {
        if (Linhas > 1)
        {
            Linhas--;
            RefreshProperties();
        }
    }
    public ConfigSalaViewModel()
    {
        _sala = new Models.Sala();
        Colunas = 3;                                        // Valor inicial
        Linhas =3;
        MaisColunasCommand = new Command(MaisColunas);
        MenosColunasCommand = new Command(MenosColunas);
        MaisLinhasCommand = new Command(MaisLinhas);
        MenosLinhasCommand = new Command(MenosLinhas);
    }
    private void RefreshProperties()
    {
        OnPropertyChanged(nameof(Colunas));
        OnPropertyChanged(nameof(Linhas));
    }

    /*
    private Models.Sala _sala;
    public string Colunas
    {

        get { return _sala.Colunas }
        set
        {
            if (_sala.Colunas != value)
            {
                _sala.Colunas = value;
                OnPropertyChanged(nameof(_sala.Colunas));
            }
        }
    }
    public int Linhas => _sala.Linhas;
    public ICommand MaisColunasCommand { get; }
    public ICommand MenosColunasCommand { get; }

    public ConfigSalaViewModel()
    {
        _sala = new Models.Sala();
        MaisColunasCommand = new Command(MaisColunas);
        MenosColunasCommand = new Command(MenosColunas);
    }
    private void MaisColunas()
    {
        _sala.MaisColunas();
    }
    private void MenosColunas()
    {
        _sala.MenosColunas();
    }
     */
}
