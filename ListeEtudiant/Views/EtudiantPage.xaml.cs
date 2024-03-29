using ListeEtudiant.Models;

namespace ListeEtudiant.Views;

[QueryProperty("Student", "Student")]
public partial class EtudiantPage : ContentPage
{
    public Etudiant Student
    {
        get => BindingContext as Etudiant;
        set => BindingContext = value;
    }

    EtudiantDatabase database;

    public EtudiantPage(EtudiantDatabase etudiantDatabase)
    {
        InitializeComponent();
        database = etudiantDatabase; 
    }
    
    async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Student.CNE))
        {
            await DisplayAlert("CNE Requise", "Veuillez entrer la CNE de l'étudiant.", "OK");
            return;
        }
        if (string.IsNullOrWhiteSpace(Student.Nom))
        {
            await DisplayAlert("Nom Requis", "Veuillez entrer le nom de l'étudiant.", "OK");
            return;
        }

        await database.SaveEtudiant(Student);
        await Shell.Current.GoToAsync("..");
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (Student.ID == 0)
            return;
        await database.DeleteEtudiant(Student);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}

