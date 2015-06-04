using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace MasjidRamadhan.Model
{
    public class BaseModel
    {
        protected SqliteConnectionHelper connection;

        public BaseModel(SqliteConnectionHelper connection)
        {
            this.connection = connection;
        }

        public int ExecuteNonQuery(string sql, SQLiteParameter[] parameters = null)
        {
            if (!connection.Connect())
                return 0;
            using (SQLiteCommand cmd = connection.DbConnection.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                int result = cmd.ExecuteNonQuery();
                connection.OnExecuteNonQuery();
                return result;
            }
        }

        public DataTable ExecuteQuery(string sql, SQLiteParameter[] parameters = null)
        {
            if (!connection.Connect())
                return null;
            using (SQLiteCommand cmd = connection.DbConnection.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
