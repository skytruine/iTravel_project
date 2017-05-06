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
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace iTravel
{
    public partial class searchbyname : Form
    {
        List<string> listOnit = new List<string>();

            //输入key之后，返回的关键词
        List<IFeature> featurelist = new List<IFeature>();
           List<string> listNew = new List<string>();
           AxMapControl mapcon = null;
           int index = -1;
           DataTable dt = new DataTable();
          
           //获取图层中的所有地物
         public static List<IFeature> GetLayerFeatures(IFeatureClass featureClass)
        {
            List<IFeature> result = new List<IFeature>();
            if (featureClass == null)
                return result;
            IFeatureCursor featureCursor = featureClass.Search(null, false);
            IFeature feature = featureCursor.NextFeature();
            while (feature != null)
            {
                result.Add(feature);
                feature = featureCursor.NextFeature();
            }
            //ESRI.ArcGIS.ADF.ComReleaser.ReleaseCOMObject(featureCursor);
            return result;
        }
           public searchbyname(AxMapControl mapcontrol)
        {
            InitializeComponent();
            mapcon = mapcontrol;
            //ILayer layer1=null;
            IFeatureLayer layer2 = null;
      
            for (int i = 0; i < mapcon.LayerCount; i++)
            {
                if (mapcon.get_Layer(i).Name == "tourist_attraction")
                {
                    //引用deletelayer方法删除该图层
                    //axMapControl1.DeleteLayer(i);
                    //layer1 = axMapControl1.get_Layer(i);
                    layer2 = (IFeatureLayer)mapcon.get_Layer(i);
                    IFeatureClass pFeatureClass = layer2.FeatureClass;
                    index=pFeatureClass.Fields.FindField("景点名称"); 
                    featurelist = GetLayerFeatures(pFeatureClass);//获得所有地物
                    


                }
                }
        }

        private void searchbyname_Load(object sender, EventArgs e)
        {
            BindComboBox();

 
        }
        //private DataTable guanlian()
        private void guanlian()
        {
            string strConnection = "Provider=Microsoft.Jet.OleDb.4.0;";
            strConnection += @"Data Source=C:\Users\Administrator\Desktop\first\Database1.mdb";
            OleDbConnection objConnection = new OleDbConnection(strConnection);
            objConnection.Open();
            string sql = "select * from sights";
            OleDbCommand cmd = new OleDbCommand(sql, objConnection);
            OleDbDataAdapter ad = new OleDbDataAdapter();
            ad.SelectCommand = cmd;
            //DataTable dt = new DataTable();
            ad.Fill(dt);
            //return dt;
        }
        private void BindComboBox()
        {
           // DataTable dt = new DataTable();
            //dt = guanlian();
            guanlian();
            

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

       

            /*

             * 1.注意用Item.Add(obj)或者Item.AddRange(obj)方式添加

             * 2.如果用DataSource绑定，后面再进行绑定是不行的，即便是Add或者Clear也不行

             */

        
            this.comboBox1.Items.AddRange(listOnit.ToArray());

        }
       
        
        public static void FlashFeature(AxMapControl mapControl, IFeature iFeature)
        {


            IActiveView iActiveView = mapControl.ActiveView;
            if (iActiveView != null)
            {
                iActiveView.ScreenDisplay.StartDrawing(0, (short)esriScreenCache.esriNoScreenCache);
                FlashPoint(mapControl, iActiveView.ScreenDisplay, iFeature.Shape);
                iActiveView.ScreenDisplay.FinishDrawing();
            }
        }
        
        //闪烁点
        public static void FlashPoint(AxMapControl mapControl, IScreenDisplay iScreenDisplay, IGeometry iGeometry)
        {
            ISimpleMarkerSymbol iMarkerSymbol;
            ISymbol iSymbol;
            IRgbColor iRgbColor;



            iMarkerSymbol = new SimpleMarkerSymbol();
            iMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
            iRgbColor = new RgbColor();
            //iRgbColor.RGB = System.Drawing.Color.FromArgb(0, 0, 0).ToArgb();
            iRgbColor.RGB = 255;
            iMarkerSymbol.Color = iRgbColor;
            iSymbol = (ISymbol)iMarkerSymbol;
            iSymbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;
            mapControl.FlashShape(iGeometry, 10, 200, iSymbol);
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
            
            //DataTable dt = new DataTable();
           // dt = guanlian();
             IPoint pt=new PointClass();
       

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
           shanshan();

          
        }

        private void  shanshan()
        {
            IPoint pt = new PointClass();
            for (int i = 0; i < featurelist.Count; i++)
            {
                if (featurelist.ElementAt(i).get_Value(index) == comboBox1.Text)
                {
                    FlashFeature(mapcon, featurelist.ElementAt(i));//为什么先闪后出现图片

                    pt.X = featurelist.ElementAt(i).get_Value(index + 1);
                    pt.Y = featurelist.ElementAt(i).get_Value(index + 2);
                    drowLocationByPoint(pt);
                }
            }
        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }
        public void drowLocationByPoint(IPoint pt)
        {
            //将图形元素显示在视图上的一般步骤为
            //①确定元素显示时用的符号(symbol)和几何形体对象(geometry)
            //②使用IGraphicsContainer::AddElement把元素添加到视图中
            //③刷新视图，显示添加的元素

            //创建一个新的元素（底板）
            IMarkerElement pMarkerElement = new MarkerElementClass();
            //创建一个新的符号（胶片）
            ISimpleMarkerSymbol pMarkerSym = new SimpleMarkerSymbolClass();
            //指定符号的样式（曝光）
            //pMarkerSym.Style = esriSimpleMarkerStyle.esriSMSCircle;  //形状
            pMarkerSym.Style = esriSimpleMarkerStyle.esriSMSDiamond;
            IRgbColor tColor = new RgbColorClass();  //颜色
          
           tColor.Red = 0; tColor.Green =125; tColor.Blue = 125; tColor.Transparency = 100;
            
            
            pMarkerSym.Color = tColor;
            pMarkerSym.Size = 12; //大小
            pMarkerSym.Outline = true;

            //把符号赋值给元素（冲印）
            pMarkerElement.Symbol = pMarkerSym;

            //确定元素显示时所用的几何形状
            IElement pElement;
            pElement = pMarkerElement as IElement;
            pElement.Geometry = pt;
            //将元素添加到视图中去
            IMap pMap = mapcon.Map;
            IActiveView pActiveView = pMap as IActiveView;  //as是一种不抛出异常的强制类型转换，创建地图视图
            IGraphicsContainer pGraphicsContainer = pMap as IGraphicsContainer;//创建地图容器
            pGraphicsContainer.DeleteAllElements();  //添加前先清除原有的元素
            pGraphicsContainer.AddElement(pElement, 0); //把元素添加到地图容器中去；
            pActiveView.Refresh();

        }
    
        
    }
}
