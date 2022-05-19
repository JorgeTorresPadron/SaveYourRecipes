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
        private readonly SQLiteConnection _connection;

        public static string DbPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SaveYourRecipes.db");

        public SQLiteHelper()
        {
            _connection = new SQLiteConnection(DbPath);
            _connection.CreateTable<Cantidad>();
            _connection.CreateTable<Categoria_comida>();
            _connection.CreateTable<Ingredientes>();
            _connection.CreateTable<Medidas>();
            _connection.CreateTable<Pais>();
            _connection.CreateTable<Receta>();
            _connection.CreateTable<Receta_pasos>();
        }

        public List<Receta> recetaList()
        {
            return _connection.Table<Receta>().ToList();
        }
    }
}
