using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comparacion.Model
{
    public class ObjetoRealmN : RealmObject
    {

        [PrimaryKey]
        public int id { get; set; }
        public int dato { get; set; }
        public string descripcion { get; set; }

        public ObjetoRealmN(int id, int dato)
        {
            this.id = id;
            this.dato = dato;
            this.descripcion = id.ToString() + dato.ToString();
        }
        public ObjetoRealmN() { }

    }

}
