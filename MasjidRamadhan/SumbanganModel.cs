using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace MasjidRamadhan
{
    public class SumbanganModel
    {
        public static int Insert(ref MasjidRamadhanConnection connection, string nama, string alamat, double jumlah, string keterangan = "")
        {
            if (!MasjidRamadhanConnection.Connect(ref connection))
                return 0;
            try
            {
                SQLiteCommand cmd = connection.Connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "INSERT INTO sumbangan " +
                    "(sbg_tanggal, sbg_nama, sbg_alamat, sbg_jumlah, sbg_keterangan) VALUES " +
                    "(DATETIME('now', 'localtime'), @namaParam, @alamatParam, @jumlahParam, @ketParam);";
                cmd.Parameters.AddRange(
                    new SQLiteParameter[] {
                        new SQLiteParameter("@namaParam", SqlDbType.Text) { Value = nama },
                        new SQLiteParameter("@alamatParam", SqlDbType.Text) { Value = alamat},
                        new SQLiteParameter("@jumlahParam", SqlDbType.Real) { Value = jumlah},
                        new SQLiteParameter("@ketParam", SqlDbType.Text) { Value = keterangan},
                    }
                );
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ". " + ex.StackTrace);
                return 0;
            }
        }

        public static DataTable Get(ref MasjidRamadhanConnection connection, DateTime start, DateTime end, int offset, int limit)
        {
            if (!MasjidRamadhanConnection.Connect(ref connection))
                return null;
            try
            {
                SQLiteCommand cmd = connection.Connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "SELECT * FROM sumbangan " +
                    "WHERE sbg_tanggal >= @startParam AND sbg_tanggal <= @endParam " +
                    "LIMIT " + offset + "," + limit + ");";

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ". " + ex.StackTrace);
                return null;
            }
        }
    }
}
