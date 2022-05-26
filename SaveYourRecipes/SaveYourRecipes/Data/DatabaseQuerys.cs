using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SaveYourRecipes.Models;
using System.Threading.Tasks;
using System.IO;

namespace SaveYourRecipes.Data
{
    public class DatabaseQuerys
    {
        #region Creacion - Tabla - DbPath
        readonly SQLiteAsyncConnection _database;

        public DatabaseQuerys(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);

            #region Creacion - Tablas
            _database.CreateTableAsync<Cantidad>().Wait();
            _database.CreateTableAsync<Categoria_comida>().Wait();
            _database.CreateTableAsync<Ingredientes>().Wait();
            _database.CreateTableAsync<Medidas>().Wait();
            _database.CreateTableAsync<Pais>().Wait();
            _database.CreateTableAsync<Receta>().Wait();
            _database.CreateTableAsync<Receta_pasos>().Wait();
            _database.CreateTableAsync<User>().Wait();
            #endregion
        }
        #endregion

        #region CRUD - USER TABLE
        /// <summary>
        /// METOD-O SELECT SEARCH BAR()
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<User> GetUserIdAsync(int id)
        {
            return _database.Table<User>().Where(i => i.user_id == id).FirstOrDefaultAsync();
        }
        /// <summary>
        /// METOD-O SELECT ()
        /// </summary>
        /// <returns></returns>
        public Task<List<User>> GetUserAsync()
        {
            return _database.Table<User>().ToListAsync();
        }
        /// <summary>
        /// METOD-O GUARDAR Y ACTUALIZAR ()
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<int> SaveUserAsync(User user)
        {
            if (user.user_id != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }
        /// <summary>
        /// METOD-O ELIMINAR ()
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }
        /// <summary>
        /// METOD-O INICIAR SESIÓN
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task<List<User>> GetUsersValidate(string nombreUsuario, string password)
        {
            return _database.QueryAsync<User>("SELECT * FROM User WHERE user_nombre_usuario = '" + nombreUsuario + "' AND user_password = '" + password + "'");
        }
        /// <summary>
        /// METOD-O COMPROBAR QUE USUARIO EXISTE PARA CAMBIAR CONTRASEÑA
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns></returns>
        public Task<List<User>> GetUserChangePasswordValidate(string nombreUsuario)
        {
            return _database.QueryAsync<User>("SELECT * FROM User WHERE user_nombre_usuario = '" + nombreUsuario + "'");
        }
        /// <summary>
        /// METOD-O ACTUALIZAR CONTRASEÑA USUARIO
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task UpdateUserPassword(string nombreUsuario, string password)
        {
            return _database.QueryAsync<User>("UPDATE User SET user_password = '" + password + "' WHERE user_nombre_usuario = '" + nombreUsuario + "'");
        }
        /// <summary>
        /// METOD-O ELIMINAR USUARIO
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task DeleteUserCompletely(string nombreUsuario, string password)
        {
            return _database.QueryAsync<User>("DELETE FROM User WHERE user_nombre_usuario = '" + nombreUsuario + "' AND user_password = '" + password + "'");
        }
        #endregion

        #region CRUD - RECETA TABLE 

        #endregion
    }
}
