using Comparacion.Model;
using Comparacion.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;


namespace Comparacion.ViewModel
{
    class ReadViewModel : BaseViewModel
    {
        private RealmRepository realmRepository;
        private SQLiteRepository SQLiteRepository;

        private List<ObjetoSQLite> objetosSQLite = new List<ObjetoSQLite>();
        public List<ObjetoSQLite> ObjetosSQLite
        {
            get => objetosSQLite;
            set
            {
                objetosSQLite = value;
                OnPropertyChanged("Objetos");
            }
        }

        private ObservableCollection<ObjetoRealmN> objetosRealm;
        public ObservableCollection<ObjetoRealmN> ObjetosRealm
        {
            get => objetosRealm;
            set
            {
                this.objetosRealm = value;
                OnPropertyChanged("Objetos");
            }
        }

        //Color ganador #60C967
        //Color perdedor #A350A6

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
        public Color ColorSQLite {
            get => colorSQLite;
            set
            {
                colorSQLite = value;
                OnPropertyChanged("");
            }
        }

        private long tiempoRealm = Tiempos.watchRealmReadAll;
        public long TiempoRealm
        {
            get => tiempoRealm;
            set
            {
                tiempoRealm = value;
                OnPropertyChanged("");
            }
        }
        private long tiempoSQLite = Tiempos.watchSQLiteReadAll;
        public long TiempoSQLite
        {
            get => tiempoSQLite;
            set
            {
                tiempoSQLite = value;
                OnPropertyChanged("");
            }
        }

        public ReadViewModel()
        {
            SQLiteRepository = new SQLiteRepository("MySQLite.db3");
            realmRepository = new RealmRepository();
        }

        public Command ReadDates
        {
            get
            {
                return new Command(() =>
                {
                    ObjetosRealm = new ObservableCollection<ObjetoRealmN>(realmRepository.GetAllObjectRealm());
                    ObjetosSQLite = SQLiteRepository.GetAllObjectsSQLite().Result;

                    TiempoRealm = Tiempos.watchRealmReadAll;
                    TiempoSQLite = Tiempos.watchSQLiteReadAll;

                   this.cambiarColores();

                });
            }
        }

        public void cambiarColores() 
        {
            if( TiempoRealm < TiempoSQLite)
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
