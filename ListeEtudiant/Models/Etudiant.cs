using SQLite;

namespace ListeEtudiant.Models;

public class Etudiant
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string Nom { get; set; }
    public string Ville { get; set; }
    public string Niveau { get; set; }
    public string CNE { get; set; }
}



