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
    public partial class Checker : Form
    {
        private string ftpId = "checker";
        private string ftpPwd = "dkfdptmdps404";
        private string ftpPath = "ftp://192.168.1.23";
        private DBConnector dbconn;
        private MySqlDataAdapter dbAdapter;
        private DataTable table;

        private string cellStr;

        public Checker(String[] args)
        {

            InitializeComponent();

            int argsCount = args.Length;

            if (argsCount >= 2)
            {
                String arg = args[1];

                updateBtn.Text = arg;

                if (arg == "update")
                {
                    Update updateApp = new Update();
                    updateApp.ShowDialog();
                    this.Close();
                }
            }



            clientIp_label.Text = "접속 IP : " + GetAccessIP();

            dbconn = new DBConnector();

            SetServerDataGridView();

            InitProgramDataGridView();

            InitLogDataGridView();

            serverDGV.CellClick += serverGridView_CellClick;
            programDGV.CellClick += programGridView_CellClick;

            string versionStr = ReadFileToString("readme.txt");

        }

        public void SetServerDataGridView()
        {
            string selectUpdateListSql = "SELECT S_HOST, S_NAME FROM SERVER GROUP BY S_HOST";

            dbAdapter = dbconn.excuteSql(selectUpdateListSql);

            table = new DataTable();

            serverDGV.Columns.Add("s_host", "호스트");

            serverDGV.Columns.Add("s_name", "서버명");

            dbAdapter.Fill(table);

            //dataGridView1.DataSource = table;

            int cnt = 0;
            foreach (DataRow row in table.Rows)
            {
                serverDGV.Rows.Add();
                serverDGV.Rows[cnt].Cells["s_host"].Value = row["s_host"].ToString();
                serverDGV.Rows[cnt].Cells["s_name"].Value = row["s_name"].ToString();

                cnt++;
            }
        }

        public string GetAccessIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            string ClientIP = string.Empty;
            for (int i = 0; i < host.AddressList.Length; i++)
            {
                if (host.AddressList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ClientIP = host.AddressList[i].ToString();
                }
            }
            return ClientIP;
        }
        public void InitProgramDataGridView()
        {
            programDGV.Columns.Clear();

            programDGV.Columns.Add("p_seq", "P_SEQ");
            programDGV.Columns.Add("p_name", "이름");
            programDGV.Columns.Add("p_version", "버전");
            programDGV.Columns.Add("p_path", "경로");
            programDGV.Columns.Add("s_status", "사용여부");
        }

        public void InitLogDataGridView()
        {
            logDGV.Columns.Clear();

            logDGV.Columns.Add("p_name", "이름");
            logDGV.Columns.Add("v_version", "버전");
            logDGV.Columns.Add("v_comment", "비고");
            logDGV.Columns.Add("v_ip", "IP");
            logDGV.Columns.Add("v_stamp", "일자");
        }

        public DateTime ConvertFromTimeStamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
        public long UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));

            return (long)timeSpan.TotalSeconds;
        }
        public void GetLogInfo(string pSeq)
        {
            string pNameSql = "SELECT p_name FROM PROGRAM WHERE p_seq = " + pSeq;
            dbAdapter = dbconn.excuteSql(pNameSql);
            table = new DataTable();
            dbAdapter.Fill(table);
            string pName = table.Rows[0]["p_name"].ToString();

            string sql = "SELECT * FROM VERSION WHERE p_seq = " + pSeq + " ORDER BY v_stamp DESC";

            dbAdapter = dbconn.excuteSql(sql);

            table = new DataTable();

            InitLogDataGridView();

            dbAdapter.Fill(table);

            int cnt = 0;

            foreach (DataRow row in table.Rows)
            {
                string v_version = row["v_version"].ToString();
                string v_comment = row["v_comment"].ToString();
                string v_ip = row["v_ip"].ToString();
                long v_stamp = Int64.Parse(row["v_stamp"].ToString());
                DateTime dateTime = ConvertFromTimeStamp(v_stamp);

                logDGV.Rows.Add();
                logDGV.Rows[cnt].Cells["v_version"].Value = v_version;
                logDGV.Rows[cnt].Cells["v_comment"].Value = v_comment;
                logDGV.Rows[cnt].Cells["v_ip"].Value = v_ip;
                logDGV.Rows[cnt].Cells["v_stamp"].Value = dateTime;
                logDGV.Rows[cnt].Cells["p_name"].Value = pName;

                cnt++;
            }
        }

        public void GetProgramInfo(string host)
        {

            string sql = "SELECT * FROM PROGRAM WHERE P_SEQ != 0";

            dbAdapter = dbconn.excuteSql(sql);

            table = new DataTable();

            InitProgramDataGridView();

            dbAdapter.Fill(table);

            int cnt = 0;

            sql = "SELECT * FROM SERVER WHERE s_host = '" + host + "'";

            dbAdapter = dbconn.excuteSql(sql);

            DataTable serverTable = new DataTable();

            dbAdapter.Fill(serverTable);

            foreach(DataRow row in table.Rows)
            {
                string p_seq = row["p_seq"].ToString();
                string p_path = row["p_path"].ToString();
                string p_name = row["p_name"].ToString();
                string p_version = row["p_version"].ToString();

                programDGV.Rows.Add();
                programDGV.Rows[cnt].Cells["p_seq"].Value = p_seq;
                programDGV.Rows[cnt].Cells["p_name"].Value = p_name;
                programDGV.Rows[cnt].Cells["p_path"].Value = p_path;
                programDGV.Rows[cnt].Cells["p_version"].Value = p_version;
                programDGV.Rows[cnt].Cells["s_status"].Value = 'N';

                foreach (DataRow sRow in serverTable.Rows)
                {
                    string serverPSeq = sRow["p_seq"].ToString();
                    if(serverPSeq == p_seq)
                    {
                        string status = sRow["s_status"].ToString();

                        programDGV.Rows[cnt].Cells["s_status"].Value = status;
                    }
                }

                cnt++;
            }

        }

        void programGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cellStr = programDGV.Rows[e.RowIndex].Cells["p_seq"].Value.ToString();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }

            button1.Text = cellStr;

            GetLogInfo(cellStr);
        }

        void serverGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cellStr = serverDGV.Rows[e.RowIndex].Cells["s_host"].Value.ToString();
            } catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }

            button1.Text = cellStr;

            GetProgramInfo(cellStr);
        }

        public string GetCellDataByClick (DataGridView dgv, string target, object sender, DataGridViewCellEventArgs e) {
            string result = dgv.Rows[e.RowIndex].Cells[target].Value.ToString();

            return result;
        }


        public void SetVersionDataGridView()
        {

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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update updateApp = new Update();
            updateApp.ShowDialog();
            this.Close();
        }
    }
}
