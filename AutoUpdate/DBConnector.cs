using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AutoUpdate
{
    public class DBConnector
    {
        public MySqlConnection con;
        public MySqlDataAdapter adapter;
        public MySqlCommand cmd;
        public DBConnector()
        {
            string dbName = "checker";
            string host = "localhost";
            string id = "root";
            string pass = "engine!@#";

            string dbInfo = string.Format("server={0};uid={1};pwd={2};database={3};charset=utf8;Allow Zero Datetime = True;", 
                               host, id, pass, dbName);

            con = new MySqlConnection(dbInfo);
            //con = new MySqlConnection(@"Server=" + host + ";Database=" + dbName + ";Uid=" + id + ";Pwd=" + pass +";Allow Zero Datetime = True;");
        }

        public void OpenDB()
        {
            con.Open();
        }

        public void CloseDB()
        {
            con.Close();
        }

        public MySqlDataAdapter excuteSql(string sql)
        {
            cmd = new MySqlCommand(sql, con);
            adapter = new MySqlDataAdapter(cmd);
            
            return adapter;
        }

    }
}
