using ListeEtudiant.Models;
using SQLite;
using ListeEtudiant;

public class EtudiantDatabase
{ 
    SQLiteAsyncConnection Database;

    async Task Init()
    {
        if (Database is not null)
            return;

        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await Database.CreateTableAsync<Etudiant>();
    }

    public async Task<List<Etudiant>> GetAllEtudiants()
    {
        await Init();
        return await Database.Table<Etudiant>().ToListAsync();
    }

    public async Task<Etudiant> GetEtudiant(string CNE)
    {
        await Init();
        return await Database.Table<Etudiant>().Where(etudiant => etudiant.CNE.Equals(CNE)).FirstOrDefaultAsync();
    }

    public async Task<int> SaveEtudiant(Etudiant etudiant)
    {
        await Init();
        if (etudiant.ID != 0)
        {
            return await Database.UpdateAsync(etudiant);
        }

        return await Database.InsertAsync(etudiant);
    }

    public async Task<int> DeleteEtudiant(Etudiant etudiant)
    {
        await Init();
        return await Database.DeleteAsync(etudiant);
    }
}