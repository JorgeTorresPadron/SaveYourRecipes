using SaveYourRecipes.Features.MisRecetas;
using SaveYourRecipes.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveYourRecipes.Features.NuevaReceta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevaRecetaView : ContentPage
    {
        public NuevaRecetaView()
        {
            InitializeComponent();
        }

        private async void guardarRecetaButton_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Receta receta = new Receta
                {
                    receta_nombre = nombreRecetaEntry.Text,
                    receta_descripcion = recetaDescripcion.Text,
                    tiempo_preparacion = tiempoPreparacion.Text,
                    tiempo_cocina = tiempoCocina.Text
                };
                //guardamos los datos en la base de datos
                await App.SQLiteDB.SaveRecetaAsync(receta);
                //ponemos los cambios otra vez vacíos
                nombreRecetaEntry.Text = "";
                recetaDescripcion.Text = "";
                tiempoPreparacion.Text = "";
                tiempoCocina.Text = "";
                //avisamos que se insertaron correctamente con una alerta
                await DisplayAlert("Guardar receta", "Receta almacenada correctamente", "Ok");
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresa todos los datos", "Ok");
            }
        }

        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(nombreRecetaEntry.Text))
            {
                respuesta = false;
            } 
            else if (string.IsNullOrEmpty(recetaDescripcion.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(tiempoPreparacion.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(tiempoCocina.Text))
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