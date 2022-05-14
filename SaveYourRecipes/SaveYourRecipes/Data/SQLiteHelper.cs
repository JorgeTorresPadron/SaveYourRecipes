using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SaveYourRecipes.Models;

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
    }
}
