namespace EspelhodeClasse;
public partial class Sala : ContentPage
{
    public Sala()
    {
        InitializeComponent();
        MontaSala(8, 8);            // maxColunas e maxLinhas
    }

    void MontaSala(int maxColunas, int maxLinhas)
    {
        // O layout esta rotacionado à esquerda, logo, o total de linhas será o total de colunas e vice versa
        // O grid  | a, b, c |    vira  | 0, c, f |   mas acrescento uma coluna para poder posicionar as imagens melhor
        //         | d, e, f |          | 0, b, e |
        //                              | 0, a, d |

        int lin, col;

        var grids = new List<Grid>();                       // Cria um grid para cada linha da tela, para representar as colunas de classes
                
        var images = new Image[maxLinhas+1, maxColunas];    // Cria espaços para as imagens

        for(col = maxColunas - 1; col >= 0; col--)          // col representa as linhas na tela
        {
            var grid = new Grid();                          // cria um grid para cada linha

            grid.RowDefinitions.Add(new RowDefinition { Height = 90 });    // Define altura da linha na tela
            for (lin = 0; lin <= maxLinhas; lin++)                          // Vai até <= para acrescentar uma linha
            {
                if(lin == 0)        // na linha 0, uso uma imagem corredor e defino o tamanho variável, para ajustar as demais mesas
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 100 + col * 60 });     // Define a largura dos desenhos

                    images[lin, col] = new Image
                    {
                        Source = "corredor.png",
                        WidthRequest = 200,
                        HeightRequest = 200,
                    };
                    Grid.SetColumn(images[lin, col], lin);

                    grid.Children.Add(images[lin, col]);
                }
                else
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 150 });     // Define a largura dos desenhos

                    images[lin, col] = new Image
                    {
                        Source = "mesa.png",
                        WidthRequest = 200,
                        HeightRequest = 200,
                    };
                    Grid.SetColumn(images[lin, col], lin);

                    grid.Children.Add(images[lin, col]);
                }
            }
            grids.Add(grid);
        }

        Content = new StackLayout();

        var grid1 = new Grid();
        grid1.RowDefinitions.Add(new RowDefinition { Height = 50 });    // Define altura da linha na tela
        (Content as StackLayout).Children.Add(grid1);

        for (int i = 0; i < maxColunas; i++)
        {
            (Content as StackLayout).Children.Add(grids[i]);
        }
    }
}