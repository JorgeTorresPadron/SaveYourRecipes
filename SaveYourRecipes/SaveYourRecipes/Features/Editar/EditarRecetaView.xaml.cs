using SaveYourRecipes.Models;
using SaveYourRecipes.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveYourRecipes.Features.Editar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarRecetaView : ContentPage
    {
        public EditarRecetaView()
        {
            InitializeComponent();
        }

        private void actualizarRecetaButton_Clicked(object sender, EventArgs e)
        {
            EditarReceta();
        }

        async void EditarReceta()
        {
            if (validarDatos())
            {
                Receta receta = new Receta
                {
                    receta_nombre = actualizarNombreReceta.Text,
                    receta_descripcion = actualizarRecetaDescripcion.Text,
                    tiempo_preparacion = actualizarTiempoPreparacion.Text,
                    tiempo_cocina = actualizarTiempoCocina.Text
                };

                await App.SQLiteDB.ActualizarReceta(receta);
                await App.SQLiteDB.ReadRecetasAsync();
            }
        }

        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(actualizarNombreReceta.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(actualizarRecetaDescripcion.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(actualizarTiempoPreparacion.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(actualizarTiempoCocina.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }
    }
}