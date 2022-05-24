using CommunityToolkit.Mvvm.Input;
using SaveYourRecipes.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SaveYourRecipes.Features.Usuarios
{
    public class CambiarContrasenaViewModel : BaseViewModel
    {
        #region Atributos
        public string nombreUsuario;
        public string contrasenaUsuario;
        public bool isRunning;
        public bool isVisible;
        public bool isEnabled;
        #endregion

        #region Propiedades
        public string nombreUsuarioTxt
        {
            get { return this.nombreUsuario; }
            set { SetValue(ref this.nombreUsuario, value); }
        }

        public string contrasenaUsuarioTxt
        {
            get { return this.contrasenaUsuario; }
            set { SetValue(ref this.contrasenaUsuario, value); }
        }

        public bool IsRunningTxt
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsVisibleTxt
        {
            get { return this.isVisible; }
            set { SetValue(ref this.isVisible, value); }
        }

        public bool IsEnabledTxt
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Commands
        public ICommand ChangePasswordCommand
        {
            get
            {
                return new RelayCommand(ChangePasswordMethod);
            }
        }
        #endregion

        #region Methods
        public async void ChangePasswordMethod()
        {
            if (string.IsNullOrEmpty(this.nombreUsuario))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debe ingresar un nombre de usuario / You must enter a user name", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(this.contrasenaUsuario))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes ingreser una contraseña / You must enter a password", "Ok");
                return;
            }

            this.IsVisibleTxt = true;
            this.IsRunningTxt = true;
            this.IsEnabledTxt = false;

            await Task.Delay(20);

            List<User> e = App.Database.GetUserChangePasswordValidate(nombreUsuario).Result;

            if (e.Count == 0)
            {
                await App.Current.MainPage.DisplayAlert("Error", "El usuario al que intentas cambiar la contraseña no existe / The user you are trying to change the password does not exist", "Ok");

                this.IsRunningTxt = false;
                this.IsVisibleTxt = false;
                this.IsEnabledTxt = true;
            }
            else if (e.Count > 0)
            {
                await App.Database.UpdateUserPassword(nombreUsuario, contrasenaUsuario);

                await App.Current.MainPage.DisplayAlert("Éxito / Success", "Contraseña de usuario actualizada / Updated user password", "Ok");

                await App.Current.MainPage.Navigation.PushModalAsync(new IniciarSesionView());

                this.IsRunningTxt = false;
                this.IsVisibleTxt = false;
                this.IsEnabledTxt = true;
            }
        }
        #endregion

        #region Constructor
        public CambiarContrasenaViewModel()
        {
            this.IsEnabledTxt = true;
        }
        #endregion
    }
}
