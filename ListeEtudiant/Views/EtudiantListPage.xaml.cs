using System.Collections.ObjectModel;
using ListeEtudiant.Models;

namespace ListeEtudiant.Views;

public partial class EtudiantListPage : ContentPage
{
    EtudiantDatabase database;
    public ObservableCollection<Etudiant> Etudiants { get; set; } = new();

    public EtudiantListPage(EtudiantDatabase etudiantDatabase)
    {
        InitializeComponent();
        database = etudiantDatabase;
        BindingContext = this;
    }

    // this function customizes behavior immediately after this page was navigated to. 
    // here it's reloading all students from the database to display them
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        var etudiants = await database.GetAllEtudiants();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Etudiants.Clear();
            foreach (var etudiant in etudiants)
                Etudiants.Add(etudiant);
        });
    }

    // go to EtudiantPage when you click the Ajouter Etudiant button
    async void OnEtudiantAdded(object sender, EventArgs e)
    {
        // await DisplayAlert("hi i'm working", "if you're seeing me, then the problem is somewhere else.", "OK");
        await Shell.Current.GoToAsync(nameof(EtudiantPage), true, new Dictionary<string, object>
        {
            ["Student"] = new Etudiant()
        });
    }

    // open the EtudiantPage for the selected student
    private async void SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Etudiant etudiant)
            return;
        
        await Shell.Current.GoToAsync(nameof(EtudiantPage), true, new Dictionary<string, object>
        {
            ["Student"] = etudiant
        });
    }
}