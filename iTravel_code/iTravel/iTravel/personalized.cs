using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

namespace iTravel
{
    public partial class personalized : Form
    {
        string name, engname, location, introduction;

        private string DBlocation;
        private OleDbConnection dbconn; //数据库连接
        private OleDbDataAdapter da;

        public personalized()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
           
            //建立与数据库的连接，这里采用了OLEDB方法
            dbconn = new OleDbConnection(@"provider=microsoft.jet.oledb.4.0; Data Source=C:\Users\Administrator\Desktop\per.mdb");
            dbconn.Open();
            //string strConnection = "Provider=Microsoft.Jet.OleDb.4.0;";
            //strConnection += @"Data Source=C:\Users\Administrator\Desktop\per.mdb";
            //OleDbConnection dbconn = new OleDbConnection(strConnection);
            //dbconn.Open();
            //创建DataSet对象
            da = new OleDbDataAdapter(@"select * from sheet1", dbconn); //引用数据库连接dbconn并依据SQL语句"select * from kaizhi"创建OleDbDataAdapter对象da
            DataSet ds = new DataSet(); //创建DataSet对象
            da.Fill(ds); //用OleDbDataAdapter对象da填充、更新刚创建的DataSet对象

            //添加记录并更新数据库
            OleDbCommandBuilder cb = new OleDbCommandBuilder(da); // 创建OleDbCommandBuilder对象cb用于更新OleDbDataAdapter对象da的Insert、Delete、Update指令
            da.UpdateCommand = cb.GetUpdateCommand(); //更新OleDbDataAdapter对象da的指令

            name = mingcheng.Text;
            engname = yingwenming.Text;
            location = dizhi.Text;
            introduction = jianjie.Text;


            DataRow drx = ds.Tables[0].NewRow(); //创建一条新记录行
            drx["景点名称"] = name;
            drx["英文名称"] = engname;
            drx["景点地址"] = location;
            drx["景点简介"] = introduction;
           
            ds.Tables[0].Rows.Add(drx); //在表中追加记录
            da.Update(ds); //更新数据库

            MessageBox.Show("提交成功！");
            this.Dispose();
        }
    }
}
