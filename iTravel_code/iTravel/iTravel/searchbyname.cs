using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTravel
{
    public partial class searchbyname : Form
    {
        List<string> listOnit = new List<string>();

            //输入key之后，返回的关键词

           List<string> listNew = new List<string>();
            
        public searchbyname()
        {
            InitializeComponent();
        }

        private void searchbyname_Load(object sender, EventArgs e)
        {
            BindComboBox();

 
        }
        private DataTable guanlian()
        {
            string strConnection = "Provider=Microsoft.Jet.OleDb.4.0;";
            strConnection += @"Data Source=C:\Users\Administrator\Desktop\Database1.mdb";
            OleDbConnection objConnection = new OleDbConnection(strConnection);
            objConnection.Open();
            string sql = "select * from sights";
            OleDbCommand cmd = new OleDbCommand(sql, objConnection);
            OleDbDataAdapter ad = new OleDbDataAdapter();
            ad.SelectCommand = cmd;
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
        private void BindComboBox()
        {
            DataTable dt = new DataTable();
            dt = guanlian();
            

        /*string strConnection = "Provider=Microsoft.Jet.OleDb.4.0;";
        strConnection += @"Data Source=C:\Users\Administrator\Desktop\Database1.mdb";
        OleDbConnection objConnection = new OleDbConnection(strConnection);
        objConnection.Open();
        string sql = "select * from sights";
        OleDbCommand cmd = new OleDbCommand(sql,objConnection);
            OleDbDataAdapter ad = new OleDbDataAdapter();
            ad.SelectCommand = cmd;
            DataTable dt = new DataTable();
            ad.Fill(dt);*/
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listOnit.Add(dt.Rows[i][1].ToString());
            }

        //OleDbDataReader reader = cmd.ExecuteReader();
        //comboBox1.Items.Clear();
        //while(reader.Read()){
            //listOnit.Add((string)reader["景点名称"]);
        //comboBox1.Items.Add((string)reader["景点名称"]); //添加物品名到combobox
        //richTextBox1.Text + = (string)reader["物品属性"]); //添加物品属性刀richTextBox
        //}
        //cmd.Dispose();
        //reader.Close();
        //objConnection.Close();

            /*

             * 1.注意用Item.Add(obj)或者Item.AddRange(obj)方式添加

             * 2.如果用DataSource绑定，后面再进行绑定是不行的，即便是Add或者Clear也不行

             */

        
            this.comboBox1.Items.AddRange(listOnit.ToArray());

        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            //清空combobox

            this.comboBox1.Items.Clear();

            //清空listNew

            listNew.Clear();

            //遍历全部备查数据

            foreach (var item in listOnit)

            {
                       if (item.Contains(this.comboBox1.Text))

                        {

                            //符合，插入ListNew

                            listNew.Add(item);

                        }

            }

            //combobox添加已经查到的关键词

            this.comboBox1.Items.AddRange(listNew.ToArray());

            //设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列

            this.comboBox1.SelectionStart = this.comboBox1.Text.Length;

            //保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。

            Cursor = Cursors.Default;

            //自动弹出下拉框

            this.comboBox1.DroppedDown = true;
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = guanlian();
       

           for (int i = 0; i < dt.Rows.Count; i++)
            {
                //listOnit.Add(dt.Rows[i][1].ToString());
                if (comboBox1.Text == dt.Rows[i][1].ToString())
                {
                    //String s = dt.Rows[i][3].ToString();
                    //s=
                   // pictureBox1.Image = dt.Rows[i][3].ToString();
                   // pictureBox1.ImageLocation = @"C:\Users\Administrator\Desktop\tourpics\hhl.jpg";
                    pictureBox1.ImageLocation = dt.Rows[i][3].ToString();//@用于表示地址
                    //labelX2.Text = dt.Rows[i][2].ToString();
                    textBox1.Text = dt.Rows[i][2].ToString();
                }
            }

           /* if (comboBox1.Text=="张三")
            {
                pictureBox1.Image = global ::iTravel.Properties.Resources._1859_110G9193G763;
                labelX2.Text = "zhangsan de xinxi ";
            }
            if (comboBox1.Text == "张思")
            {
                pictureBox1.Image = global ::iTravel.Properties.Resources._1;
                labelX2.Text = "zhangsi de xinxi ";
            }*/
        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }
    
        
    }
}
