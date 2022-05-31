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

        private void guardarRecetaButton_Clicked(object sender, EventArgs e)
        {

        }

        public async Task LoadData()
        {
            paisesPicker.ItemsSource = await App.Database.GetPaisAsync();

            categoriaPicker.ItemsSource = await App.Database.GetCategoriaComidaAsync();
        }
    }
}