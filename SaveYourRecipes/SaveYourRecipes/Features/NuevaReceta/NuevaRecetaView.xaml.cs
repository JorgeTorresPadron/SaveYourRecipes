using SaveYourRecipes.Features.MisRecetas;
using SaveYourRecipes.Models;
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
            LoadData();
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
                await App.Current.MainPage.DisplayAlert("Error", "Debes escribir un nombre para la receta / You must write a name for the recipe", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(this.descripcionRecetaTxt.Text))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes escribir una descripción para la receta / You must write a description for the recipe", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(this.pasosRecetaTxt.Text))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes escribir los pasos de la receta / You must write the steps of the recipe", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(this.ingredientesRecetaTxt.Text))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes escribir los ingredientes de la receta / You must write the ingredients of the recipe", "Ok");
                return;
            }

            if (this.tiempoPreparacionTxt.Equals(null) | this.tiempoPreparacionTxt.Equals(""))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes escribir el tiempo de preparación de la receta / You must write the recipe preparation time", "Ok");
                return;
            }

            if (this.tiempoCocinaTxt.Equals(null) | this.tiempoCocinaTxt.Equals(""))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes escribir el tiempo de cocina de la receta / You must write the cooking time of the recipe", "Ok");
                return;
            }

            var paisSelectedItem = paisesPicker.SelectedItem as Pais;
            var paisNombre = paisSelectedItem.pais_nombre;
            var categoriaSelectedItem = categoriaPicker.SelectedItem as Categoria_comida;
            var categoriaNombre = categoriaSelectedItem.categoria_comida_nombre;

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
            };

            await App.Database.SaveRecetaAsync(receta);
           
            await App.Current.MainPage.DisplayAlert("Éxito / Success", "Receta / Recipe " + nombreRecetaTxt.ToString() + " almacenada correctamente / stored correctly", "Ok");
            await App.Current.MainPage.Navigation.PushModalAsync(new MisRecetasView());
        }

        public async Task LoadData()
        {
            paisesPicker.ItemsSource = await App.Database.GetPaisNombresAsync();

            categoriaPicker.ItemsSource = await App.Database.GetCategoriaComidaNombresAsync();
        }

        private void refrescarPickersButton_Clicked(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}