using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SaveYourRecipes.Models;
using System.Threading.Tasks;
using System.IO;

namespace SaveYourRecipes.Data
{
    public class SQLiteHelper
    {
        static SQLiteAsyncConnection db;

        public static string dbPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBSaveYourRecipes.db");

        public SQLiteHelper()
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Receta>();
            db.CreateTableAsync<Cantidad>();
            db.CreateTableAsync<Ingredientes>();
            db.CreateTableAsync<Categoria_comida>();
            db.CreateTableAsync<Medidas>();
            db.CreateTableAsync<Pais>();
            db.CreateTableAsync<Receta_pasos>();
        }

        public static Task<int> SaveRecetaAsync(Receta receta)
        {
                return db.InsertAsync(receta);
        }
    }
}
