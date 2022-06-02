using SaveYourRecipes.Features.AcercaDe;
using SaveYourRecipes.Features.Usuarios;
using SaveYourRecipes.Service;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveYourRecipes.Features.Configuracion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfiguracionView : ContentPage
    {
        public ConfiguracionView()
        {
            InitializeComponent();
        }

        private async void acercaDeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AcercaDeView());
        }

        private async void cerrarSesionButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new IniciarSesionView());
        }

        private async void eliminarUsuarioButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EliminarUsuarioView());
        }
    }
}