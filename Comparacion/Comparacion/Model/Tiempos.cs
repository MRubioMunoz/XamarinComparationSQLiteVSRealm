using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Comparacion.Model
{
    public class Tiempos
    {
        public static long watchRealmCreate;
        public static long watchSQLiteCreate;

        public static long watchRealmDelete;
        public static long watchSQLiteDelete;

        public static long watchRealmUpdate;
        public static long watchSQLiteUpdate;

        public static long watchRealmReadAll;
        public static long watchSQLiteReadAll;
        
        public static Color rapidoColor = Color.FromHex("A350A6");
        public static Color lentoColor = Color.FromHex("60C967");
    }
}
