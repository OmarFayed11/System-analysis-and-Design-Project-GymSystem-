using Microsoft.Data.Sqlite;
using System.Data;

namespace GymSystem;

static class DB
{
    static readonly string Conn =
        $"Data Source={AppDomain.CurrentDomain.BaseDirectory}gym.db";

    // ── Create all tables ────────────────────────────────────────────
    public static void Init()
    {
        Exec(@"CREATE TABLE IF NOT EXISTS TRAINER (
                 Trainer_ID  INTEGER PRIMARY KEY AUTOINCREMENT,
                 Name        TEXT NOT NULL,
                 Phone       TEXT,
                 Specialty   TEXT)");

        Exec(@"CREATE TABLE IF NOT EXISTS MEMBER (
                 Member_ID   INTEGER PRIMARY KEY AUTOINCREMENT,
                 Name        TEXT NOT NULL,
                 Phone       TEXT,
                 Email       TEXT,
                 Join_Date   TEXT,
                 Trainer_ID  INTEGER REFERENCES TRAINER(Trainer_ID))");

        Exec(@"CREATE TABLE IF NOT EXISTS SUBSCRIPTION (
                 Sub_ID          INTEGER PRIMARY KEY AUTOINCREMENT,
                 Plan_Name       TEXT NOT NULL,
                 Duration_Months INTEGER,
                 Price           REAL)");

        Exec(@"CREATE TABLE IF NOT EXISTS MEMBER_SUBSCRIPTION (
                 MS_ID      INTEGER PRIMARY KEY AUTOINCREMENT,
                 Member_ID  INTEGER REFERENCES MEMBER(Member_ID),
                 Sub_ID     INTEGER REFERENCES SUBSCRIPTION(Sub_ID),
                 Start_Date TEXT,
                 End_Date   TEXT)");

        Exec(@"CREATE TABLE IF NOT EXISTS PAYMENT (
                 Receipt_No    INTEGER PRIMARY KEY AUTOINCREMENT,
                 MS_ID         INTEGER REFERENCES MEMBER_SUBSCRIPTION(MS_ID),
                 Amount        REAL,
                 Payment_Date  TEXT,
                 Method        TEXT)");

        Exec(@"CREATE TABLE IF NOT EXISTS REVIEW (
                 Review_ID  INTEGER PRIMARY KEY AUTOINCREMENT,
                 Member_ID  INTEGER REFERENCES MEMBER(Member_ID),
                 MS_ID      INTEGER REFERENCES MEMBER_SUBSCRIPTION(MS_ID),
                 Score      REAL,
                 Comment    TEXT)");
    }

    // ── Run INSERT / UPDATE / DELETE ─────────────────────────────────
    public static void Exec(string sql, params (string Key, object? Val)[] p)
    {
        using var con = Open();
        using var cmd = new SqliteCommand(sql, con);
        foreach (var (k, v) in p)
            cmd.Parameters.AddWithValue(k, v ?? DBNull.Value);
        cmd.ExecuteNonQuery();
    }

    // ── Run SELECT → DataTable ───────────────────────────────────────
    public static DataTable Query(string sql, params (string Key, object? Val)[] p)
    {
        using var con = Open();
        using var cmd = new SqliteCommand(sql, con);
        foreach (var (k, v) in p)
            cmd.Parameters.AddWithValue(k, v ?? DBNull.Value);
        var dt = new DataTable();
        dt.Load(cmd.ExecuteReader());
        return dt;
    }

    static SqliteConnection Open()
    {
        var c = new SqliteConnection(Conn);
        c.Open();
        return c;
    }
}
