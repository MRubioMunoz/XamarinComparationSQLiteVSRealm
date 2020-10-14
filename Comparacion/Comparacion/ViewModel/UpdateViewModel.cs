using Comparacion.Model;
using Comparacion.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Comparacion.ViewModel
{
    class UpdateViewModel : BaseViewModel { 

    private RealmRepository realmRepository;
    private SQLiteRepository SQLiteRepository;

    private long tiempoRealm = Tiempos.watchRealmUpdate;
    public long TiempoRealm
    {
        get => tiempoRealm;
        set
        {
            tiempoRealm = value;
            OnPropertyChanged("");
        }
    }
    private long tiempoSQLite = Tiempos.watchSQLiteUpdate;
    public long TiempoSQLite
    {
        get => tiempoSQLite;
        set
        {
            tiempoSQLite = value;
            OnPropertyChanged("");
        }
    }

    public UpdateViewModel()
    {
        SQLiteRepository = new SQLiteRepository("MySQLite.db3");
        realmRepository = new RealmRepository();
    }

    public Command UpdateDates
    {
        get
        {
            return new Command(() =>
            {
                this.realmRepository.UpdateAllObjectRealm();
                this.SQLiteRepository.UpdateAllObjectSQLite();

                TiempoRealm = Tiempos.watchRealmUpdate;
                TiempoSQLite = Tiempos.watchSQLiteUpdate;
            });
        }
    }
}
}

