using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Comparacion.Model;

namespace Comparacion.Repository
{
    class SQLiteRepository
    {
        readonly SQLiteAsyncConnection database;

        public SQLiteRepository(string dbPath)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, dbPath);
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<ObjetoSQLite>().Wait();

        }

        public Task<List<ObjetoSQLite>> GetAllObjectsSQLite()
        {
            Stopwatch watchSQLite = Stopwatch.StartNew();
            Task<List<ObjetoSQLite>> lista = database.Table<ObjetoSQLite>().ToListAsync();
            watchSQLite.Stop();
            Tiempos.watchSQLiteReadAll = watchSQLite.ElapsedMilliseconds;
            return lista;
        }

        public Task<ObjetoSQLite> GetOneObjectsSQLite(int id)
        {
            return database.Table<ObjetoSQLite>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<int> CreateObjectsSQLite(ObjetoSQLite sqliteObject)
        {
            if (sqliteObject.id != 1)
                return database.UpdateAsync(sqliteObject);
            else
                return database.InsertAsync(sqliteObject);
        }

        public Task<int> DeleteObjectsSQLite(ObjetoSQLite vg)
        {
            return database.DeleteAsync(vg);
        }

        public void CreateAllObjectsSQLite()
        {
            Stopwatch watchSQLite = Stopwatch.StartNew();
            for (int i = 1; i <= 1000; i++)
                database.InsertAsync(new ObjetoSQLite(i, i));

            watchSQLite.Stop();
            Tiempos.watchSQLiteCreate = watchSQLite.ElapsedMilliseconds;
            Console.WriteLine(Tiempos.watchSQLiteCreate.ToString());
        }

        public void DeleteAllObjectSQLite()
        {
            Stopwatch watchSQLite = Stopwatch.StartNew();
            database.DeleteAllAsync<ObjetoSQLite>();
            watchSQLite.Stop();
            Tiempos.watchSQLiteDelete = watchSQLite.ElapsedMilliseconds;
        }

        public void UpdateAllObjectSQLite()
        {
            Stopwatch watchSQLite = Stopwatch.StartNew();
            List<ObjetoSQLite> lista = this.GetAllObjectsSQLite().Result;
            for (int i = 1; i < lista.Count; i++)
            {
                ObjetoSQLite newObj = new ObjetoSQLite(i, i + i);
                database.UpdateAsync(newObj);
            }
            watchSQLite.Stop();
            Tiempos.watchSQLiteUpdate = watchSQLite.ElapsedMilliseconds;

        }
    }
}
