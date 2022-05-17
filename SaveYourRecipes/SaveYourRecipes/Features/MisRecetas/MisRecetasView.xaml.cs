using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SaveYourRecipes.Models;
using SaveYourRecipes.Features.Editar;
using SaveYourRecipes.Service;

namespace SaveYourRecipes.Features.MisRecetas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MisRecetasView : ContentPage
    {
        public MisRecetasView()
        {
            InitializeComponent();
        }

        private async void listaRecetas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Receta)e.SelectedItem;
            if (!string.IsNullOrEmpty(obj.receta_id.ToString()))
            {
                var receta = await App.SQLiteDB.GetRecetaByIdAsync(obj.receta_id);
                CompartirInformacion.idReceta = receta;
            }
            await Navigation.PushModalAsync(new EditarRecetaView());
        }

        private async void mostrarDatos_Clicked(object sender, EventArgs e)
        {
            var recetaList = await App.SQLiteDB.ReadRecetasAsync();
            if (recetaList != null)
            {
                listaRecetas.ItemsSource = recetaList;
            }
        }

        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var rec = item.CommandParameter as Receta;
            var result = await DisplayAlert("Eliminar", $"¿Desea eliminar la receta {rec.receta_nombre}?", "Yes", "No");
            if (result)
            {
                await App.SQLiteDB.EliminarReceta(rec);
                await App.SQLiteDB.ReadRecetasAsync();
            }
        }
    }
}