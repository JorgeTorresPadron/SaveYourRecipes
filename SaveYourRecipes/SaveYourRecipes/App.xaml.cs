using SaveYourRecipes.Data;
using SQLite;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveYourRecipes
{
    public partial class App : Application
    {
        // static SQLiteHelper db;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPageView();
        }
        /*
        public static SQLiteHelper SQLiteDB
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBSaveYourRecipes.db"));
                }
                return db;
            }
        }
        */

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
