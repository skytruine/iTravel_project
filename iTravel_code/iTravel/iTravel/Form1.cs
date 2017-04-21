using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using System.Web;

namespace iTravel
{
    public partial class Form1 :  Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {

        }

        private void ribbonPanel1_Click(object sender, EventArgs e)
        {

        }
       /* public class MyPic : PictureBox
        {
            protected override void OnCreateControl()
            {
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(this.ClientRectangle);
                Region region = new Region(gp);
                this.Region = region;
                gp.Dispose();
                region.Dispose();
                base.OnCreateControl();
            }

        }*/

        private void Form1_Load(object sender, EventArgs e)
        {
            /*MyPic pic = new MyPic();
            pic.Name = "p1";
            //pic.Image = WindowsFormsApplication1.Properties.Resources.cnt_bg_01;
            pic.Width = 500;
            pic.Height = 300;
            this.Controls.Add(pic);
            
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(pictureBox2.ClientRectangle);
            Region region = new Region(gp);
            pictureBox2.Region = region;
            gp.Dispose();
            region.Dispose();*/

        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            ESRI.ArcGIS.SystemUI.ITool tool = new ESRI.ArcGIS.Controls.ControlsMapZoomInToolClass();
            ESRI.ArcGIS.SystemUI.ICommand command = tool as ESRI.ArcGIS.SystemUI.ICommand;
            command.OnCreate(this.axMapControl2.Object);
            this.axMapControl2.CurrentTool = tool;
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
            ESRI.ArcGIS.SystemUI.ITool tool = new ESRI.ArcGIS.Controls.ControlsMapZoomOutToolClass();
            //查询接口获取ICommand 
            ESRI.ArcGIS.SystemUI.ICommand cmd = tool as ESRI.ArcGIS.SystemUI.ICommand;
            //Tool通过ICommand与MapControl的关联 
            cmd.OnCreate(this.axMapControl2.Object);
            cmd.OnClick();
            //MapControl的当前工具设定为tool 
            this.axMapControl2.CurrentTool = tool;
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            ICommand Pan = new ControlsMapPanToolClass();
            Pan.OnCreate(axMapControl2.Object);
            Pan.OnClick();
            axMapControl2.CurrentTool = (ITool)Pan;
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            axMapControl2.Extent = axMapControl2.FullExtent;
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void ribbonPanel3_Click(object sender, EventArgs e)
        {

        }
    }
}
