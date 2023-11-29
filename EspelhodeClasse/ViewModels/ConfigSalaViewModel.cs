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

    public ICommand MaisColunasCommand { get; }
    public ICommand MenosColunasCommand { get; }
    public ICommand MaisLinhasCommand { get; }
    public ICommand MenosLinhasCommand { get; }

    public int Colunas
    {
        get { return _sala.Colunas; }
        set
        {
            if (_sala.Colunas != value)
            {
                _sala.Colunas = value;
                OnPropertyChanged(nameof(Colunas));
            }
        }
    }
    public int Linhas
    {
        get { return _sala.Linhas; }
        set
        {
            if (_sala.Linhas != value)
            {
                _sala.Linhas = value;
                OnPropertyChanged(nameof(Linhas));
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
        _sala.MaisColunas();
        OnPropertyChanged(nameof(Colunas));
    }
    private void MenosColunas()
    {
        _sala.MenosColunas();
        OnPropertyChanged(nameof(Colunas));
    }
    private void MaisLinhas()
    {
        _sala.MaisLinhas();
        OnPropertyChanged(nameof(Linhas));
    }
    private void MenosLinhas()
    {
        _sala.MenosLinhas();
        OnPropertyChanged(nameof(Linhas));
    }
    public ObservableCollection<bool> CheckBoxStates { get; set; } = new ObservableCollection<bool>();
    private void InicializarCheckBoxes()
    {
        CheckBoxStates.Clear();

        for (int i = 0; i < _sala.MaxColunas; i++)
        {


            int index = i; // Crie uma variável local para armazenar o valor atual de i

            var chBox = new CheckBox
            {
                IsChecked = _sala.GetMesaCorredor(index)
            };
            // Associe o manipulador de eventos ao evento CheckedChanged
            chBox.CheckedChanged += (s, e) =>
            {
                // Verifique se o CheckBox foi marcado ou desmarcado
                var checkBox = (CheckBox)s;
                _sala.SetMesaCorredor(index, checkBox.IsChecked);
            };
            CheckBoxStates.Add(true);
        }
    }
    public ConfigSalaViewModel()
    {
        _sala = new Models.Sala();
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

                if (checkBox != null)
                {
                    if (checkBox.IsChecked)
                    {
                        var mesa = new Frame
                        {
                            BackgroundColor = Colors.LightGray,
                            BorderColor = Colors.Gray,
                            HasShadow = true,
                            CornerRadius = 12,
                            WidthRequest = 90,
                            HeightRequest = 55,
                        };

                        Grid.SetColumn(mesa, i);
                        Grid.SetRow(mesa, j);
                        grid.Children.Add(mesa);
                    }
                    else
                    {
                        var corredor = new Frame
                        {
                            BackgroundColor = Colors.LightYellow,
                            WidthRequest = 90,
                            HeightRequest = 55,
                        };

                        Grid.SetColumn(corredor, i);
                        Grid.SetRow(corredor, j);
                        grid.Children.Add(corredor);
                    }
                }
            }
        }
        GridSala = grid;
        OnPropertyChanged(nameof(GridSala));
    }
}

