using SaveYourRecipes.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SaveYourRecipes.Data
{
    public class IngredientesRepository
    {
        private readonly SQLiteConnection _database;

        public static string DbPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBSaveYourRecipes.db");

        public IngredientesRepository()
        {
            _database = new SQLiteConnection(DbPath);
            _database.CreateTable<Ingredientes>();
        }

        public List<Ingredientes> List()
        {
            return _database.Table<Ingredientes>().ToList();
        }
    }
}
