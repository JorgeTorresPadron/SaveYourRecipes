using System;
using System.Collections.ObjectModel;
using SaveYourRecipes.Models;
using SaveYourRecipes.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveYourRecipes.Features.MisRecetas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MisRecetasView : ContentPage
    {
        public ObservableCollection<Receta> Recetas { get; set; } = new ObservableCollection<Receta>();

        public MisRecetasView()
        {
            InitializeComponent();
            ListaMostrar();

        }

        private async void lstRecetas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Receta)e.SelectedItem;
            mostrarDatos.IsVisible = false;
            eliminarDatos.IsVisible = true;

            if (!string.IsNullOrEmpty(obj.receta_id.ToString()))
            {
                var receta = await App.Database.GetRecetaIdAsync(obj.receta_id);
                if (receta != null)
                {
                    idRecetaTxt.Text = receta.receta_id.ToString();
                }

                idRecetaTxt.IsVisible = false;
            }
        }

        public async void ListaMostrar()
        {
            string nombreUsuario = CompartirInformacion.nombreUsuarioShare;
            var recetaList = await App.Database.GetRecipesOfMyUser(nombreUsuario);
            if (recetaList != null)
            {
                lstRecetas.ItemsSource = recetaList;
            }
        }

        private void mostrarDatos_Clicked(object sender, EventArgs e)
        {
            ListaMostrar();
        }

        private async void eliminarDatos_Clicked(object sender, EventArgs e)
        {
            var receta = await App.Database.GetRecetaIdAsync(Convert.ToInt32(idRecetaTxt.Text));

            if (receta != null)
            {
                await App.Database.DeleteRecetaAsync(receta);
                await DisplayAlert(Strings.Strings.display_alert_eliminado, Strings.Strings.display_alert_receta_eliminada, Strings.Strings.display_alert_aceptar);


                eliminarDatos.IsVisible = false;
                mostrarDatos.IsVisible = true;

                ListaMostrar();
            }
        }
    }
}