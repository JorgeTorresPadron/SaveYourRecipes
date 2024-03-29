﻿using SaveYourRecipes.Data;
using SaveYourRecipes.Features.Usuarios;
using System;
using System.IO;
using Xamarin.Forms;

namespace SaveYourRecipes
{
    public partial class App : Application
    {

        #region Database
        static DatabaseQuerys database;

        public static DatabaseQuerys Database
        {
            get
            {
                if (database == null)
                {
                    database = new DatabaseQuerys(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SaveYourRecipesDB.db3"));
                }
                return database;
            }

            set { database = value; }
        }
        #endregion

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new IniciarSesionView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
