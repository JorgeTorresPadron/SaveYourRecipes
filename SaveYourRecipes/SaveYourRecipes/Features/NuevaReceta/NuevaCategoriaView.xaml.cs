using SaveYourRecipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Categoria_comida categoria_Comida = new Categoria_comida()
            {
                categoria_comida_nombre = nuevaCategoriaTxt.Text,
            };

            await App.Database.SaveCategoriaComidaAsync(categoria_Comida);
            await DisplayAlert("Éxito / Success", "Categoría almacenada correctamente / Successfully stored category", "Ok");

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
            var categoriaList = await App.Database.GetCategoriaComidaAsync();
            if (categoriaList != null)
            {
               lstCategorias.ItemsSource = categoriaList;
            }
        }

        private async void modificarCategoriaButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(idCategoriaTxt.Text))
            {
                Categoria_comida categoria_Comida = new Categoria_comida()
                {
                    categoria_comida_id = Convert.ToInt32(idCategoriaTxt.Text),
                    categoria_comida_nombre = nuevaCategoriaTxt.Text,
                };
                await App.Database.SaveCategoriaComidaAsync(categoria_Comida);
                await DisplayAlert("Éxito / Success", "Categoría modificada correctamente / Successfully modified category", "Ok");

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
                await DisplayAlert("Eliminado / Deleted", "Categoría eliminada correctamente / Successfully deleted category", "Ok");

                modificarCategoriaButton.IsVisible = false;
                eliminarCategoriaButton.IsVisible = false;
                nuevaCategoriaButton.IsVisible = true;

                ListaMostrar();
            }
        }
    }
}