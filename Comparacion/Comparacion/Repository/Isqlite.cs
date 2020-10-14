using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comparacion.Repository
{
    public interface Isqlite
    {
        SQLiteAsyncConnection GetConnection();
    }
}
