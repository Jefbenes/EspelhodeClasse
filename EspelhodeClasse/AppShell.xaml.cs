namespace EspelhodeClasse;
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

        Routing.RegisterRoute(nameof(Views.Aluno), typeof(Views.Aluno));
        Routing.RegisterRoute(nameof(Views.ConfigSala), typeof(Views.ConfigSala));
    }
}