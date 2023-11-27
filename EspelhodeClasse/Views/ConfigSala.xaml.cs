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
        viewModel = new ConfigSalaViewModel();
        BindingContext = viewModel;
        MontaSala();
    }
    private void MontaSala()
    {
        Content = new StackLayout();

        (Content as StackLayout).Children.Clear();
        /*
                Button btnTeste = new Button
                {
                    Text = "Refresh",
                    TextColor = Color.FromArgb("ffFFFFaF"),
                    HorizontalOptions = LayoutOptions.Center,
                    FontSize = 14
                };
                btnTeste.Command = new Command(() => MontaSala());
                (Content as StackLayout).Children.Add(btnTeste);

         */

        Grid gridMenu = viewModel.GridMenu;
        (Content as StackLayout).Children.Add(gridMenu);

        Grid gridSeletor = viewModel.GridSeletor;
        (Content as StackLayout).Children.Add(gridSeletor);

        Grid gridSala = viewModel.GridSala;
        (Content as StackLayout).Children.Add(gridSala);
    }
}

