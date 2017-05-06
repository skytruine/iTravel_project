using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace syf_oracle_test
{
    public partial class Form2 : Form
    {
        string connString;
        OracleConnection conn;
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlString;
            string accountString;
            string passwordConfirmString;
            string passwordString;
            int signFlag;

            connString = "data source=120.24.97.173/orcl;User Id=system;Password=517012;";
            conn = new OracleConnection(connString);
            try
            {
                conn.Open();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("数据库连接异常");

            }
            OracleCommand cmd;
            cmd = conn.CreateCommand();

            this.Close();
        }
    }
}
