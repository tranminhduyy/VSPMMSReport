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
    public partial class ucPrinting : UserControl
    {
        public ucPrinting()
        {
            InitializeComponent();
        }

        private void ucPrinting_Load(object sender, EventArgs e)
        {
            //SQL.Instance().TestConnection();
            SetZedGraphProperty(myZedGraph);          
            dtpStarttime.Visible = false;
            dtpEndtime.Visible = false;
            btSearch.Visible = false;
            Speed(myZedGraph);
            P601_Event(dgvP601);
            P604_Event(dgvP604);
            P605_Event(dgvP605);
            P5M_Event(dgvP5M);
            
            timer1.Enabled = true;
            timer1.Start();
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            Speed(myZedGraph);
            P601_Event(dgvP601);
            P604_Event(dgvP604);
            P605_Event(dgvP605);
            P5M_Event(dgvP5M);
        }

        DataSourcePointList dspP601;
        DataSourcePointList dspP604;
        DataSourcePointList dspP605;
        DataSourcePointList dspP5M;

        private void SetZedGraphProperty(ZedGraphControl zg)
        {
            
            myZedGraph.GraphPane.Border.Color = System.Drawing.ColorTranslator.FromHtml("#EDEDED");
            myZedGraph.GraphPane.Border.Width = 8F;
            zg.IsShowPointValues = true;
            GraphPane myPane = zg.GraphPane;
            myPane.Title.Text = "Performance";
            myPane.YAxis.Title.Text = "Speed";
            myPane.XAxis.Title.Text = "Datetime";
            myPane.XAxis.Type = AxisType.Date;
            myPane.XAxis.Scale.Format = "dd-MM-yy hh:mm tt";
            myPane.XAxis.Scale.MajorUnit = DateUnit.Day;
            myPane.XAxis.Scale.MajorStep = 1;
            myPane.XAxis.Scale.Min = new XDate(DateTime.Now.AddDays(-3));
            myPane.XAxis.Scale.Max = new XDate(DateTime.Now.AddDays(0));
            myPane.YAxis.Scale.MaxAuto = true;

            LineItem P601Curve = myPane.AddCurve("P601", dspP601, System.Drawing.ColorTranslator.FromHtml("#84D8B3"), SymbolType.None);
            P601Curve.Line.Width = 2F;
            LineItem P604Curve = myPane.AddCurve("P604", dspP604, System.Drawing.ColorTranslator.FromHtml("#FFC475"), SymbolType.None);
            P604Curve.Line.Width = 2F;
            LineItem P605Curve = myPane.AddCurve("P605", dspP605, System.Drawing.ColorTranslator.FromHtml("#40D7D9"), SymbolType.None);
            P605Curve.Line.Width = 2F;
            LineItem P5MCurve = myPane.AddCurve("P5M", dspP5M, System.Drawing.ColorTranslator.FromHtml("#7CAFD7"), SymbolType.None);
            P5MCurve.Line.Width = 2F;
        }
        
        private void Speed(ZedGraphControl zg)
        {                                         
            if (!cbSearchType.Checked) //Realtime
            {
                 SQL.Instance().Quey_Chart_Printing(DateTime.Now.AddDays(-3), DateTime.Now);                    
            }
            else //History
            {
                SQL.Instance().Quey_Chart_Printing(dtpStarttime.Value, dtpEndtime.Value);
            }
            dspP601 = new DataSourcePointList();
            dspP601.DataSource = SQL.Instance().dt_Speed_Printing;           
            dspP604 = new DataSourcePointList();
            dspP604.DataSource = SQL.Instance().dt_Speed_Printing;           
            dspP605 = new DataSourcePointList();
            dspP605.DataSource = SQL.Instance().dt_Speed_Printing;
            dspP5M = new DataSourcePointList();
            dspP5M.DataSource = SQL.Instance().dt_Speed_Printing;
            dspP601.XDataMember = "Datetime";
            dspP601.YDataMember = "P601";
            dspP604.XDataMember = "Datetime";
            dspP604.YDataMember = "P604";
            dspP605.XDataMember = "Datetime";
            dspP605.YDataMember = "P605";
            dspP5M.XDataMember = "Datetime";
            dspP5M.YDataMember = "P5M";
            GraphPane myPane = zg.GraphPane;
            myPane.CurveList[0].Points = dspP601;
            myPane.CurveList[1].Points = dspP604;
            myPane.CurveList[2].Points = dspP605;
            myPane.CurveList[3].Points = dspP5M;
            zg.AxisChange();
            zg.Refresh();
        }
   
        private void P601_Event(DataGridView dgv)
        {
            if (!cbSearchType.Checked) //Realtime
            {
                SQL.Instance().Query_Event("P601", DateTime.Now.AddDays(-2), DateTime.Now);
            }
            else //History
            {
                SQL.Instance().Query_Event("P601", dtpStarttime.Value, dtpEndtime.Value);
            }          
            dgv.ReadOnly = true;
            dgv.DataSource = SQL.Instance().dtP601_Event;
            SetDataGridViewStyle(dgv); 
        }

        private void P604_Event(DataGridView dgv)
        {
            if (!cbSearchType.Checked) //Realtime
            {
                SQL.Instance().Query_Event("P604", DateTime.Now.AddDays(-2), DateTime.Now);
            }
            else //History
            {
                SQL.Instance().Query_Event("P604", dtpStarttime.Value, dtpEndtime.Value);
            }
            dgv.ReadOnly = true;
            dgv.DataSource = SQL.Instance().dtP604_Event;
            SetDataGridViewStyle(dgv);
        }

        private void P605_Event(DataGridView dgv)
        {
            if (!cbSearchType.Checked) //Realtime
            {
                SQL.Instance().Query_Event("P605", DateTime.Now.AddDays(-2), DateTime.Now);
            }
            else //History
            {
                SQL.Instance().Query_Event("P605", dtpStarttime.Value, dtpEndtime.Value);
            }
            dgv.ReadOnly = true;
            dgv.DataSource = SQL.Instance().dtP605_Event;
            SetDataGridViewStyle(dgv);
        }

        private void P5M_Event(DataGridView dgv)
        {
            if (!cbSearchType.Checked) //Realtime
            {
                SQL.Instance().Query_Event("P5M", DateTime.Now.AddDays(-2), DateTime.Now);
            }
            else //History
            {
                SQL.Instance().Query_Event("P5M", dtpStarttime.Value, dtpEndtime.Value);
            }
            dgv.ReadOnly = true;
            dgv.DataSource = SQL.Instance().dtP5M_Event;
            SetDataGridViewStyle(dgv);
        }

        private void SetDataGridViewStyle(DataGridView dgv)
        {
            dgv.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dgv.BorderStyle = BorderStyle.None;
            dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#717578");
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersHeight = 30;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    switch (row.Cells[1].Value.ToString())
                    {
                        case "READY":
                            row.Cells[1].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#B7FFB7");
                            break;
                        case "RUNNING":
                            row.Cells[1].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#00FF00");
                            break;
                        case "PAUSE":
                            row.Cells[1].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF00");
                            row.Cells[1].Style.ForeColor = Color.Red;
                            break;
                        case "BREAK TIME":
                            row.Cells[1].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFCC99");
                            break;
                        case "FIXING":
                            row.Cells[1].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#C6C6FF");
                            break;
                        case "OTHER":
                            row.Cells[1].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#FE0000");
                            row.Cells[1].Style.ForeColor = Color.White;
                            break;
                        case "PENDING":
                            row.Cells[1].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF00FF");
                            break;
                        case "MAINTAIN":
                            row.Cells[1].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBBFF");
                            break;
                        case "FINISH":
                            row.Cells[1].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#00FFFF");
                            break;
                        case "TESTING":
                            row.Cells[1].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#2B9DFD");
                            break;
                    }
                }
            }
        }
        private void lbEvent_Click(object sender, EventArgs e)
        {
            SetDataGridViewStyle(dgvP601);
            SetDataGridViewStyle(dgvP604);
            SetDataGridViewStyle(dgvP605);
            SetDataGridViewStyle(dgvP5M);
        }
        private void bcbP601_OnChange(object sender, EventArgs e)
        {
            if (!bcbP601.Checked)
            {
                myZedGraph.GraphPane.CurveList[0].IsVisible = false;
                myZedGraph.Refresh();
            }
            else
            {
                myZedGraph.GraphPane.CurveList[0].IsVisible = true;
                myZedGraph.Refresh();
            }
        }

        private void bcbP604_OnChange(object sender, EventArgs e)
        {
            if (!bcbP604.Checked)
            {
                myZedGraph.GraphPane.CurveList[1].IsVisible = false;
                myZedGraph.Refresh();
            }
            else
            {
                myZedGraph.GraphPane.CurveList[1].IsVisible = true;
                myZedGraph.Refresh();
            }
        }
        private void bcbP605_OnChange(object sender, EventArgs e)
        {
            if (!bcbP605.Checked)
            {
                myZedGraph.GraphPane.CurveList[2].IsVisible = false;
                myZedGraph.Refresh();
            }
            else
            {
                myZedGraph.GraphPane.CurveList[2].IsVisible = true;
                myZedGraph.Refresh();
            }
        }
        private void bcbP5M_OnChange(object sender, EventArgs e)
        {
            if (!bcbP5M.Checked)
            {
                myZedGraph.GraphPane .CurveList[3].IsVisible = false;
                myZedGraph.Refresh();
            }
            else
            {
                myZedGraph.GraphPane.CurveList[3].IsVisible = true;
                myZedGraph.Refresh();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Speed(myZedGraph);
            P601_Event(dgvP601);
            P604_Event(dgvP604);
            P605_Event(dgvP605);
            P5M_Event(dgvP5M);
        }

        private void cbSearchType_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSearchType.Checked)
            {
                cbSearchType.Text = "History";
                dtpStarttime.Visible = true;
                dtpEndtime.Visible = true;
                btSearch.Visible = true;
                timer1.Stop();
            }
            else
            {
                cbSearchType.Text = "Realtime";
                dtpStarttime.Visible = false;
                dtpEndtime.Visible = false;
                btSearch.Visible = false;
                timer1.Start();
            }
        }

        string TimeDuration;
        private void btDay_Click(object sender, EventArgs e)
        {
            timer1.Start();
            //SQL.Instance().Query_Event("P601", DateTime.Now.AddDays(-1), DateTime.Now);
            //dgvP601.ReadOnly = true;
            //dgvP601.DataSource = SQL.Instance().dtP601_Event;
            //SetDataGridViewStyle(dgvP601);

            //SQL.Instance().Query_Event("P604", DateTime.Now.AddDays(-1), DateTime.Now);
            //dgvP604.ReadOnly = true;
            //dgvP604.DataSource = SQL.Instance().dtP604_Event;
            //SetDataGridViewStyle(dgvP604);

            //SQL.Instance().Query_Event("P605", DateTime.Now.AddDays(-1), DateTime.Now);
            //dgvP605.ReadOnly = true;
            //dgvP605.DataSource = SQL.Instance().dtP605_Event;
            //SetDataGridViewStyle(dgvP605);

            //SQL.Instance().Query_Event("P5M", DateTime.Now.AddDays(-1), DateTime.Now);
            //dgvP5M.ReadOnly = true;
            //dgvP5M.DataSource = SQL.Instance().dtP5M_Event;
            //SetDataGridViewStyle(dgvP5M);
        }

        private void btWeek_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            DateTime now = DateTime.Now;
            DayOfWeek startOfWeek = DayOfWeek.Monday;
            int diff = (7 + (now.DayOfWeek - startOfWeek)) % 7;
            var startDate = DateTime.Now.AddDays(-1 * diff).Date;

            SQL.Instance().Quey_Chart_Printing(startDate, DateTime.Now);
            dspP601 = new DataSourcePointList();
            dspP601.DataSource = SQL.Instance().dt_Speed_Printing;
            dspP604 = new DataSourcePointList();
            dspP604.DataSource = SQL.Instance().dt_Speed_Printing;
            dspP605 = new DataSourcePointList();
            dspP605.DataSource = SQL.Instance().dt_Speed_Printing;
            dspP5M = new DataSourcePointList();
            dspP5M.DataSource = SQL.Instance().dt_Speed_Printing;
            dspP601.XDataMember = "Datetime";
            dspP601.YDataMember = "P601";
            dspP604.XDataMember = "Datetime";
            dspP604.YDataMember = "P604";
            dspP605.XDataMember = "Datetime";
            dspP605.YDataMember = "P605";
            dspP5M.XDataMember = "Datetime";
            dspP5M.YDataMember = "P5M";
            GraphPane myPane = myZedGraph.GraphPane;
            myPane.CurveList[0].Points = dspP601;
            myPane.CurveList[1].Points = dspP604;
            myPane.CurveList[2].Points = dspP605;
            myPane.CurveList[3].Points = dspP5M;
            myZedGraph.AxisChange();
            myZedGraph.Refresh();

            SQL.Instance().Query_Event("P601", startDate, DateTime.Now);
            dgvP601.ReadOnly = true;
            dgvP601.DataSource = SQL.Instance().dtP601_Event;
            SetDataGridViewStyle(dgvP601);

            SQL.Instance().Query_Event("P604", startDate, DateTime.Now);
            dgvP604.ReadOnly = true;
            dgvP604.DataSource = SQL.Instance().dtP604_Event;
            SetDataGridViewStyle(dgvP604);

            SQL.Instance().Query_Event("P605", startDate, DateTime.Now);
            dgvP605.ReadOnly = true;
            dgvP605.DataSource = SQL.Instance().dtP605_Event;
            SetDataGridViewStyle(dgvP605);

            SQL.Instance().Query_Event("P5M", startDate, DateTime.Now);
            dgvP5M.ReadOnly = true;
            dgvP5M.DataSource = SQL.Instance().dtP5M_Event;
            SetDataGridViewStyle(dgvP5M);
        }

        private void btMonth_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);

            SQL.Instance().Quey_Chart_Printing(startDate, DateTime.Now);
            dspP601 = new DataSourcePointList();
            dspP601.DataSource = SQL.Instance().dt_Speed_Printing;
            dspP604 = new DataSourcePointList();
            dspP604.DataSource = SQL.Instance().dt_Speed_Printing;
            dspP605 = new DataSourcePointList();
            dspP605.DataSource = SQL.Instance().dt_Speed_Printing;
            dspP5M = new DataSourcePointList();
            dspP5M.DataSource = SQL.Instance().dt_Speed_Printing;
            dspP601.XDataMember = "Datetime";
            dspP601.YDataMember = "P601";
            dspP604.XDataMember = "Datetime";
            dspP604.YDataMember = "P604";
            dspP605.XDataMember = "Datetime";
            dspP605.YDataMember = "P605";
            dspP5M.XDataMember = "Datetime";
            dspP5M.YDataMember = "P5M";
            GraphPane myPane = myZedGraph.GraphPane;
            myPane.CurveList[0].Points = dspP601;
            myPane.CurveList[1].Points = dspP604;
            myPane.CurveList[2].Points = dspP605;
            myPane.CurveList[3].Points = dspP5M;
            myZedGraph.AxisChange();
            myZedGraph.Refresh();

            SQL.Instance().Query_Event("P601", startDate, DateTime.Now);
            dgvP601.ReadOnly = true;
            dgvP601.DataSource = SQL.Instance().dtP601_Event;
            SetDataGridViewStyle(dgvP601);

            SQL.Instance().Query_Event("P601", startDate, DateTime.Now);
            dgvP601.ReadOnly = true;
            dgvP601.DataSource = SQL.Instance().dtP601_Event;
            SetDataGridViewStyle(dgvP601);

            SQL.Instance().Query_Event("P604", startDate, DateTime.Now);
            dgvP604.ReadOnly = true;
            dgvP604.DataSource = SQL.Instance().dtP604_Event;
            SetDataGridViewStyle(dgvP604);

            SQL.Instance().Query_Event("P605", startDate, DateTime.Now);
            dgvP605.ReadOnly = true;
            dgvP605.DataSource = SQL.Instance().dtP605_Event;
            SetDataGridViewStyle(dgvP605);

            SQL.Instance().Query_Event("P5M", startDate, DateTime.Now);
            dgvP5M.ReadOnly = true;
            dgvP5M.DataSource = SQL.Instance().dtP5M_Event;
            SetDataGridViewStyle(dgvP5M);
        }

        private void btYear_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, 1, 1);

            SQL.Instance().Quey_Chart_Printing(startDate, DateTime.Now);
            dspP601 = new DataSourcePointList();
            dspP601.DataSource = SQL.Instance().dt_Speed_Printing;
            dspP604 = new DataSourcePointList();
            dspP604.DataSource = SQL.Instance().dt_Speed_Printing;
            dspP605 = new DataSourcePointList();
            dspP605.DataSource = SQL.Instance().dt_Speed_Printing;
            dspP5M = new DataSourcePointList();
            dspP5M.DataSource = SQL.Instance().dt_Speed_Printing;
            dspP601.XDataMember = "Datetime";
            dspP601.YDataMember = "P601";
            dspP604.XDataMember = "Datetime";
            dspP604.YDataMember = "P604";
            dspP605.XDataMember = "Datetime";
            dspP605.YDataMember = "P605";
            dspP5M.XDataMember = "Datetime";
            dspP5M.YDataMember = "P5M";
            GraphPane myPane = myZedGraph.GraphPane;
            myPane.CurveList[0].Points = dspP601;
            myPane.CurveList[1].Points = dspP604;
            myPane.CurveList[2].Points = dspP605;
            myPane.CurveList[3].Points = dspP5M;
            myZedGraph.AxisChange();
            myZedGraph.Refresh();

            SQL.Instance().Query_Event("P601", startDate, DateTime.Now);
            dgvP601.ReadOnly = true;
            dgvP601.DataSource = SQL.Instance().dtP601_Event;
            SetDataGridViewStyle(dgvP601);

            SQL.Instance().Query_Event("P601", startDate, DateTime.Now);
            dgvP601.ReadOnly = true;
            dgvP601.DataSource = SQL.Instance().dtP601_Event;
            SetDataGridViewStyle(dgvP601);

            SQL.Instance().Query_Event("P604", startDate, DateTime.Now);
            dgvP604.ReadOnly = true;
            dgvP604.DataSource = SQL.Instance().dtP604_Event;
            SetDataGridViewStyle(dgvP604);

            SQL.Instance().Query_Event("P605", startDate, DateTime.Now);
            dgvP605.ReadOnly = true;
            dgvP605.DataSource = SQL.Instance().dtP605_Event;
            SetDataGridViewStyle(dgvP605);

            SQL.Instance().Query_Event("P5M", startDate, DateTime.Now);
            dgvP5M.ReadOnly = true;
            dgvP5M.DataSource = SQL.Instance().dtP5M_Event;
            SetDataGridViewStyle(dgvP5M);
        }
    }
}
