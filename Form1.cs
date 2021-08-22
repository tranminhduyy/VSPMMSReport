using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace VSPMMS_Chart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.Fill.Color = Color.Red;
            zedGraphControl1.GraphPane.Chart.Fill.Brush = new System.Drawing.SolidBrush(Color.Black);

            //TextObj text = new TextObj();
            //text.FontSpec.FontColor = Color.White;
            //zedGraphControl1.GraphPane.GraphObjList.Add(text);

            zedGraphControl1.GraphPane.YAxis.Title.FontSpec.FontColor = Color.White;
            zedGraphControl1.GraphPane.Chart.Border.Color = Color.White;
            zedGraphControl1.GraphPane.YAxis.IsAxisSegmentVisible = false;
            zedGraphControl1.GraphPane.YAxis.MajorGrid.Color = Color.White;
            zedGraphControl1.GraphPane.YAxis.MajorTic.Color = Color.White;
            zedGraphControl1.GraphPane.YAxis.MinorGrid.Color = Color.White;
            zedGraphControl1.GraphPane.YAxis.MinorTic.Color = Color.White;
            zedGraphControl1.GraphPane.YAxis.Scale.FontSpec.FontColor = Color.White;
        }
    }
}
