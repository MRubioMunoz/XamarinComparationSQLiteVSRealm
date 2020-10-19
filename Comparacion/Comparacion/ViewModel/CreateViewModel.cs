using Comparacion.Model;
using Comparacion.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace Comparacion.ViewModel
{
    class CreateViewModel : BaseViewModel
    {
        private RealmRepository realmRepository;
        private SQLiteRepository SQLiteRepository;

        private long tiempoRealm = Tiempos.watchRealmCreate;
        public long TiempoRealm
        {
            get => tiempoRealm;
            set
            {
                tiempoRealm = value;
                OnPropertyChanged("");
            }
        }
        private long tiempoSQLite = Tiempos.watchSQLiteCreate;
        public long TiempoSQLite
        {
            get => tiempoSQLite;
            set
            {
                tiempoSQLite = value;
                OnPropertyChanged("");
            }
        }

        private Color colorRealm = Color.White;
        public Color ColorRealm
        {
            get => colorRealm;
            set
            {
                colorRealm = value;
                OnPropertyChanged("");
            }
        }

        private Color colorSQLite = Color.White;
        public Color ColorSQLite
        {
            get => colorSQLite;
            set
            {
                colorSQLite = value;
                OnPropertyChanged("");
            }
        }

        public CreateViewModel()
        {
            SQLiteRepository = new SQLiteRepository("MySQLite.db3");
            realmRepository = new RealmRepository();
        }

        public Command CreateDates
        {
            get
            {
                return new Command(() =>
                {
                    this.realmRepository.CreateObjectRealm();
                    this.SQLiteRepository.CreateAllObjectsSQLite();

                    TiempoRealm = Tiempos.watchRealmCreate;
                    TiempoSQLite = Tiempos.watchSQLiteCreate;
                    this.cambiarColores();

                });
            }
        }

        public void cambiarColores()
        {
            if (TiempoRealm < TiempoSQLite)
            {
                ColorRealm = Tiempos.lentoColor;
                ColorSQLite = Tiempos.rapidoColor;
            }
            else
            {
                ColorRealm = Tiempos.rapidoColor;
                ColorSQLite = Tiempos.lentoColor;
            }
        }
    }
}
