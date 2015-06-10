using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;


namespace MasjidRamadhan.Model
{
    public class Pengeluaran : BaseModel
    {
        public Pengeluaran(SqliteConnectionHelper connection) : base(connection)
        {
        }

        public int Insert(DateTime tanggal, bool hitungManual, string toko, string alamat)
        {
            Toko tokoModel = new Toko(connection);
            int tokoId = tokoModel.GetId(toko, alamat);
            if (tokoId == -1)
                tokoId = tokoModel.Insert(toko, alamat);
            return (int)connection.DbConnection.LastInsertRowId;
        }

        public int Insert(DateTime tanggal, bool hitungManual, int toko)
        {
            ExecuteNonQuery(
                "INSERT INTO pengeluaran (plr_tanggal, plr_hitung_manual, plr_toko) VALUES (@tanggalParam, @htgManualParam, @tokoParam)",
                new SQLiteParameter[] {
                    new SQLiteParameter("@tanggalParam", DbType.DateTime) { Value = tanggal },
                    new SQLiteParameter("@htgManualParam", DbType.Boolean) { Value = hitungManual },
                    new SQLiteParameter("@tokoParam", DbType.Int32) { Value = toko },
                }
            );
            return (int)connection.DbConnection.LastInsertRowId;
        }

        public int UpdateTotal(int pengeluaranId, float total)
        {
            return ExecuteNonQuery(
                "UPDATE PENGELUARAN SET plr_total = @totalParam WHERE plr_id = @idParam",
                new SQLiteParameter[] {
                    new SQLiteParameter("@totalParam", DbType.Decimal) { Value = total },
                    new SQLiteParameter("@idParam", DbType.Int32) { Value = pengeluaranId },
                }
            );
        }
    }
}
