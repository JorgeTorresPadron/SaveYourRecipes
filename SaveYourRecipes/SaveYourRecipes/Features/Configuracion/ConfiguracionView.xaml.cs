using SaveYourRecipes.Features.AcercaDe;
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

        private void cambiarIdiomaButton_Clicked(object sender, EventArgs e)
        {
            
        }

        private void acercaDeButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AcercaDeView());
        }
    }
}