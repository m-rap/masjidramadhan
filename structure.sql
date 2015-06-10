CREATE TABLE IF NOT EXISTS `person` (
    `prs_id`          INTEGER PRIMARY KEY AUTOINCREMENT,
    `prs_nama`        TEXT,
    `prs_alamat`      TEXT
);

CREATE INDEX IF NOT EXISTS `idx_prs_nama` ON `person` (`prs_nama`, `prs_alamat`);

CREATE TABLE IF NOT EXISTS sumbangan (
    `sbg_id`          INTEGER PRIMARY KEY AUTOINCREMENT,
    `sbg_tanggal`     DATETIME,
    `sbg_jumlah`      REAL,
    `sbg_keterangan`  TEXT,
    `sbg_penyumbang`  INTEGER
);

CREATE INDEX IF NOT EXISTS `idx_sbg_tanggal` ON `sumbangan` (`sbg_tanggal` ASC);

CREATE TABLE IF NOT EXISTS `toko` (
    `tko_id`     INTEGER PRIMARY KEY AUTOINCREMENT,
    `tko_nama`   TEXT,
    `tko_alamat` TEXT
);

CREATE TABLE IF NOT EXISTS `barang` (
    `brg_id`           INTEGER PRIMARY KEY AUTOINCREMENT,
    `brg_nama`         TEXT,
    `brg_satuan`       TEXT,
    `brg_harga_satuan` REAL
);

CREATE TABLE IF NOT EXISTS `pengeluaran` (
    `plr_id`            INTEGER PRIMARY KEY AUTOINCREMENT,
    `plr_tanggal`       DATETIME,
    `plr_total`	        REAL DEFAULT 0,
    `plr_hitung_manual` BOOLEAN,
    `plr_toko`          INTEGER,
    `plr_keterangan`    TEXT
);

CREATE INDEX IF NOT EXISTS `idx_plr_tanggal` ON `pengeluaran` (`plr_tanggal` ASC);

CREATE TABLE IF NOT EXISTS `detail_pengeluaran` (
    `dpl_pengeluaran`   INTEGER,
    `dpl_barang`        INTEGER,
    `dpl_jumlah`        REAL,
    `dpl_harga_satuan`  REAL,
    `dpl_subtotal`      REAL
);

CREATE INDEX IF NOT EXISTS `idx_dpl_pengeluaran` ON `detail_pengeluaran` (`dpl_pengeluaran` ASC);