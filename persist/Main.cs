using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using Microsoft.Data.Sqlite;
using System.Diagnostics;
using hlogger;

namespace persist
{
    public class DB
    {
        
        public static SqliteConnection CreateConnection()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Hale Terminal");
            bool exists = Directory.Exists(path);
            if(!exists)
                Directory.CreateDirectory(path);

            path = Path.Combine(path, "persist.db");
            SqliteConnection sqlite_conn = new SqliteConnection("Data Source=" + path);
            sqlite_conn.Open();
            return sqlite_conn;
        }

        public static void CreateTable()
        {
            SqliteConnection conn = CreateConnection();
            SqliteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE commands (name VARCHAR(150), category VARCHAR(150), description VARCHAR(150))";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void InsertData()
        {
            SqliteConnection conn = CreateConnection();
            SqliteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO commands (name, category, description) VALUES ('boop', 'beep', 'rawr');";
            sqlite_cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
