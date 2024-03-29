using ListeEtudiant.Views;

namespace ListeEtudiant;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(EtudiantListPage), typeof(EtudiantListPage));
        Routing.RegisterRoute(nameof(EtudiantPage), typeof(EtudiantPage));
    }
}