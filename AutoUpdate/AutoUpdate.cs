using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdate;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.IO;
using System.Net;

namespace AutoUpdate
{
    public partial class AutoUpdate : Form
    {
        private string ftpId = "checker";
        private string ftpPwd = "dkfdptmdps404";
        private string ftpPath = "ftp://192.168.1.23";

        public AutoUpdate()
        {
            InitializeComponent();

            DBConnector dbcon = new DBConnector();

            dbcon.OpenDB();

            string selectUpdateListSql = "SELECT * FROM CHECKER";

            MySqlDataAdapter dbAdapter = dbcon.excuteSql(selectUpdateListSql);

            dbcon.CloseDB();

            DataTable table = new DataTable();

            dataGridView1.Columns.Add("c_seq", "C_SEQ");

            dataGridView1.Columns.Add("name", "이름");

            dataGridView1.Columns.Add("version", "버전");

            dataGridView1.Columns.Add("comment", "커멘트");

            dataGridView1.Columns.Add("ip", "작업IP");

            dataGridView1.Columns.Add("path", "경로");

            dataGridView1.Columns.Add("filesize", "크기");


            dbAdapter.Fill(table);

            //dataGridView1.DataSource = table;

            int cnt = 0;
            foreach (DataRow row in table.Rows)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[cnt].Cells["c_seq"].Value = row["c_seq"].ToString();
                dataGridView1.Rows[cnt].Cells["name"].Value = row["name"].ToString();
                dataGridView1.Rows[cnt].Cells["version"].Value = row["version"].ToString();
                dataGridView1.Rows[cnt].Cells["comment"].Value = row["comment"].ToString();
                dataGridView1.Rows[cnt].Cells["ip"].Value = row["ip"].ToString();
                dataGridView1.Rows[cnt].Cells["path"].Value = row["path"].ToString();
                dataGridView1.Rows[cnt].Cells["filesize"].Value = row["filesize"].ToString();

                cnt++;
            }


            string versionStr = ReadFileToString("test.txt");

            version_label.Text = versionStr;
        }

        public string ReadFileToString (string fileName)
        {
            fileName = ftpPath + "/" + fileName;

            FtpWebRequest ReqFile = WebRequest.Create(fileName) as FtpWebRequest;
            ReqFile.Method = WebRequestMethods.Ftp.DownloadFile;
            ReqFile.Credentials = new NetworkCredential(ftpId, ftpPwd);

            string resDataString = String.Empty;

            using (FtpWebResponse ResponseFile = ReqFile.GetResponse() as FtpWebResponse)
            {
                Stream responseStream = ResponseFile.GetResponseStream();

                using (StreamReader reader = new StreamReader(responseStream))
                {
                    resDataString = reader.ReadToEnd();
                }
            }

            return resDataString;
        }



        public IniFile LoadIni()
        {
            IniFile ini = new IniFile();

            ini.Load("");

            return ini;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
