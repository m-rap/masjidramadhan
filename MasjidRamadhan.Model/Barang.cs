using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace MasjidRamadhan.Model
{
	public class Barang : BaseModel
	{
		public Barang (SqliteConnectionHelper connection) : base(connection)
		{
		}

		public int Insert(string namaBarang, string satuan, float hargaSatuan)
		{
			ExecuteNonQuery(
				"INSERT INTO barang (brg_nama, brg_satuan, brg_harga_satuan) VALUES (@namaParam, @satuanParam, @hrgParam)",
				new SQLiteParameter[] {
					new SQLiteParameter("@namaParam", DbType.String) { Value = namaBarang },
					new SQLiteParameter("@satuanParam", DbType.String) { Value = satuan },
					new SQLiteParameter("@hrgParam", DbType.String) { Value = hargaSatuan },
				}
			);
			return (int)connection.DbConnection.LastInsertRowId;
		}

		public int GetId(string namaBarang, string satuan, out float hargaSatuan)
		{
			hargaSatuan = 0.0f;
			if (!connection.Connect())
				return -1;
			using (SQLiteCommand cmd = connection.DbConnection.CreateCommand())
			{
				cmd.CommandType = CommandType.Text;
				cmd.CommandText =
					"SELECT * FROM barang WHERE brg_nama = @namaParam AND brg_satuan = @satuanParam;";
				cmd.Parameters.AddRange(
					new SQLiteParameter[] {
						new SQLiteParameter("@namaParam", DbType.String) { Value = namaBarang },
						new SQLiteParameter("@alamatParam", DbType.String) { Value = satuan },
					}
				);
				using (SQLiteDataReader reader = cmd.ExecuteReader())
				{
					int id = -1;
					while (reader.Read())
					{
						id = int.Parse(reader["brg_id"].ToString());
						hargaSatuan = float.Parse(reader["brg_harga_satuan"].ToString());
						break;
					}
					return id;
				}
			}
		}

		public int UpdateHargaSatuan(int barangId, float hargaSatuan)
		{
			return ExecuteNonQuery(
				"UPDATE barang SET brg_harga_satuan = @hargaParam WHERE brg_id = @idParam",
				new SQLiteParameter[] {
					new SQLiteParameter("@idParam", DbType.Int32) { Value = barangId },
					new SQLiteParameter("@hargaParam", DbType.Decimal) { Value = hargaSatuan }
				}
			);
		}
	}
}

