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
            db.CreateTableAsync<Receta>();
            db.CreateTableAsync<Cantidad>();
            db.CreateTableAsync<Ingredientes>();
            db.CreateTableAsync<Categoria_comida>();
            db.CreateTableAsync<Medidas>();
            db.CreateTableAsync<Pais>();
            db.CreateTableAsync<Receta_pasos>();
        }

        /// <summary>
        /// Guardar o actualizar la receta
        /// </summary>
        /// <param name="receta"></param>
        /// <returns></returns>
        public Task<int> SaveRecetaAsync(Receta receta)
        {
            if (receta.receta_id != 0)
            {
                return db.InsertAsync(receta);
            }
            else
            {
                return db.UpdateAsync(receta);
            }
                
        }

        /// <summary>
        /// Recuperar todas las recetas
        /// </summary>
        /// <returns></returns>
        public Task<List<Receta>> ReadRecetasAsync()
        {
            return db.Table<Receta>().ToListAsync();
        }

        /// <summary>
        /// Recuperar recetas por id
        /// </summary>
        /// <param name="idReceta">Id de la receta que se requiere</param>
        /// <returns></returns>
        public Task<Receta> GetRecetaByIdAsync(int idReceta)
        {
            return db.Table<Receta>().Where(a => a.receta_id == idReceta).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Actualizar recetas
        /// </summary>
        /// <param name="receta"></param>
        /// <returns></returns>
        public Task<int> ActualizarReceta(Receta receta)
        {
            return db.UpdateAsync(receta);
        }

        /// <summary>
        /// Eliminar recetas
        /// </summary>
        /// <param name="receta"></param>
        /// <returns></returns>
        public Task<int> EliminarReceta (Receta receta)
        {
            return db.DeleteAsync(receta);
        }
    }
}
