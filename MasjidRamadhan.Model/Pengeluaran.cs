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

		public int Insert(DateTime tanggal, bool hitungManual, string toko, string alamat, float total = 0, string keterangan = "")
        {
            Toko tokoModel = new Toko(connection);
            int tokoId = tokoModel.GetId(toko, alamat);
            if (tokoId == -1)
                tokoId = tokoModel.Insert(toko, alamat);
            return Insert(tanggal, hitungManual, tokoId, total, keterangan);
        }

		public int Insert(DateTime tanggal, bool hitungManual, int toko, float total = 0, string keterangan = "")
        {
            ExecuteNonQuery(
				"INSERT INTO pengeluaran (plr_tanggal, plr_hitung_manual, plr_toko, plr_total, plr_keterangan) VALUES (@tanggalParam, @htgManualParam, @tokoParam, @totalParam, @ketParam)",
                new SQLiteParameter[] {
                    new SQLiteParameter("@tanggalParam", DbType.DateTime) { Value = tanggal },
					new SQLiteParameter("@htgManualParam", DbType.Boolean) { Value = hitungManual },
                    new SQLiteParameter("@tokoParam", DbType.Int32) { Value = toko },
					new SQLiteParameter("@totalParam", DbType.Decimal) { Value = total },
					new SQLiteParameter("@ketParam", DbType.String) { Value = keterangan },
                }
			);
            return (int)connection.DbConnection.LastInsertRowId;
        }

		public int InsertDetail(int pengeluaran, string namaBarang, string satuan, float jumlah, float hargaSatuan, float subTotal)
		{
			Barang barang = new Barang(connection);
			float prevHargaSatuan;
			int barangId = barang.GetId(namaBarang, satuan, out prevHargaSatuan);
			if (barangId == -1)
			{
				barang.Insert(namaBarang, satuan, hargaSatuan);
			}
			else if (prevHargaSatuan != hargaSatuan)
			{
				barang.UpdateHargaSatuan(barangId, hargaSatuan);
			}
			return InsertDetail(pengeluaran, barangId, jumlah, hargaSatuan, subTotal);
		}

		public int InsertDetail(int pengeluaran, int barang, float jumlah, float hargaSatuan, float subTotal)
		{
			return ExecuteNonQuery (
				"INSERT INTO detail_pengeluaran (dpl_pengeluaran, dpl_barang, dpl_jumlah, dpl_harga_satuan, dpl_subtotal)\n" +
				"VALUES (@plrParam, @brgParam, @jmlParam, @hargaParam, @subtotalParam)",
				new SQLiteParameter[] {
					new SQLiteParameter("@plrParam", DbType.Int32) { Value = pengeluaran },
					new SQLiteParameter("@brgParam", DbType.Int32) { Value = barang },
					new SQLiteParameter("@jmlParam", DbType.Decimal) { Value = jumlah },
					new SQLiteParameter("@hargaParam", DbType.Decimal) { Value = hargaSatuan },
					new SQLiteParameter("@subtotalParam", DbType.Decimal) { Value = subTotal },
				}
			);
		}

		public DataTable Get(DateTime start, DateTime end)
		{
			if (!connection.Connect())
				return null;
			using (SQLiteCommand cmd = connection.DbConnection.CreateCommand())
			{
				cmd.CommandType = CommandType.Text;
				cmd.CommandText =
					"SELECT p.plr_id, p.plr_tanggal, p.plr_total, p.plr_keterangan, t.tko_nama, dp.dpl_jumlah, b.brg_nama, b.brg_satuan FROM\n" +
					"(pengeluaran p INNER JOIN toko t ON p.plr_toko = t.tko_id) INNER JOIN (\n" +
					"detail_pengeluaran dp INNER JOIN barang b ON dp.dpl_barang = b.brg_id\n" +
					") ON p.plr_id = dp.dpl_pengeluaran\n" +
					"WHERE p.plr_tanggal >= @startParam AND p.plr_tanggal <= @endParam\n" +
					"ORDER BY p.plr_id";
				cmd.Parameters.AddRange(
					new SQLiteParameter[] {
						new SQLiteParameter("@namaParam", DbType.String) { Value = namaBarang },
						new SQLiteParameter("@alamatParam", DbType.String) { Value = satuan },
					}
				);

				using (SQLiteDataReader reader = cmd.ExecuteReader())
				{
					DataTable dt = new DataTable();
					dt.Columns.AddRange(
						new DataColumn[] {
							new DataColumn("ID"),
							new DataColumn("Tanggal"),
							new DataColumn("Toko"),
							new DataColumn("Uraian"),
							new DataColumn("Total")
						}
					);
					int currPlrId = -1;
					DataRow r = null;
					while (reader.Read())
					{
						int plrId = int.Parse(reader["plr_id"].ToString());
						if (plrId != currPlrId)
						{
							if (r != null)
								dt.Rows.Add(r);
							currPlrId = plrId;
							r = dt.NewRow();
							r["ID"] = plrId;
							r["Tanggal"] = reader["plr_tanggal"];
							r["Toko"] = reader["tko_nama"];
							r["Uraian"] = "";
							r["Total"] = reader["plr_total"];
						}
						else
						{
							r["Uraian"] += ", ";
						}
						reader["uraian"] += reader["brg_nama"].ToString() + " " + reader["dpl_jumlah"] + " " + reader["dpl_satuan"];
					}
					return dt;
				}
			}
		}

		public DataTable Get(int id)
		{
			return ExecuteQuery("");
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
