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
        SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Cantidad>();
            db.CreateTableAsync<Ingredientes>();
            db.CreateTableAsync<Categoria_comida>();
            db.CreateTableAsync<Medidas>();
            db.CreateTableAsync<Pais>();
            db.CreateTableAsync<Receta>();
            db.CreateTableAsync<Receta_pasos>();
        }

        public Task<int> SaveRecetaAsync(Receta receta)
        {
            if (receta.receta_id == 0)
            {
                return db.InsertAsync(receta);
            }
            else
            {
                return db.InsertAsync(receta);
            }
        }
    }
}
