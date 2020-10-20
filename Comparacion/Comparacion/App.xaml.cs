using Realms;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Comparacion
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            //Cambiar modelo Realm
            var con = RealmConfiguration.DefaultConfiguration;
            con.SchemaVersion = 3;
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
