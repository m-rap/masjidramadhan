using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace MasjidRamadhan.Model
{
    public class Person : BaseModel
    {
        public static List<string> NamaCache = new List<string>();
        public static List<string> AlamatCache = new List<string>();

        public Person(SqliteConnectionHelper connection) : base(connection)
        {
        }

        public int Insert(string nama, string alamat)
        {
            int res = ExecuteNonQuery(
                "INSERT INTO person " +
                "(prs_nama, prs_alamat) VALUES " +
                "(@namaParam, @alamatParam);",
                new SQLiteParameter[] {
                    new SQLiteParameter("@namaParam", DbType.String) { Value = nama },
                    new SQLiteParameter("@alamatParam", DbType.String) { Value = alamat },
                }
            );
            if (res > 0)
            {
                NamaCache.Add(nama);
                AlamatCache.Add(alamat);
                return (int)connection.DbConnection.LastInsertRowId;
            }
            return -1;
        }

        public DataTable Get()
        {
            DataTable persons = ExecuteQuery("SELECT * FROM person");
            NamaCache = new List<string>();
            AlamatCache = new List<string>();
            foreach (DataRow row in persons.Rows)
            {
                NamaCache.Add(row["prs_nama"].ToString());
                AlamatCache.Add(row["prs_alamat"].ToString());
            }
            return persons;
        }

        public DataTable Get(int personId)
        {
            return ExecuteQuery("SELECT * FROM person WHERE prs_id = " + personId + ";");
        }

        public int GetId(string nama, string alamat)
        {
            if (!connection.Connect())
                return -1;
            using (SQLiteCommand cmd = connection.DbConnection.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "SELECT * FROM person WHERE prs_nama = @namaParam AND prs_alamat = @alamatParam;";
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
                        id = int.Parse(reader["prs_id"].ToString());
						break;
                    }
                    return id;
                }
            }
        }

        public DataTable Search(string nama)
        {
            return ExecuteQuery("SELECT * FROM person WHERE prs_nama LIKE '%" + nama + ";");
        }

        public int Update(int personId, string nama, string alamat)
        {
            return ExecuteNonQuery(
                "UPDATE person SET " +
                "prs_nama = @namaParam, prs_alamat = @alamatParam " +
                "WHERE prs_id = @idParam;",
                new SQLiteParameter[] {
                    new SQLiteParameter("@namaParam", DbType.String) { Value = nama },
                    new SQLiteParameter("@alamatParam", DbType.String) { Value = alamat},
                    new SQLiteParameter("@idParam", DbType.String) { Value = personId},
                }
            );
        }

        public int Delete(int personId)
        {
            return ExecuteNonQuery("DELETE FROM person WHERE prs_id = " + personId + ";");
        }
    }
}
