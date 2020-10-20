﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Comparacion.Model
{
    public class ObjetoSQLite
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int dato { get; set; }
        public string descripcion { get; set; }
        public string nuevoDato { get; set; }

        public ObjetoSQLite(int id, int dato)
        {
            this.id = id;
            this.dato = dato;
            this.descripcion = id.ToString() + dato.ToString();
            this.nuevoDato = descripcion + "nuevo";
        }

        public ObjetoSQLite() { }

    }
}