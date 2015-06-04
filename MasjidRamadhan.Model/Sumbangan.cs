using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace MasjidRamadhan.Model
{
    public class Sumbangan : BaseModel
    {
        public Sumbangan(SqliteConnectionHelper connection) : base(connection)
        {
        }

        public int Insert(DateTime tanggal, int person, double jumlah, string keterangan = "")
        {
            int res = ExecuteNonQuery(
                "INSERT INTO sumbangan " +
                "(sbg_tanggal, sbg_jumlah, sbg_penyumbang, sbg_keterangan) VALUES " +
                "(@tanggalParam, @jumlahParam, @personParam, @ketParam);",
                new SQLiteParameter[] {
                    new SQLiteParameter("@tanggalParam", DbType.DateTime) { Value = tanggal },
                    new SQLiteParameter("@jumlahParam", DbType.Decimal) { Value = jumlah},
                    new SQLiteParameter("@personParam", DbType.Int32) { Value = person },
                    new SQLiteParameter("@ketParam", DbType.String) { Value = keterangan},
                }
            );
            if (res > 0)
                return (int)connection.DbConnection.LastInsertRowId;
            return -1;
        }

        public int Insert(DateTime tanggal, string nama, string alamat, double jumlah, string keterangan = "")
        {
            Person person = new Person(connection);
            int personId = person.GetId(nama, alamat);
            if (personId == -1)
                personId = person.Insert(nama, alamat);
            return Insert(tanggal, personId, jumlah, keterangan);
        }

        public DataTable Get(DateTime start, DateTime end, int offset, int limit = 0)
        {
            string sql =
                "SELECT sbg_id as ID, sbg_tanggal as Tanggal, sbg_jumlah as Jumlah, prs_nama as Nama, prs_alamat as Alamat, sbg_keterangan as Keterangan " +
                "FROM sumbangan JOIN person ON sbg_penyumbang = prs_id " +
                "WHERE sbg_tanggal >= @startParam AND sbg_tanggal <= @endParam ORDER BY sbg_tanggal";
            if (limit == 0)
                sql += ";";
            else
                sql += " LIMIT " + offset + "," + limit + ");";
            return ExecuteQuery(
                sql,
                new SQLiteParameter[] {
                    new SQLiteParameter("@startParam", DbType.DateTime) { Value = start },
                    new SQLiteParameter("@endParam", DbType.DateTime) { Value = end },
                }
            );
        }

        public DataTable Get(int sumbanganId)
        {
            string sql = "SELECT * FROM sumbangan s JOIN person p ON s.sbg_penyumbang = p.prs_id WHERE s.sbg_id = " + sumbanganId + ";";
            return ExecuteQuery(sql);
        }

        public int Update(int sumbanganId, DateTime tanggal, int person, double jumlah, string keterangan = "")
        {
            return ExecuteNonQuery(
                "UPDATE sumbangan SET " +
                "sbg_tanggal = @tanggalParam, sbg_jumlah = @jumlahParam, sbg_penyumbang = @personParam, sbg_keterangan = @ketParam " +
                "WHERE sbg_id = @idParam;",
                new SQLiteParameter[] {
                    new SQLiteParameter("@tanggalParam", DbType.DateTime) { Value = tanggal },
                    new SQLiteParameter("@jumlahParam", DbType.Decimal) { Value = jumlah},
                    new SQLiteParameter("@personParam", DbType.Int32) { Value = person },
                    new SQLiteParameter("@ketParam", DbType.String) { Value = keterangan},
                    new SQLiteParameter("@idParam", DbType.Int32) { Value = sumbanganId},
                }
            );
        }

        public int Update(int sumbanganId, DateTime tanggal, string nama, string alamat, double jumlah, string keterangan = "")
        {
            Person person = new Person(connection);
            int personId = person.GetId(nama, alamat);
            if (personId == -1)
            {
                person.Insert(nama, alamat);
                personId = (int)connection.DbConnection.LastInsertRowId;
            }
            return Update(sumbanganId, tanggal, personId, jumlah, keterangan);
        }

        public int Delete(int sumbanganId)
        {
            return ExecuteNonQuery("DELETE FROM sumbangan WHERE sbg_id = " + sumbanganId + ";");
        }
    }
}
