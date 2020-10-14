using Comparacion.Model;
using Comparacion.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Comparacion.ViewModel
{
    class DeleteViewModel : BaseViewModel
    {
        private RealmRepository realmRepository;
        private SQLiteRepository SQLiteRepository;

        private long tiempoRealm = Tiempos.watchRealmDelete;
        public long TiempoRealm
        {
            get => tiempoRealm;
            set
            {
                tiempoRealm = value;
                OnPropertyChanged("");
            }
        }
        private long tiempoSQLite = Tiempos.watchSQLiteDelete;
        public long TiempoSQLite
        {
            get => tiempoSQLite;
            set
            {
                tiempoSQLite = value;
                OnPropertyChanged("");
            }
        }

        public DeleteViewModel()
        {
            SQLiteRepository = new SQLiteRepository("MySQLite.db3");
            realmRepository = new RealmRepository();
        }

        public Command DeleteDates
        {
            get
            {
                return new Command(() =>
                {
                    this.realmRepository.DeleteAllObjectRealm();
                    this.SQLiteRepository.DeleteAllObjectSQLite();

                    TiempoRealm = Tiempos.watchRealmDelete;
                    TiempoSQLite = Tiempos.watchSQLiteDelete;
                });
            }
        }
    }
}
