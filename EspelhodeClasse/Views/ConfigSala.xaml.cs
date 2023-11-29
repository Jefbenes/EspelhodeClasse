//using AndroidX.Lifecycle;
using EspelhodeClasse.ViewModels;
using Microsoft.Maui.Controls;
//using static Android.App.Assist.AssistStructure;

namespace EspelhodeClasse.Views;

public partial class ConfigSala : ContentPage
{
    private ConfigSalaViewModel viewModel;
    public ConfigSala()
	{
		InitializeComponent();
        MontaSala();
    }
    private void MontaSala()
    {
        viewModel = new ConfigSalaViewModel();
        BindingContext = viewModel;
        Content = new StackLayout();

        (Content as StackLayout).Children.Clear();

        Grid gridMenu = viewModel.GridMenu;
        (Content as StackLayout).Children.Add(gridMenu);

        Grid gridSeletor = viewModel.GridSeletor;
        (Content as StackLayout).Children.Add(gridSeletor);

        Grid gridSala = viewModel.GridSala;
        (Content as StackLayout).Children.Add(gridSala);
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        MontaSala();
    }
}

