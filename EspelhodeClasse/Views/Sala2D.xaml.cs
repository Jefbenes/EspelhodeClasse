using Microsoft.Maui.Graphics.Text;

namespace EspelhodeClasse.Views;

public partial class Sala2D : ContentPage
{
	public Sala2D()
	{
		InitializeComponent();
        MontaSala();
    }
    private void MontaSala()
    {
        Content = new StackLayout();

        var label = new Label
        {
            Text = "Sala de aula",
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            TextColor = Color.FromArgb("#ff0000FF"),
            FontSize = 24
        };
        (Content as StackLayout).Children.Add(label);

        var btnConfig = new Button
        {
            Text = "Configurar",
            TextColor = Color.FromArgb("ffFFFFaF"),
            HorizontalOptions = LayoutOptions.Center,
            FontSize = 24
        };        
        btnConfig.SetBinding(Button.CommandProperty, new Binding("ConfigCommand"));
        (Content as StackLayout).Children.Add(btnConfig);
    }
}