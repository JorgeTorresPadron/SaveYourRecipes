using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using SaveYourRecipes.Features.Usuarios;
using SaveYourRecipes.Models;

namespace SaveYourRecipes.Features.NuevaReceta
{
    public class NuevaCategoriaViewModel : BaseViewModel
    {
        #region Atributos
        public string nombreCategoriaComida;

        public bool isRunning;
        public bool isVisible;
        public bool isEnabled;
        #endregion

        #region Propiedades
        public string nombreCategoriaComidaTxt
        {
            get { return this.nombreCategoriaComida; }
            set { SetValue(ref this.nombreCategoriaComida, value); }
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
        public ICommand NewCategoryCommand
        {
            get
            {
                return new RelayCommand(NewCategoryMethod);
            }
        }
        #endregion

        #region Methods
        private async void NewCategoryMethod()
        {
            if (string.IsNullOrEmpty(this.nombreCategoriaComida))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes escribir la categoría de comida que quieres añadir / You must type the food category you want to add", "Ok");
                return;
            }

            this.IsVisibleTxt = true;
            this.IsRunningTxt = true;
            this.IsEnabledTxt = false;

            await Task.Delay(1000);

            var categoriaComida = new Categoria_comida
            {
                categoria_comida_nombre = nombreCategoriaComida,
            };

            await App.Database.SaveCategoriaComidaAsync(categoriaComida);

            await App.Current.MainPage.DisplayAlert("Éxito / Success", "Categoría de comida / Food category " + nombreCategoriaComida.ToString() + " almacenada correctamente / stored correctly", "Ok");

            this.IsRunningTxt = false;
            this.IsVisibleTxt = false;
            this.IsEnabledTxt = true;

            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        #endregion

        #region Constructor
        public NuevaCategoriaViewModel()
        {
            IsEnabledTxt = true;
        }

        #endregion
    }
}
