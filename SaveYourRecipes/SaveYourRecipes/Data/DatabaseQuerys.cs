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
            _database.CreateTableAsync<Categoria_comida>().Wait();
            _database.CreateTableAsync<Pais>().Wait();
            _database.CreateTableAsync<Receta>().Wait();
            _database.CreateTableAsync<User>().Wait();
            #endregion

            /*
            #region Eliminación - Tablas (Solo para testeo)
            try
            {
                _database.DeleteAllAsync<Categoria_comida>().Wait();
                _database.DeleteAllAsync<Pais>().Wait();
                _database.DeleteAllAsync<Receta>().Wait();
                _database.DeleteAllAsync<User>().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion
            */
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
        /// METOD-O PARA MOSTRAR LOS USUARIOS QUE TIENEN SESIÓN INICIADA
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns></returns>
        public Task<List<User>> GetUserThatAreLogIn()
        {
            return _database.QueryAsync<User>("SELECT * FROM User WHERE user_is_login = true");
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
        /// <summary>
        /// METOD-O SELECCIONAR RECETA POR ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Receta> GetRecetaIdAsync(int id)
        {
            return _database.Table<Receta>().Where(i => i.receta_id == id).FirstOrDefaultAsync();
        }
        /// <summary>
        /// METOD-O SELECCIONAR RECETAS
        /// </summary>
        /// <returns></returns>
        public Task<List<Receta>> GetRecetaAsync()
        {
            return _database.Table<Receta>().ToListAsync();
        }
        /// <summary>
        /// METOD-O GUARDAR RECETAS
        /// </summary>
        /// <param name="receta"></param>
        /// <returns></returns>
        public Task<int> SaveRecetaAsync(Receta receta)
        {
            if (receta.receta_id != 0)
            {
                return _database.UpdateAsync(receta);
            }
            else
            {
                return _database.InsertAsync(receta);
            }
        }
        /// <summary>
        /// METOD-O ELIMINAR RECETA
        /// </summary>
        /// <param name="receta"></param>
        /// <returns></returns>
        public Task<int> DeleteRecetaAsync(Receta receta)
        {
            return _database.DeleteAsync(receta);
        }

        public Task<List<Receta>> GetRecipesOfMyUser(string nombreUsuario)
        {
            return _database.Table<Receta>().Where(r => r.receta_nombre_usuario == nombreUsuario).ToListAsync();
        }
        #endregion

        #region CRUD - CATEGORIA_COMIDA TABLE
        /// <summary>
        /// METOD-O GUARDAR CATEGORIA COMIDA
        /// </summary>
        /// <param name="categoria_Comida"></param>
        /// <returns></returns>
        public Task<int> SaveCategoriaComidaAsync(Categoria_comida categoria_Comida)
        {
            if (categoria_Comida.categoria_comida_id != 0)
            {
                return _database.UpdateAsync(categoria_Comida);
            }
            else
            {
                return _database.InsertAsync(categoria_Comida);
            }
        }
        /// <summary>
        /// METOD-O PARA VER LAS CATEGORIAS DE COMIDA
        /// </summary>
        /// <returns></returns>
        public Task<List<Categoria_comida>> GetCategoriaComidaAsync()
        {
            return _database.Table<Categoria_comida>().ToListAsync();
        }
        /// <summary>
        /// METOD-O PARA VER LAS CATEGORIAS POR ID
        /// </summary>
        /// <param name="idCategoria"></param>
        /// <returns></returns>
        public Task<Categoria_comida> GetCategoriaComidaPorId(int idCategoria)
        {
            return _database.Table<Categoria_comida>().Where(cat => cat.categoria_comida_id == idCategoria).FirstOrDefaultAsync();
        }
        /// <summary>
        /// METOD-O ELIMINAR CATEGORIA COMIDA
        /// </summary>
        /// <param name="categoria_Comida"></param>
        /// <returns></returns>
        public Task<int> DeleteCategoriaComidaAsync(Categoria_comida categoria_Comida)
        {
            return _database.DeleteAsync(categoria_Comida);
        }

        public Task<List<Categoria_comida>> GetCategoriaComidaNombresAsync()
        {
            return _database.QueryAsync<Categoria_comida>("SELECT categoria_comida_nombre FROM Categoria_comida");
        }
        #endregion

        #region CRUD - PAIS TABLE
        /// <summary>
        /// METOD-O GUARDAR PAIS
        /// </summary>
        /// <param name="pais"></param>
        /// <returns></returns>
        public Task<int> SavePaisAsync(Pais pais)
        {
            if (pais.pais_id != 0)
            {
                return _database.UpdateAsync(pais);
            }
            else
            {
                return _database.InsertAsync(pais);
            }
        }
        /// <summary>
        /// METOD-O PARA VER LOS PAISES
        /// </summary>
        /// <returns></returns>
        public Task<List<Pais>> GetPaisAsync()
        {
            return _database.Table<Pais>().ToListAsync();
        }
        /// <summary>
        /// METOD-O PARA VER LOS PAISES POR ID
        /// </summary>
        /// <param name="idPais"></param>
        /// <returns></returns>
        public Task<Pais> GetPaisPorId(int idPais)
        {
            return _database.Table<Pais>().Where(pas => pas.pais_id == idPais).FirstOrDefaultAsync();
        }
        /// <summary>
        /// METOD-O ELIMINAR PAIS
        /// </summary>
        /// <param name="pais"></param>
        /// <returns></returns>
        public Task<int> DeletePaisAsync(Pais pais)
        {
            return _database.DeleteAsync(pais);
        }

        public Task<List<Pais>> GetPaisNombresAsync()
        {
            return _database.QueryAsync<Pais>("SELECT pais_nombre FROM Pais");
        }
        #endregion
    }
}
