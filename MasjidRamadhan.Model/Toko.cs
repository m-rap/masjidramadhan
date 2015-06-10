using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace MasjidRamadhan.Model
{
    public class Toko : BaseModel
    {
        public Toko(SqliteConnectionHelper connection)
            : base(connection)
        {
        }

        public int Insert(string nama, string alamat)
        {
            ExecuteNonQuery(
                "INSERT INTO toko (tko_nama, tko_alamat) VALUES (@namaParam, @alamatParam)",
                new SQLiteParameter[] {
                    new SQLiteParameter("@namaParam", DbType.String) { Value = nama },
                    new SQLiteParameter("@alamatParam", DbType.String) { Value = alamat },
                }
            );
            return (int)connection.DbConnection.LastInsertRowId;
        }

        public int GetId(string nama, string alamat)
        {
            if (!connection.Connect())
                return -1;
            using (SQLiteCommand cmd = connection.DbConnection.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "SELECT * FROM toko WHERE tko_nama = @namaParam AND tko_alamat = @alamatParam;";
                cmd.Parameters.AddRange(
                    new SQLiteParameter[] {
                        new SQLiteParameter("@namaParam", DbType.String) { Value = nama },
                        new SQLiteParameter("@alamatParam", DbType.String) { Value = alamat },
                    }
                );
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    int id = -1;
                    while (reader.Read())
                    {
                        id = int.Parse(reader["tko_id"].ToString());
                    }
                    return id;
                }
            }
        }
    }
}
