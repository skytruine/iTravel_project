using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using syf_oracle_test;

namespace syf_oracle_test
{
    
    public partial class Form1 : Form
    {
        string connString;
        OracleConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connString = "data source=120.24.97.173/orcl;User Id=system;Password=517012;";
            conn = new OracleConnection(connString);
            try
            {
                conn.Open();
                MessageBox.Show("成功连接数据库");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("数据库连接异常");

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string connString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=120.24.97.173)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));Persist Security Info=True;User ID=system;Password=517012;";
            //string connString = "data source=120.24.97.173/orcl;User Id=system;Password=517012;";
           //------------------------------------------数据库连接-------------------------------------------------------------
      
            //string tempString;
            //string sqlString;
           

            //OracleCommand cmd = conn.CreateCommand();
            //sqlString = "insert into test_login values('admin113','admin111')";
            //cmd.CommandText = "insert into test_login values('admin113','admin111')";
            
            //try
            //{
            //    cmd.ExecuteReader();
            //    MessageBox.Show("成功插入一行");
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show("未能成功插入行");
            //}

            ////建立Dataset
            //DataSet ds = new DataSet();
            
            ////建立表,添加到数据集中
            //DataTable dt = new DataTable();
            //ds.Tables.Add(dt);

            ////建立列
            //DataColumn dc = new DataColumn();
            //dc.

            ////建立行
           
            
            




            //conn.Close();
            //tempString = conn.State.ToString();
            //MessageBox.Show(tempString);
            
            //------------------------------------------数据库连接-------------------------------------------------------------


            /*
            MessageBox.Show(groupBox1, "添加成功!");
            int count = 0;
            try
            {
                string ConnectionString = "Data Source=dzjc_2005;user=kk;password=kk;";//写连接串   
                OracleConnection conn = new OracleConnection(ConnectionString);//创建一个新连接  

                conn.Open();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from kk.kkyh";//在这儿写sql语句   
                OracleDataReader odr = cmd.ExecuteReader();//创建一个OracleDateReader对象   
                while (odr.Read())//读取数据，如果odr.Read()返回为false的话，就说明到记录集的尾部了   
                {
                    count++;
                    MessageBox.Show(odr.GetOracleString(1).ToString());//输出字段1，这个数是字段索引，具体怎么使用字段名还有待研究   
                }
                odr.Close();


                if (count > 0)
                {
                    MessageBox.Show(groupBox1, "添加成功!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(groupBox1, "添加失败!");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }  
             */
        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fm = new Form2();
            fm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
