using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveYourRecipes.Features.MisRecetas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MisRecetasView : ContentPage
    {
        public MisRecetasView()
        {
            InitializeComponent();
        }

        private async void mostrarDatos_Clicked(object sender, EventArgs e)
        {
            var recetaList = await App.SQLiteDB.GetRecetasAsync();
            if (recetaList != null)
            {
                listaRecetas.ItemsSource = recetaList;
            }
        }
    }
}