using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace MasjidRamadhan
{
    public class MasjidRamadhanConnection
    {
        public SQLiteConnection Connection;
        public string ConnectionString;

        public MasjidRamadhanConnection(string dbPath)
        {
            ConnectionString = GetConnectionString(dbPath);
        }
        
        private string GetConnectionString(string dbPath)
        {
            return "Data Source=" + dbPath + ";Version=3;";
        }

        public static bool Connect(ref MasjidRamadhanConnection connection)
        {
            try
            {
                if (connection.Connection != null)
                    return true;
                connection.Connection = new SQLiteConnection(connection.ConnectionString);
                connection.Connection.Open();
                string sql =
                    "CREATE TABLE IF NOT EXISTS sumbangan (" +
                    "sbg_id          INT PRIMARY KEY AUTOINCREMENT," +
                    "sbg_tanggal     DATETIME," +
                    "sbg_nama        TEXT," +
                    "sbg_alamat      TEXT," +
                    "sbg_jumlah      REAL," +
                    "sbg_keterangan  TEXT);";
                SQLiteCommand cmd = new SQLiteCommand(sql, connection.Connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                connection = null;
                Console.WriteLine(ex.Message + ". " + ex.StackTrace);
                return false;
            }
        }

        public static void Close(ref MasjidRamadhanConnection connection)
        {
            if (connection == null)
                return;
            connection.Connection.Close();
            connection.Connection.Dispose();
            connection.Connection = null;
        }
    }
}
