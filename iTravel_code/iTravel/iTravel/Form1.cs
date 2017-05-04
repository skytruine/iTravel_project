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
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

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

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            searchbyname search = new searchbyname();
            search.Show();
            //search.MdiParent = this;

            search.Location = (Point)new Size(axMapControl2.Location.X, axMapControl2.Location.Y);
            search.Height = axMapControl2.Height;
            search.TopMost = true;
        }

        private void buttonItem23_Click(object sender, EventArgs e)
        {
            ICommand pCommand = null;
            pCommand = new ControlsSelectToolClass(); //选择要素
            pCommand.OnCreate(axMapControl2.Object);     //使得PageLayoutContro中对象可以编辑
            axMapControl2.CurrentTool = (ITool)pCommand;
            MapSelectFeature();
           
        }
        private void MapSelectFeature()
        {
            ICommand pCommand = new ControlsSelectFeaturesToolClass();
            ITool pTool = pCommand as ITool;
            pCommand.OnCreate(axMapControl2.Object);
            axMapControl2.CurrentTool = pTool;
            //getSelectedFeature();
        }//选择地图要素
        public void getSelectedFeature()  
    {  
            try  
            {
                IMap map = axMapControl2.Map;
                ISelection selection = map.FeatureSelection;
                IEnumFeatureSetup iEnumFeatureSetup = (IEnumFeatureSetup)selection;
                iEnumFeatureSetup.AllFields = true;
                IEnumFeature enumFeature = (IEnumFeature)iEnumFeatureSetup;
                enumFeature.Reset();
                IFeature feature = enumFeature.Next();
                while (feature != null)
                {
                    string hehe = feature.get_Value(5).ToString();
                    MessageBox.Show(hehe);
                    feature = enumFeature.Next();
                }
            }
            catch (Exception e)
            {
            }  
}

        private void axMapControl2_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            getSelectedFeature();
        }  
    }
}
