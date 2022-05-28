using CommunityToolkit.Mvvm.Input;
using SaveYourRecipes.Features.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SaveYourRecipes.Models;
using SaveYourRecipes.Features.MisRecetas;

namespace SaveYourRecipes.Features.NuevaReceta
{
    public class NuevaRecetaViewModel : BaseViewModel
    {
        #region Atributos
        public string nombreReceta;
        public string descripcionReceta;
        public string pasosReceta;
        public string ingredientesReceta;
        public int tiempoPreparacionReceta;
        public int tiempoCocinaReceta;
        public object paisPickerSource;
        public object categoriaPickerSource;

        public bool isRunning;
        public bool isVisible;
        public bool isEnabled;
        #endregion

        #region Propiedades
        public string nombreRecetaTxt
        {
            get { return this.nombreReceta; }
            set { SetValue(ref this.nombreReceta, value); }
        }

        public string descripcionRecetaTxt
        {
            get { return this.descripcionReceta; }
            set { SetValue(ref this.descripcionReceta, value); }
        }

        public string pasosRecetaTxt
        {
            get { return this.pasosReceta; }
            set { SetValue(ref this.pasosReceta, value); }
        }

        public string ingredientesRecetaTxt
        {
            get { return this.ingredientesReceta; }
            set { SetValue(ref this.ingredientesReceta, value); }
        }

        public int tiempoPreparacionRecetaTxt
        {
            get { return this.tiempoPreparacionReceta; }
            set { SetValue(ref this.tiempoPreparacionReceta, value); }
        }

        public int tiempoCocinaRecetaTxt
        {
            get { return this.tiempoCocinaReceta; }
            set {  SetValue(ref this.tiempoCocinaReceta, value); }
        }

        public object PaisPickerSource
        {
            get { return this.paisPickerSource; }
            set { SetValue(ref this.paisPickerSource, value); }
        }

        public object CategoriaPickerSource
        {
            get { return this.categoriaPickerSource; }
            set { SetValue(ref this.categoriaPickerSource, value); }
        }

        public bool IsEnabledTxt
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        public bool IsVisibleTxt
        {
            get { return this.isVisible; }
            set { SetValue(ref this.isVisible, value); }
        }

        public bool IsRunningTxt
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        #endregion

        #region Commands
        public ICommand NewRecipeCommand
        {
            get
            {
                return new RelayCommand(NewRecipeMethod);
            }
        }
        #endregion

        #region Methods
        private async void NewRecipeMethod()
        {
            if (string.IsNullOrEmpty(this.nombreReceta))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes escribir un nombre para la receta / You must write a name for the recipe", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(this.descripcionReceta))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes escribir una descripción para la receta / You must write a description for the recipe", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(this.pasosReceta))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes escribir los pasos de la receta / You must write the steps of the recipe", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(this.ingredientesReceta))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes escribir los ingredientes de la receta / You must write the ingredients of the recipe", "Ok");
                return;
            }

            if (this.tiempoPreparacionReceta.Equals(null) | this.tiempoPreparacionReceta.Equals(""))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes escribir el tiempo de preparación de la receta / You must write the recipe preparation time", "Ok");
                return;
            }

            if (this.tiempoCocinaReceta.Equals(null) | this.tiempoCocinaReceta.Equals(""))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes escribir el tiempo de cocina de la receta / You must write the cooking time of the recipe", "Ok");
                return;
            }

            this.IsVisibleTxt = true;
            this.IsRunningTxt = true;
            this.IsEnabledTxt = false;

            await Task.Delay(1000);

            var receta = new Receta
            {
                receta_nombre = nombreReceta,
                receta_descripcion = descripcionReceta,
                receta_pasos_receta = pasosReceta,
                receta_ingredientes = ingredientesReceta,
                tiempo_preparacion = tiempoPreparacionReceta,
                tiempo_cocina = tiempoCocinaReceta,
            };

            await App.Database.SaveRecetaAsync(receta);

            await App.Current.MainPage.DisplayAlert("Éxito / Success", "Receta / Recipe " + nombreReceta.ToString() + " almacenada correctamente / stored correctly", "Ok");

            this.IsRunningTxt = false;
            this.IsVisibleTxt = false;
            this.IsEnabledTxt = true;

            await App.Current.MainPage.Navigation.PushModalAsync(new MisRecetasView());
        }

        public async Task LoadData()
        {
            this.PaisPickerSource = await App.Database.GetPaisAsync();
            this.CategoriaPickerSource = await App.Database.GetCategoriaComidaAsync();
        }
        #endregion

        #region Constructor
        public NuevaRecetaViewModel()
        {
            IsEnabledTxt = true;
            LoadData();
        }

        #endregion
    }
}
