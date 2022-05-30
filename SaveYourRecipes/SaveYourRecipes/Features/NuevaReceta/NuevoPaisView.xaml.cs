using SaveYourRecipes.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveYourRecipes.Features.NuevaReceta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevoPaisView : ContentPage
    {
        public NuevoPaisView()
        {
            InitializeComponent();
            ListaMostrar();
        }

        private async void nuevoPaisButton_Clicked(object sender, EventArgs e)
        {
            Pais pais = new Pais()
            {
                pais_nombre = nuevoPaisTxt.Text,
            };

            await App.Database.SavePaisAsync(pais);
            await DisplayAlert("Éxito / Success", "Categoría almacenada correctamente / Successfully stored category", "Ok");

            ListaMostrar();
        }

        private async void lstPaises_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Pais)e.SelectedItem;
            nuevoPaisButton.IsVisible = false;
            modificarPaisButton.IsVisible = true;
            eliminarPaisButton.IsVisible = true;

            if (!string.IsNullOrEmpty(obj.pais_id.ToString()))
            {
                var pais = await App.Database.GetPaisPorId(obj.pais_id);
                if (pais != null)
                {
                    idPaisTxt.Text = pais.pais_id.ToString();
                    nuevoPaisTxt.Text = pais.pais_nombre.ToString();
                }

                idPaisTxt.IsVisible = false;
            }
        }

        public async void ListaMostrar()
        {
            var paisesList = await App.Database.GetPaisAsync();
            if (paisesList != null)
            {
                lstPaises.ItemsSource = paisesList;
            }
        }

        private async void modificarPaisButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(idPaisTxt.Text))
            {
                Pais pais = new Pais()
                {
                    pais_id = Convert.ToInt32(idPaisTxt.Text),
                    pais_nombre = nuevoPaisTxt.Text,
                };
                await App.Database.SavePaisAsync(pais);
                await DisplayAlert("Éxito / Success", "Categoría modificada correctamente / Successfully modified category", "Ok");

                modificarPaisButton.IsVisible = false;
                eliminarPaisButton.IsVisible = false;
                nuevoPaisButton.IsVisible = true;

                nuevoPaisButton.Text = "";

                ListaMostrar();
            }
        }

        private async void eliminarPaisButton_Clicked(object sender, EventArgs e)
        {
            var pais = await App.Database.GetPaisPorId(Convert.ToInt32(idPaisTxt.Text));

            if (pais != null)
            {
                await App.Database.DeletePaisAsync(pais);
                await DisplayAlert("Eliminado / Deleted", "Categoría eliminada correctamente / Successfully deleted category", "Ok");

                modificarPaisButton.IsVisible = false;
                eliminarPaisButton.IsVisible = false;
                nuevoPaisButton.IsVisible = true;

                ListaMostrar();
            }

        }
    }
}