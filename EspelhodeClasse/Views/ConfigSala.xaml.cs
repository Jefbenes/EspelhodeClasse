namespace EspelhodeClasse.Views;

public partial class ConfigSala : ContentPage
{
    private int linhas, colunas;
    public ConfigSala()
	{
		InitializeComponent();
        MontaSala();
    }
    private void MontaSala()
    {
        Content = new StackLayout();

        var lblTittle = new Label
        {
            Text = "Sala de aula",
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            TextColor = Color.FromArgb("#ff0000FF"),
            FontSize = 36
        };
        (Content as StackLayout).Children.Add(lblTittle);

        Menu();
        Sala();
    }
    private void Menu()
    {
        var grid1 = new Grid
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
        grid1.Children.Add(btnMaisColunas);

        var lblColunas = new Label
        {
            Text = colunas.ToString(),
            TextColor = Color.FromArgb("#ff0000FF"),
            HorizontalOptions = LayoutOptions.Center,
            FontSize = 18
        };
        Grid.SetColumn(lblColunas, 0);
        Grid.SetRow(lblColunas, 1);
        lblColunas.SetBinding(Label.TextProperty, new Binding("Colunas"));
        grid1.Children.Add(lblColunas);

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
        grid1.Children.Add(btnMenosColunas);

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
        grid1.Children.Add(btnMaisLinhas);

        var lblLinhas = new Label
        {
            Text = linhas.ToString(),
            TextColor = Color.FromArgb("#ff0000FF"),
            HorizontalOptions = LayoutOptions.Center,
            FontSize = 18
        };
        Grid.SetColumn(lblLinhas, 1);
        Grid.SetRow(lblLinhas, 1);
        lblLinhas.SetBinding(Label.TextProperty, new Binding("Linhas"));
        grid1.Children.Add(lblLinhas);

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
        grid1.Children.Add(btnMenosLinhas);

        (Content as StackLayout).Children.Add(grid1);
    }
    private void Sala()
    {
        var grid2 = new Grid
        {
            HorizontalOptions = LayoutOptions.Center,
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = 100 }
            },
            RowDefinitions =
            {
                new RowDefinition { Height = GridLength.Star },
            },
            ColumnSpacing = 10
        };
        var btnMaisColunas = new Button
        {
            Text = "Mesa",
            TextColor = Color.FromArgb("ffFFFFaF"),
            HorizontalOptions = LayoutOptions.Center,
            FontSize = 14
        };
        Grid.SetColumn(btnMaisColunas, 0);
        Grid.SetRow(btnMaisColunas, 0);
        btnMaisColunas.SetBinding(Button.CommandProperty, new Binding("MaisColunasCommand"));
        grid2.Children.Add(btnMaisColunas);

        (Content as StackLayout).Children.Add(grid2);
    }
}
