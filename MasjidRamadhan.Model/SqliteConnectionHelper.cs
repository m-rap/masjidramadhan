using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace MasjidRamadhan.Model
{
    public class SqliteConnectionHelper : IDisposable
    {
        public delegate void ExecuteNonQueryEventHandler();
        public event ExecuteNonQueryEventHandler ExecuteNonQueryEvent;

        public SQLiteConnection DbConnection
        {
            get;
            set;
        }

        public string ConnectionString
        {
            get;
            set;
        }

        public SqliteConnectionHelper(string dbPath)
        {
            ConnectionString = GetConnectionString(dbPath);
        }
        
        private string GetConnectionString(string dbPath)
        {
            return "Data Source=" + dbPath + ";Version=3;";
        }

        public bool Connect()
        {
            try
            {
                if (DbConnection == null)
                    DbConnection = new SQLiteConnection(ConnectionString);
                if (DbConnection.State == ConnectionState.Open)    
                    return true;
                DbConnection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ". " + ex.StackTrace);
                return false;
            }
        }

        public void OnExecuteNonQuery()
        {
            if (ExecuteNonQueryEvent == null)
                return;
            ExecuteNonQueryEvent();
        }

        public void Dispose()
        {
            DbConnection.Dispose();
            DbConnection = null;
        }
    }
}
