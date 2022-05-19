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
using System.Reflection;
using System.IO;
using SaveYourRecipes.Data;
using System.Collections.ObjectModel;

namespace SaveYourRecipes.Features.MisRecetas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MisRecetasView : ContentPage
    {
        public ObservableCollection<Receta> Recetas { get; set; } = new ObservableCollection<Receta>();

        public MisRecetasView()
        {
            InitializeComponent();

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("SaveYourRecipes.SaveYourRecipes.db"))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);

                    File.WriteAllBytes(SQLiteHelper.DbPath, memoryStream.ToArray());
                }
            } 
        }

        private async void listaRecetas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }

        private async void mostrarDatos_Clicked(object sender, EventArgs e)
        {
            SQLiteHelper repository = new SQLiteHelper();
            foreach (var receta in repository.recetaList())
            {
                Recetas.Add(receta);
            }

            BindingContext = this;
        }

        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            
        }
    }
}