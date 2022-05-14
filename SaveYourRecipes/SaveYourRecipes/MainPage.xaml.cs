using SaveYourRecipes.Data;
using SaveYourRecipes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SaveYourRecipes
{
    public partial class MainPageView : TabbedPage
    {
        public MainPageView()
        {
            InitializeComponent();

            //Solo hacer esto la primera vez que se abre la app
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("SaveYourRecipes.DBSaveYourRecipes.db"))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);

                    File.WriteAllBytes(IngredientesRepository.DbPath, memoryStream.ToArray());
                }
            }
        }
    }
}
