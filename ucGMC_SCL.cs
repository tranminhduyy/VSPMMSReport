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
    public partial class ucGMC_SCL : UserControl
    {
        public ucGMC_SCL()
        {
            InitializeComponent();
        }

        private void ucGMC_SCL_Load(object sender, EventArgs e)
        {
            SetZedGraphProperty(myZedGraph);
            dtpStarttime.Visible = false;
            dtpEndtime.Visible = false;
            btSearch.Visible = false;
            
            Speed(myZedGraph);
            GMC1_Event(dgvGMC1);
            GMC2_Event(dgvGMC2);
            SCL_Event(dgvSCL);

            timer1.Enabled = true;
            timer1.Start();
        }

        DataSourcePointList dspGMC1;
        DataSourcePointList dspGMC2;
        DataSourcePointList dspSCL;

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


            LineItem GMC1Curve = myPane.AddCurve("GMC1", dspGMC1, System.Drawing.ColorTranslator.FromHtml("#84D8B3"), SymbolType.None);
            GMC1Curve.Line.Width = 2F;
            LineItem GMC2Curve = myPane.AddCurve("GMC2", dspGMC2, System.Drawing.ColorTranslator.FromHtml("#FFC475"), SymbolType.None);
            GMC2Curve.Line.Width = 2F;
            LineItem SCLCurve = myPane.AddCurve("SCL", dspSCL, System.Drawing.ColorTranslator.FromHtml("#40D7D9"), SymbolType.None);
            SCLCurve.Line.Width = 2F;
            zg.AxisChange();
        }
        private void Speed(ZedGraphControl zg)
        {
            if (!cbSearchType.Checked) //Realtime
            {
                SQL.Instance().Quey_Chart_GMCSCL(DateTime.Now.AddDays(-3), DateTime.Now);
            }
            else //History
            {
                SQL.Instance().Quey_Chart_GMCSCL(dtpStarttime.Value, dtpEndtime.Value);
            }
            DataSourcePointList dspGMC1 = new DataSourcePointList();
            dspGMC1.DataSource = SQL.Instance().dt_Speed_GMCSCL;
            dspGMC1.XDataMember = "Datetime";
            dspGMC1.YDataMember = "GMC1";
            DataSourcePointList dspGMC2 = new DataSourcePointList();
            dspGMC2.DataSource = SQL.Instance().dt_Speed_GMCSCL;
            dspGMC2.XDataMember = "Datetime";
            dspGMC2.YDataMember = "GMC2";
            DataSourcePointList dspSCL = new DataSourcePointList();
            dspSCL.DataSource = SQL.Instance().dt_Speed_GMCSCL;
            dspSCL.XDataMember = "Datetime";
            dspSCL.YDataMember = "SCL";

            GraphPane myPane = zg.GraphPane;
            myPane.CurveList[0].Points = dspGMC1;
            myPane.CurveList[1].Points = dspGMC2;
            myPane.CurveList[2].Points = dspSCL;
            zg.AxisChange();
            zg.Refresh();
        }

        private void GMC1_Event(DataGridView dgv)
        {
            if (!cbSearchType.Checked) //Realtime
            {
                SQL.Instance().Query_Event("GMC1", DateTime.Now.AddDays(-2), DateTime.Now);
            }
            else //History
            {
                SQL.Instance().Query_Event("GMC1", dtpStarttime.Value, dtpEndtime.Value);
            }
            dgv.ReadOnly = true;
            dgv.DataSource = SQL.Instance().dtGMC1_Event;
            SetDataGridViewStyle(dgv); 
        }

        private void GMC2_Event(DataGridView dgv)
        {
            if (!cbSearchType.Checked) //Realtime
            {
                SQL.Instance().Query_Event("GMC2", DateTime.Now.AddDays(-2), DateTime.Now);
            }
            else //History
            {
                SQL.Instance().Query_Event("GMC2", dtpStarttime.Value, dtpEndtime.Value);
            }
            dgv.ReadOnly = true;
            dgv.DataSource = SQL.Instance().dtGMC2_Event;
            SetDataGridViewStyle(dgv);
        }

        private void SCL_Event(DataGridView dgv)
        {
            if (!cbSearchType.Checked) //Realtime
            {
                SQL.Instance().Query_Event("SCL", DateTime.Now.AddDays(-2), DateTime.Now);
            }
            else //History
            {
                SQL.Instance().Query_Event("SCL", dtpStarttime.Value, dtpEndtime.Value);
            }
            dgv.ReadOnly = true;
            dgv.DataSource = SQL.Instance().dtSCL_Event;
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
            SetDataGridViewStyle(dgvGMC1);
            SetDataGridViewStyle(dgvGMC2);
            SetDataGridViewStyle(dgvSCL);
        }
        private void bcbGMC1_OnChange(object sender, EventArgs e)
        {
            if (!bcbGMC1.Checked)
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

        private void bcbGMC2_OnChange(object sender, EventArgs e)
        {
            if (!bcbGMC2.Checked)
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
        private void bcbSCL_OnChange(object sender, EventArgs e)
        {
            if (!bcbSCL.Checked)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            Speed(myZedGraph);
            GMC1_Event(dgvGMC1);
            GMC2_Event(dgvGMC2);
            SCL_Event(dgvSCL);
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

        private void btSearch_Click(object sender, EventArgs e)
        {
            Speed(myZedGraph);
            GMC1_Event(dgvGMC1);
            GMC2_Event(dgvGMC2);
            SCL_Event(dgvSCL);
        }

        private void btDay_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btWeek_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            DateTime now = DateTime.Now;
            DayOfWeek startOfWeek = DayOfWeek.Monday;
            int diff = (7 + (now.DayOfWeek - startOfWeek)) % 7;
            var startDate = DateTime.Now.AddDays(-1 * diff).Date;

            SQL.Instance().Quey_Chart_GMCSCL(startDate, DateTime.Now);
            dspGMC1 = new DataSourcePointList();
            dspGMC1.DataSource = SQL.Instance().dt_Speed_GMCSCL;
            dspGMC2 = new DataSourcePointList();
            dspGMC2.DataSource = SQL.Instance().dt_Speed_GMCSCL;
            dspSCL = new DataSourcePointList();
            dspSCL.DataSource = SQL.Instance().dt_Speed_GMCSCL;
            dspGMC1.XDataMember = "Datetime";
            dspGMC1.YDataMember = "GMC1";
            dspGMC2.XDataMember = "Datetime";
            dspGMC2.YDataMember = "GMC2";
            dspSCL.XDataMember = "Datetime";
            dspSCL.YDataMember = "SCL";
            GraphPane myPane = myZedGraph.GraphPane;
            myPane.CurveList[0].Points = dspGMC1;
            myPane.CurveList[1].Points = dspGMC2;
            myPane.CurveList[2].Points = dspSCL;
            myZedGraph.AxisChange();
            myZedGraph.Refresh();

            SQL.Instance().Query_Event("GMC1", startDate, DateTime.Now);
            dgvGMC1.ReadOnly = true;
            dgvGMC1.DataSource = SQL.Instance().dtGMC1_Event;
            SetDataGridViewStyle(dgvGMC1);

            SQL.Instance().Query_Event("GMC2", startDate, DateTime.Now);
            dgvGMC2.ReadOnly = true;
            dgvGMC2.DataSource = SQL.Instance().dtGMC2_Event;
            SetDataGridViewStyle(dgvGMC2);

            SQL.Instance().Query_Event("SCL", startDate, DateTime.Now);
            dgvSCL.ReadOnly = true;
            dgvSCL.DataSource = SQL.Instance().dtSCL_Event;
            SetDataGridViewStyle(dgvSCL);
        }

        private void btMonth_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);

            SQL.Instance().Quey_Chart_GMCSCL(startDate, DateTime.Now);
            dspGMC1 = new DataSourcePointList();
            dspGMC1.DataSource = SQL.Instance().dt_Speed_GMCSCL;
            dspGMC2 = new DataSourcePointList();
            dspGMC2.DataSource = SQL.Instance().dt_Speed_GMCSCL;
            dspSCL = new DataSourcePointList();
            dspSCL.DataSource = SQL.Instance().dt_Speed_GMCSCL;
            dspGMC1.XDataMember = "Datetime";
            dspGMC1.YDataMember = "GMC1";
            dspGMC2.XDataMember = "Datetime";
            dspGMC2.YDataMember = "GMC2";
            dspSCL.XDataMember = "Datetime";
            dspSCL.YDataMember = "SCL";
            GraphPane myPane = myZedGraph.GraphPane;
            myPane.CurveList[0].Points = dspGMC1;
            myPane.CurveList[1].Points = dspGMC2;
            myPane.CurveList[2].Points = dspSCL;
            myZedGraph.AxisChange();
            myZedGraph.Refresh();

            SQL.Instance().Query_Event("GMC1", startDate, DateTime.Now);
            dgvGMC1.ReadOnly = true;
            dgvGMC1.DataSource = SQL.Instance().dtGMC1_Event;
            SetDataGridViewStyle(dgvGMC1);

            SQL.Instance().Query_Event("GMC2", startDate, DateTime.Now);
            dgvGMC2.ReadOnly = true;
            dgvGMC2.DataSource = SQL.Instance().dtGMC2_Event;
            SetDataGridViewStyle(dgvGMC2);

            SQL.Instance().Query_Event("SCL", startDate, DateTime.Now);
            dgvSCL.ReadOnly = true;
            dgvSCL.DataSource = SQL.Instance().dtSCL_Event;
            SetDataGridViewStyle(dgvSCL);
        }

        private void btYear_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, 1, 1);

            SQL.Instance().Quey_Chart_GMCSCL(startDate, DateTime.Now);
            dspGMC1 = new DataSourcePointList();
            dspGMC1.DataSource = SQL.Instance().dt_Speed_GMCSCL;
            dspGMC2 = new DataSourcePointList();
            dspGMC2.DataSource = SQL.Instance().dt_Speed_GMCSCL;
            dspSCL = new DataSourcePointList();
            dspSCL.DataSource = SQL.Instance().dt_Speed_GMCSCL;
            dspGMC1.XDataMember = "Datetime";
            dspGMC1.YDataMember = "GMC1";
            dspGMC2.XDataMember = "Datetime";
            dspGMC2.YDataMember = "GMC2";
            dspSCL.XDataMember = "Datetime";
            dspSCL.YDataMember = "SCL";
            GraphPane myPane = myZedGraph.GraphPane;
            myPane.CurveList[0].Points = dspGMC1;
            myPane.CurveList[1].Points = dspGMC2;
            myPane.CurveList[2].Points = dspSCL;
            myZedGraph.AxisChange();
            myZedGraph.Refresh();

            SQL.Instance().Query_Event("GMC1", startDate, DateTime.Now);
            dgvGMC1.ReadOnly = true;
            dgvGMC1.DataSource = SQL.Instance().dtGMC1_Event;
            SetDataGridViewStyle(dgvGMC1);

            SQL.Instance().Query_Event("GMC2", startDate, DateTime.Now);
            dgvGMC2.ReadOnly = true;
            dgvGMC2.DataSource = SQL.Instance().dtGMC2_Event;
            SetDataGridViewStyle(dgvGMC2);

            SQL.Instance().Query_Event("SCL", startDate, DateTime.Now);
            dgvSCL.ReadOnly = true;
            dgvSCL.DataSource = SQL.Instance().dtSCL_Event;
            SetDataGridViewStyle(dgvSCL);
        }
    }
}
