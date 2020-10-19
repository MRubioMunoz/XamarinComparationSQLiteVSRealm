using Comparacion.Model;
using Realms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Comparacion.Repository
{
    class RealmRepository
    {
        private Realm connection;
        Transaction transaction;

        public RealmRepository()
        {
            connection = Realm.GetInstance();
        }

        public List<ObjetoRealmN> GetAllObjectRealm()
        {
            Stopwatch watchRealm = Stopwatch.StartNew();
            List<ObjetoRealmN> list = connection.All<ObjetoRealmN>().ToList();
            watchRealm.Stop();
            Tiempos.watchRealmReadAll = watchRealm.ElapsedMilliseconds;
            return list;

        }

        public void CreateObjectRealm()
        {
            Stopwatch watchRealm = Stopwatch.StartNew();
            transaction = connection.BeginWrite();

            for (int i = 0; i < 1000; i++)
            {
                connection.Add(new ObjetoRealmN(i, i));
            }
            transaction.Commit();
            watchRealm.Stop();
            Tiempos.watchRealmCreate = watchRealm.ElapsedMilliseconds;
        }

        public ObjetoRealmN GetOneObjectRealm(int id)
        {
            return GetAllObjectRealm().FirstOrDefault(i => i.id == id);
        }

        public void DeleteObjectRealm(int id)
        {

            ObjetoRealmN obj = this.GetOneObjectRealm(id);
            if (obj != null)
            {
                using (Transaction trans = this.connection.BeginWrite())
                {
                    this.connection.Remove(obj);
                    trans.Commit();
                }
            }
        }

        //STOPWATCH PONEEER

        public void DeleteAllObjectRealm()
        {
            Stopwatch watchRealm = Stopwatch.StartNew();
            using (Transaction trans = this.connection.BeginWrite())
            {
                this.connection.RemoveAll();
                trans.Commit();
            }
            watchRealm.Stop();
            Tiempos.watchRealmDelete = watchRealm.ElapsedMilliseconds;
        }

        public void UpdateAllObjectRealm()
        {
            Stopwatch watchRealm = Stopwatch.StartNew();
            transaction = connection.BeginWrite();
            {
                for (int i = 0; i < this.GetAllObjectRealm().Count; i++)
                {
                    ObjetoRealmN obj = this.GetOneObjectRealm(i);
                    obj.dato += 1;
                    obj.descripcion += i;
                    
                }
                transaction.Commit();
            }
            watchRealm.Stop();
            Tiempos.watchRealmUpdate = watchRealm.ElapsedMilliseconds;
        }
    }
}