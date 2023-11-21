namespace EspelhodeClasse.Views;

public partial class Alunos : ContentPage
{
	public Alunos()
	{
		InitializeComponent();
	}
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        alunosCollection.SelectedItem = null;
    }
}