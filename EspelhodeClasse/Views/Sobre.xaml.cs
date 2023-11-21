namespace EspelhodeClasse.Views;

public partial class Sobre : ContentPage
{
    private double rotationAngle = 0;
    public Sobre()
    {
        InitializeComponent();
        StartRotation();
    }
    private async void StartRotation()
    {
        while (true)
        {
            rotationAngle = (rotationAngle + 3) % 360; // Ajuste a velocidade da rotação alterando o valor 3
            await Dispatcher.DispatchAsync(() =>
            {
                Bot.Rotation = rotationAngle;
            });
            await Task.Delay(16);
        }
    }
}