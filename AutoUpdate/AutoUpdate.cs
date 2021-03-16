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

namespace AutoUpdate
{
    public partial class AutoUpdate : Form
    {
        public AutoUpdate()
        {
            InitializeComponent();

            DBConnector dbcon = new DBConnector();

            dbcon.OpenDB();

            string selectUpdateListSql = "SELECT * FROM CHECKER";

            MySqlDataAdapter dbAdapter = dbcon.excuteSql(selectUpdateListSql);

            dbcon.CloseDB();

            DataTable table = new DataTable();

            dbAdapter.Fill(table);

            dataGridView1.DataSource = table;

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
    }
}
