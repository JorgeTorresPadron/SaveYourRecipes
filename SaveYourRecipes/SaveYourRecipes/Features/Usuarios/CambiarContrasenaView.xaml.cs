using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveYourRecipes.Features.Usuarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CambiarContrasenaView : ContentPage
    {
        public CambiarContrasenaView()
        {
            InitializeComponent();
            BindingContext = new CambiarContrasenaViewModel();
        }

        private async void iniciarSesionButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new IniciarSesionView());
        }
    }
}