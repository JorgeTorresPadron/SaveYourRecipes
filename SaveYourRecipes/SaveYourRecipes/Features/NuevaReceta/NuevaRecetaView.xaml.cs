using SaveYourRecipes.Features.MisRecetas;
using SaveYourRecipes.Models;
using SaveYourRecipes.Service;
using System;
using System.Threading.Tasks;
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

        private async void anadirPaisButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NuevoPaisView());
        }

        private async void anadirCategoriaButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NuevaCategoriaView());
        }

        private async void guardarRecetaButton_Clicked(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.nombreRecetaTxt.Text))
            {
                await App.Current.MainPage.DisplayAlert(Strings.Strings.display_alert_error, Strings.Strings.display_alert_empty_recipe_name, Strings.Strings.display_alert_aceptar);
                return;
            }

            if (string.IsNullOrEmpty(this.descripcionRecetaTxt.Text))
            {
                await App.Current.MainPage.DisplayAlert(Strings.Strings.display_alert_error, Strings.Strings.display_alert_empty_recipe_description, Strings.Strings.display_alert_aceptar);
                return;
            }

            if (string.IsNullOrEmpty(this.pasosRecetaTxt.Text))
            {
                await App.Current.MainPage.DisplayAlert(Strings.Strings.display_alert_error, Strings.Strings.display_alert_empty_recipe_steps, Strings.Strings.display_alert_aceptar);
                return;
            }

            if (string.IsNullOrEmpty(this.ingredientesRecetaTxt.Text))
            {
                await App.Current.MainPage.DisplayAlert(Strings.Strings.display_alert_error, Strings.Strings.display_alert_empty_recipe_ingredients, Strings.Strings.display_alert_aceptar);
                return;
            }

            if (this.tiempoPreparacionTxt.Equals(null) | this.tiempoPreparacionTxt.Equals(""))
            {
                await App.Current.MainPage.DisplayAlert(Strings.Strings.display_alert_error, Strings.Strings.display_alert_empty_recipe_preparation_time, Strings.Strings.display_alert_aceptar);
                return;
            }

            if (this.tiempoCocinaTxt.Equals(null) | this.tiempoCocinaTxt.Equals(""))
            {
                await App.Current.MainPage.DisplayAlert(Strings.Strings.display_alert_error, Strings.Strings.display_alert_empty_recipe_cooking_time, Strings.Strings.display_alert_aceptar);
                return;
            }

            var paisSelectedItem = paisesPicker.SelectedItem as Pais;
            var paisNombre = paisSelectedItem.pais_nombre;
            var categoriaSelectedItem = categoriaPicker.SelectedItem as Categoria_comida;
            var categoriaNombre = categoriaSelectedItem.categoria_comida_nombre;

            string nombreUsuario = CompartirInformacion.nombreUsuarioShare;

            Receta receta = new Receta()
            {
                receta_nombre = nombreRecetaTxt.Text,
                receta_descripcion = descripcionRecetaTxt.Text,
                receta_pasos_receta = pasosRecetaTxt.Text,
                receta_ingredientes = ingredientesRecetaTxt.Text,
                tiempo_preparacion = Convert.ToInt32(tiempoPreparacionTxt.Text),
                tiempo_cocina = Convert.ToInt32(tiempoCocinaTxt.Text),
                receta_pais_nombre = paisNombre,
                receta_categoria_comida_nombre = categoriaNombre,
                receta_nombre_usuario = nombreUsuario,
            };

            await App.Database.SaveRecetaAsync(receta);
           
            await App.Current.MainPage.DisplayAlert(Strings.Strings.display_alert_success, Strings.Strings.display_alert_recipe + " " + nombreRecetaTxt.ToString() + " " + Strings.Strings.display_alert_stored_correctly, Strings.Strings.display_alert_aceptar);
        }

        public async Task LoadData()
        {
            paisesPicker.ItemsSource = await App.Database.GetPaisNombresAsync();

            categoriaPicker.ItemsSource = await App.Database.GetCategoriaComidaNombresAsync();
        }

        private async void refrescarPickersButton_Clicked(object sender, EventArgs e)
        {
            await LoadData();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadData();
        }
    }
}