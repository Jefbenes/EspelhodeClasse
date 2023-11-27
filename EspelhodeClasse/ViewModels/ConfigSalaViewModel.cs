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
using System.Collections.ObjectModel;

namespace EspelhodeClasse.ViewModels;
internal class ConfigSalaViewModel : ObservableObject, INotifyPropertyChanged
{
    private Models.Sala _sala;
    private Grid _gridMenu, _gridSeletor, _gridSala;

    private int _colunas;
    private int _linhas;
    private int _maxColunas = 10;

    public ICommand MaisColunasCommand { get; }
    public ICommand MenosColunasCommand { get; }
    public ICommand MaisLinhasCommand { get; }
    public ICommand MenosLinhasCommand { get; }

     public int Colunas
    {
        get { return _colunas; }
        set
        {
            if (_colunas != value)
            {
                _colunas = value;
            }
        }
    }
    public int Linhas
    {
        get { return _linhas; }
        set
        {
            if (_linhas != value)
            {
                _linhas = value;
            }
        }
    }
    public Grid GridMenu
    {
        get { return _gridMenu; }
        set
        {
            if (_gridMenu != value)
            {
                _gridMenu = value;
            }
        }
    }
    public Grid GridSeletor
    {
        get { return _gridSeletor; }
        set
        {
            if (_gridSeletor != value)
            {
                _gridSeletor = value;
            }
        }
    }
    public Grid GridSala
    {
        get { return _gridSala; }
        set
        {
            if (_gridSala != value)
            {
                _gridSala = value;
            }
        }
    }
    private void MaisColunas()
    {
        if (Colunas < 10)
        {
            Colunas++;
            OnPropertyChanged(nameof(Colunas));
        }
    }
    private void MenosColunas()
    {
        if (Colunas > 1)
        {
            Colunas--;
            OnPropertyChanged(nameof(Colunas));
        }
    }
    private void MaisLinhas()
    {
        if (Linhas < 10)
        {
            Linhas++;
            OnPropertyChanged(nameof(Linhas));
        }
    }
    private void MenosLinhas()
    {
        if (Linhas > 1)
        {
            Linhas--;
            OnPropertyChanged(nameof(Linhas));
        }
    }
    public ObservableCollection<bool> CheckBoxStates { get; set; } = new ObservableCollection<bool>();
    private void InicializarCheckBoxes()
    {
        CheckBoxStates.Clear();

        for (int i = 0; i < _maxColunas; i++)
        {
            CheckBoxStates.Add(true);
        }
    }
    public ConfigSalaViewModel()
    {
        _sala = new Models.Sala();
        Colunas = 1;
        Linhas = 1;
        MaisColunasCommand = new Command(MaisColunas);
        MenosColunasCommand = new Command(MenosColunas);
        MaisLinhasCommand = new Command(MaisLinhas);
        MenosLinhasCommand = new Command(MenosLinhas);
        InicializarCheckBoxes();
        Atualizar();
    }
    private void Atualizar()
    {
        Menu();
        Seletor();
        Sala();
    }
    private void Menu()
    {
        GridMenu = new Grid
        {
            HorizontalOptions = LayoutOptions.Center,
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = 100 },
                new ColumnDefinition { Width = 100 }
            },
            RowDefinitions =
            {
                new RowDefinition { Height = GridLength.Star },
                new RowDefinition { Height = GridLength.Star },
                new RowDefinition { Height = GridLength.Star }
            },
            ColumnSpacing = 10
        };

        var btnMaisColunas = new Button
        {
            Text = "+ Colunas",
            TextColor = Color.FromArgb("ffFFFFaF"),
            HorizontalOptions = LayoutOptions.Center,
            FontSize = 14
        };
        Grid.SetColumn(btnMaisColunas, 0);
        Grid.SetRow(btnMaisColunas, 0);
        btnMaisColunas.SetBinding(Button.CommandProperty, new Binding("MaisColunasCommand"));
        GridMenu.Children.Add(btnMaisColunas);

        var lblColunas = new Label
        {
            Text = Colunas.ToString(),
            TextColor = Color.FromArgb("#ff0000FF"),
            HorizontalOptions = LayoutOptions.Center,
            FontSize = 18
        };
        Grid.SetColumn(lblColunas, 0);
        Grid.SetRow(lblColunas, 1);
        lblColunas.SetBinding(Label.TextProperty, new Binding("Colunas"));
        GridMenu.Children.Add(lblColunas);

        var btnMenosColunas = new Button()
        {
            Text = "- Colunas",
            TextColor = Color.FromArgb("ffFFFFaF"),
            HorizontalOptions = LayoutOptions.Center,
            FontSize = 14
        };
        Grid.SetColumn(btnMenosColunas, 0);
        Grid.SetRow(btnMenosColunas, 2);
        btnMenosColunas.SetBinding(Button.CommandProperty, new Binding("MenosColunasCommand"));
        GridMenu.Children.Add(btnMenosColunas);

        var btnMaisLinhas = new Button
        {
            Text = "+ Linhas",
            TextColor = Color.FromArgb("ffFFFFaF"),
            HorizontalOptions = LayoutOptions.Center,
            FontSize = 14
        };
        Grid.SetColumn(btnMaisLinhas, 1);
        Grid.SetRow(btnMaisLinhas, 0);
        btnMaisLinhas.SetBinding(Button.CommandProperty, new Binding("MaisLinhasCommand"));
        GridMenu.Children.Add(btnMaisLinhas);

        var lblLinhas = new Label
        {
            Text = Linhas.ToString(),
            TextColor = Color.FromArgb("#ff0000FF"),
            HorizontalOptions = LayoutOptions.Center,
            FontSize = 18
        };
        Grid.SetColumn(lblLinhas, 1);
        Grid.SetRow(lblLinhas, 1);
        lblLinhas.SetBinding(Label.TextProperty, new Binding("Linhas"));
        GridMenu.Children.Add(lblLinhas);

        var btnMenosLinhas = new Button()
        {
            Text = "- Linhas",
            TextColor = Color.FromArgb("ffFFFFaF"),
            HorizontalOptions = LayoutOptions.Center,
            FontSize = 14
        };
        Grid.SetColumn(btnMenosLinhas, 1);
        Grid.SetRow(btnMenosLinhas, 2);
        btnMenosLinhas.SetBinding(Button.CommandProperty, new Binding("MenosLinhasCommand"));
        GridMenu.Children.Add(btnMenosLinhas);
    }
    private void Seletor()
    {
        GridSeletor = new Grid
        {
            HorizontalOptions = LayoutOptions.Center,
            ColumnSpacing = 5
        };
        GridSeletor.ColumnDefinitions.Clear();
        GridSeletor.Children.Clear();

        for (int i = 0; i < Colunas; i++)
        {
            var chBoxMesaCorredor = new CheckBox
            {
                IsChecked = CheckBoxStates[i]
            };
            chBoxMesaCorredor.CheckedChanged += (s, e) =>
            {
                CheckBoxStates[i] = chBoxMesaCorredor.IsChecked;
                // Chame aqui o método que atualiza a tela conforme as mudanças nos CheckBoxes
//                Sala();
            };
            Grid.SetColumn(chBoxMesaCorredor, i);
            GridSeletor.ColumnDefinitions.Add(new ColumnDefinition { Width = 90 });
            GridSeletor.Children.Add(chBoxMesaCorredor);
        }
    }
    private void Sala()
    {
        var grid = new Grid
        {
            HorizontalOptions = LayoutOptions.Center,
            ColumnSpacing = 5
        };

        grid.ColumnDefinitions.Clear();
        grid.Children.Clear();

        for (int i = 0; i < Colunas; i++)
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 90 });
        }
        for (int j = 0; j < Linhas; j++)
        {
            grid.RowDefinitions.Add(new RowDefinition { Height = 60 });
        }

        for (int j = 0; j < Linhas; j++)
        {
            for (int i = 0; i < Colunas; i++)
            {
                CheckBox checkBox = GridSeletor.Children
                    .OfType<CheckBox>()
                    .FirstOrDefault(ch => Grid.GetColumn(ch) == i);

                if (checkBox != null && checkBox.IsChecked)
                {
                    var mesa = new Frame
                    {
                        BackgroundColor = Colors.DarkBlue,
                        BorderColor = Colors.LightGray,
                        HasShadow = true,
                        CornerRadius = 12,
                        WidthRequest = 90,
                        HeightRequest = 60,
                    };

                    Grid.SetColumn(mesa, i);
                    Grid.SetRow(mesa, j);
                    grid.Children.Add(mesa);
                }
            }
        }
        GridSala = grid;
        OnPropertyChanged(nameof(GridSala));
    }
}

