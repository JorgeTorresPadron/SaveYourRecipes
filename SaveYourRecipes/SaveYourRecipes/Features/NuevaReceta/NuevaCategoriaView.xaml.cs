using SaveYourRecipes.Models;
using SaveYourRecipes.Service;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveYourRecipes.Features.NuevaReceta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevaCategoriaView : ContentPage
    {
        public NuevaCategoriaView()
        {
            InitializeComponent();
            ListaMostrar();
        }

        private async void nuevaCategoriaButton_Clicked(object sender, EventArgs e)
        {
            string nombreUsuario = CompartirInformacion.nombreUsuarioShare;

            Categoria_comida categoria_Comida = new Categoria_comida()
            {
                categoria_comida_nombre = nuevaCategoriaTxt.Text,
                categoria_comida_nombre_usuario = nombreUsuario,
            };

            await App.Database.SaveCategoriaComidaAsync(categoria_Comida);
            await DisplayAlert(Strings.Strings.display_alert_success, Strings.Strings.display_alert_category_stored, Strings.Strings.display_alert_aceptar);

            ListaMostrar();

        }

        private async void lstCategorias_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Categoria_comida)e.SelectedItem;
            nuevaCategoriaButton.IsVisible = false;
            modificarCategoriaButton.IsVisible = true;
            eliminarCategoriaButton.IsVisible = true;

            if (!string.IsNullOrEmpty(obj.categoria_comida_id.ToString()))
            {
                var categoria = await App.Database.GetCategoriaComidaPorId(obj.categoria_comida_id);
                if (categoria != null)
                {
                    idCategoriaTxt.Text = categoria.categoria_comida_id.ToString();
                    nuevaCategoriaTxt.Text = categoria.categoria_comida_nombre.ToString();
                }

                idCategoriaTxt.IsVisible = false;
            }
        }

        public async void ListaMostrar()
        {
            string nombreUsuario = CompartirInformacion.nombreUsuarioShare;
            var categoriaList = await App.Database.GetCategoriaComidaAsync(nombreUsuario);
            if (categoriaList != null)
            {
               lstCategorias.ItemsSource = categoriaList;
            }
        }

        private async void modificarCategoriaButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(idCategoriaTxt.Text))
            {
                string nombreUsuario = CompartirInformacion.nombreUsuarioShare;
                Categoria_comida categoria_Comida = new Categoria_comida()
                {
                    categoria_comida_id = Convert.ToInt32(idCategoriaTxt.Text),
                    categoria_comida_nombre = nuevaCategoriaTxt.Text,
                    categoria_comida_nombre_usuario = nombreUsuario,
                };
                await App.Database.SaveCategoriaComidaAsync(categoria_Comida);
                await DisplayAlert(Strings.Strings.display_alert_eliminado, Strings.Strings.display_alert_category_updated, Strings.Strings.display_alert_aceptar);

                modificarCategoriaButton.IsVisible = false;
                eliminarCategoriaButton.IsVisible = false;
                nuevaCategoriaButton.IsVisible = true;

                nuevaCategoriaTxt.Text = "";

                ListaMostrar();
            }
        }

        private async void eliminarCategoriaButton_Clicked(object sender, EventArgs e)
        {
            var categoria = await App.Database.GetCategoriaComidaPorId(Convert.ToInt32(idCategoriaTxt.Text));

            if (categoria != null)
            {
                await App.Database.DeleteCategoriaComidaAsync(categoria);
                await DisplayAlert(Strings.Strings.display_alert_eliminado, Strings.Strings.display_alert_category_deleted, Strings.Strings.display_alert_aceptar);

                modificarCategoriaButton.IsVisible = false;
                eliminarCategoriaButton.IsVisible = false;
                nuevaCategoriaButton.IsVisible = true;

                ListaMostrar();
            }
        }
    }
}