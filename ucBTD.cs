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
    public partial class ucBTD : UserControl
    {
        public ucBTD()
        {
            InitializeComponent();
        }

        private void ucBTD_Load(object sender, EventArgs e)
        {
            SetZedGraphProperty(myZedGraph);
            dtpStarttime.Visible = false;
            dtpEndtime.Visible = false;
            btSearch.Visible = false;
            //SQL.Instance().TestConnection();
            Speed(myZedGraph);
            BTD2_Event(dgvBTD2);
            BTD3_Event(dgvBTD3);
            BTD4_Event(dgvBTD4);
            BTD5_Event(dgvBTD5);

            timer1.Enabled = true;
            timer1.Start();
        }

        DataSourcePointList dspBTD2;
        DataSourcePointList dspBTD3;
        DataSourcePointList dspBTD4;
        DataSourcePointList dspBTD5;

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


            LineItem BTD2Curve = myPane.AddCurve("BTD2", dspBTD2, System.Drawing.ColorTranslator.FromHtml("#84D8B3"), SymbolType.None);
            BTD2Curve.Line.Width = 2F;
            LineItem BTD3Curve = myPane.AddCurve("BTD3", dspBTD3, System.Drawing.ColorTranslator.FromHtml("#FFC475"), SymbolType.None);
            BTD3Curve.Line.Width = 2F;
            LineItem BTD4Curve = myPane.AddCurve("BTD4", dspBTD4, System.Drawing.ColorTranslator.FromHtml("#40D7D9"), SymbolType.None);
            BTD4Curve.Line.Width = 2F;
            LineItem BTD5Curve = myPane.AddCurve("BTD5", dspBTD5, System.Drawing.ColorTranslator.FromHtml("#7CAFD7"), SymbolType.None);
            BTD5Curve.Line.Width = 2F;
            zg.AxisChange();
        }

        private void Speed(ZedGraphControl zg)
        {
            if (!cbSearchType.Checked) //Realtime
            {
                SQL.Instance().Quey_Chart_Diecut(DateTime.Now.AddDays(-3), DateTime.Now);
            }
            else //History
            {
                SQL.Instance().Quey_Chart_Diecut(dtpStarttime.Value, dtpEndtime.Value);
            }
            dspBTD2 = new DataSourcePointList();
            dspBTD2.DataSource = SQL.Instance().dt_Speed_Diecut;
            dspBTD3 = new DataSourcePointList();
            dspBTD3.DataSource = SQL.Instance().dt_Speed_Diecut;
            dspBTD4 = new DataSourcePointList();
            dspBTD4.DataSource = SQL.Instance().dt_Speed_Diecut;
            dspBTD5 = new DataSourcePointList();
            dspBTD5.DataSource = SQL.Instance().dt_Speed_Diecut;

            dspBTD2.XDataMember = "Datetime";
            dspBTD2.YDataMember = "BTD2";
            dspBTD3.XDataMember = "Datetime";
            dspBTD3.YDataMember = "BTD3";
            dspBTD4.XDataMember = "Datetime";
            dspBTD4.YDataMember = "BTD4";
            dspBTD5.XDataMember = "Datetime";
            dspBTD5.YDataMember = "BTD5";

            GraphPane myPane = zg.GraphPane;
            myPane.CurveList[0].Points = dspBTD2;
            myPane.CurveList[1].Points = dspBTD3;
            myPane.CurveList[2].Points = dspBTD4;
            myPane.CurveList[3].Points = dspBTD5;
            zg.AxisChange();
            zg.Refresh();
        }

        private void BTD2_Event(DataGridView dgv)
        {
            if (!cbSearchType.Checked) //Realtime
            {
                SQL.Instance().Query_Event("BTD2", DateTime.Now.AddDays(-2), DateTime.Now);
            }
            else //History
            {
                SQL.Instance().Query_Event("BTD2", dtpStarttime.Value, dtpEndtime.Value);
            }
            dgv.ReadOnly = true;
            dgv.DataSource = SQL.Instance().dtBTD2_Event;
            SetDataGridViewStyle(dgv); 
        }

        private void BTD3_Event(DataGridView dgv)
        {
            if (!cbSearchType.Checked) //Realtime
            {
                SQL.Instance().Query_Event("BTD3", DateTime.Now.AddDays(-2), DateTime.Now);
            }
            else //History
            {
                SQL.Instance().Query_Event("BTD3", dtpStarttime.Value, dtpEndtime.Value);
            }
            dgv.ReadOnly = true;
            dgv.DataSource = SQL.Instance().dtBTD3_Event;
            SetDataGridViewStyle(dgv);
        }

        private void BTD4_Event(DataGridView dgv)
        {
            if (!cbSearchType.Checked) //Realtime
            {
                SQL.Instance().Query_Event("BTD4", DateTime.Now.AddDays(-2), DateTime.Now);
            }
            else //History
            {
                SQL.Instance().Query_Event("BTD4", dtpStarttime.Value, dtpEndtime.Value);
            }
            dgv.ReadOnly = true;
            dgv.DataSource = SQL.Instance().dtBTD4_Event;
            SetDataGridViewStyle(dgv);
        }

        private void BTD5_Event(DataGridView dgv)
        {
            if (!cbSearchType.Checked) //Realtime
            {
                SQL.Instance().Query_Event("BTD5", DateTime.Now.AddDays(-2), DateTime.Now);
            }
            else //History
            {
                SQL.Instance().Query_Event("BTD5", dtpStarttime.Value, dtpEndtime.Value);
            }
            dgv.ReadOnly = true;
            dgv.DataSource = SQL.Instance().dtBTD5_Event;
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
            SetDataGridViewStyle(dgvBTD2);
            SetDataGridViewStyle(dgvBTD3);
            SetDataGridViewStyle(dgvBTD4);
            SetDataGridViewStyle(dgvBTD5);
        }
        private void bcbBTD2_OnChange(object sender, EventArgs e)
        {
            if (!bcbBTD2.Checked)
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

        private void bcbBTD3_OnChange(object sender, EventArgs e)
        {
            if (!bcbBTD3.Checked)
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
        private void bcbBTD4_OnChange(object sender, EventArgs e)
        {
            if (!bcbBTD4.Checked)
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
        private void bcbBTD5_OnChange(object sender, EventArgs e)
        {
            if (!bcbBTD5.Checked)
            {
                myZedGraph.GraphPane.CurveList[3].IsVisible = false;
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
            BTD2_Event(dgvBTD2);
            BTD3_Event(dgvBTD3);
            BTD4_Event(dgvBTD4);
            BTD5_Event(dgvBTD5);
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
            BTD2_Event(dgvBTD2);
            BTD3_Event(dgvBTD3);
            BTD4_Event(dgvBTD4);
            BTD5_Event(dgvBTD5);
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

            SQL.Instance().Quey_Chart_Diecut(startDate, DateTime.Now);
            dspBTD2 = new DataSourcePointList();
            dspBTD2.DataSource = SQL.Instance().dt_Speed_Diecut;
            dspBTD3 = new DataSourcePointList();
            dspBTD3.DataSource = SQL.Instance().dt_Speed_Diecut;
            dspBTD4 = new DataSourcePointList();
            dspBTD4.DataSource = SQL.Instance().dt_Speed_Diecut;
            dspBTD5 = new DataSourcePointList();
            dspBTD5.DataSource = SQL.Instance().dt_Speed_Diecut;
            dspBTD2.XDataMember = "Datetime";
            dspBTD2.YDataMember = "BTD2";
            dspBTD3.XDataMember = "Datetime";
            dspBTD3.YDataMember = "BTD3";
            dspBTD4.XDataMember = "Datetime";
            dspBTD4.YDataMember = "BTD4";
            dspBTD5.XDataMember = "Datetime";
            dspBTD5.YDataMember = "BTD5";
            GraphPane myPane = myZedGraph.GraphPane;
            myPane.CurveList[0].Points = dspBTD2;
            myPane.CurveList[1].Points = dspBTD3;
            myPane.CurveList[2].Points = dspBTD4;
            myPane.CurveList[3].Points = dspBTD5;
            myZedGraph.AxisChange();
            myZedGraph.Refresh();

            SQL.Instance().Query_Event("BTD2", startDate, DateTime.Now);
            dgvBTD2.ReadOnly = true;
            dgvBTD2.DataSource = SQL.Instance().dtBTD2_Event;
            SetDataGridViewStyle(dgvBTD2);

            SQL.Instance().Query_Event("BTD3", startDate, DateTime.Now);
            dgvBTD3.ReadOnly = true;
            dgvBTD3.DataSource = SQL.Instance().dtBTD3_Event;
            SetDataGridViewStyle(dgvBTD3);

            SQL.Instance().Query_Event("BTD4", startDate, DateTime.Now);
            dgvBTD4.ReadOnly = true;
            dgvBTD4.DataSource = SQL.Instance().dtBTD4_Event;
            SetDataGridViewStyle(dgvBTD4);

            SQL.Instance().Query_Event("BTD5", startDate, DateTime.Now);
            dgvBTD5.ReadOnly = true;
            dgvBTD5.DataSource = SQL.Instance().dtBTD5_Event;
            SetDataGridViewStyle(dgvBTD5);
        }

        private void btMonth_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);

            SQL.Instance().Quey_Chart_Diecut(startDate, DateTime.Now);
            dspBTD2 = new DataSourcePointList();
            dspBTD2.DataSource = SQL.Instance().dt_Speed_Diecut;
            dspBTD3 = new DataSourcePointList();
            dspBTD3.DataSource = SQL.Instance().dt_Speed_Diecut;
            dspBTD4 = new DataSourcePointList();
            dspBTD4.DataSource = SQL.Instance().dt_Speed_Diecut;
            dspBTD5 = new DataSourcePointList();
            dspBTD5.DataSource = SQL.Instance().dt_Speed_Diecut;
            dspBTD2.XDataMember = "Datetime";
            dspBTD2.YDataMember = "BTD2";
            dspBTD3.XDataMember = "Datetime";
            dspBTD3.YDataMember = "BTD3";
            dspBTD4.XDataMember = "Datetime";
            dspBTD4.YDataMember = "BTD4";
            dspBTD5.XDataMember = "Datetime";
            dspBTD5.YDataMember = "BTD5";
            GraphPane myPane = myZedGraph.GraphPane;
            myPane.CurveList[0].Points = dspBTD2;
            myPane.CurveList[1].Points = dspBTD3;
            myPane.CurveList[2].Points = dspBTD4;
            myPane.CurveList[3].Points = dspBTD5;
            myZedGraph.AxisChange();
            myZedGraph.Refresh();

            SQL.Instance().Query_Event("BTD2", startDate, DateTime.Now);
            dgvBTD2.ReadOnly = true;
            dgvBTD2.DataSource = SQL.Instance().dtBTD2_Event;
            SetDataGridViewStyle(dgvBTD2);

            SQL.Instance().Query_Event("BTD3", startDate, DateTime.Now);
            dgvBTD3.ReadOnly = true;
            dgvBTD3.DataSource = SQL.Instance().dtBTD3_Event;
            SetDataGridViewStyle(dgvBTD3);

            SQL.Instance().Query_Event("BTD4", startDate, DateTime.Now);
            dgvBTD4.ReadOnly = true;
            dgvBTD4.DataSource = SQL.Instance().dtBTD4_Event;
            SetDataGridViewStyle(dgvBTD4);

            SQL.Instance().Query_Event("BTD5", startDate, DateTime.Now);
            dgvBTD5.ReadOnly = true;
            dgvBTD5.DataSource = SQL.Instance().dtBTD5_Event;
            SetDataGridViewStyle(dgvBTD5);
        }

        private void btYear_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, 1, 1);

            SQL.Instance().Quey_Chart_Diecut(startDate, DateTime.Now);
            dspBTD2 = new DataSourcePointList();
            dspBTD2.DataSource = SQL.Instance().dt_Speed_Diecut;
            dspBTD3 = new DataSourcePointList();
            dspBTD3.DataSource = SQL.Instance().dt_Speed_Diecut;
            dspBTD4 = new DataSourcePointList();
            dspBTD4.DataSource = SQL.Instance().dt_Speed_Diecut;
            dspBTD5 = new DataSourcePointList();
            dspBTD5.DataSource = SQL.Instance().dt_Speed_Diecut;
            dspBTD2.XDataMember = "Datetime";
            dspBTD2.YDataMember = "BTD2";
            dspBTD3.XDataMember = "Datetime";
            dspBTD3.YDataMember = "BTD3";
            dspBTD4.XDataMember = "Datetime";
            dspBTD4.YDataMember = "BTD4";
            dspBTD5.XDataMember = "Datetime";
            dspBTD5.YDataMember = "BTD5";
            GraphPane myPane = myZedGraph.GraphPane;
            myPane.CurveList[0].Points = dspBTD2;
            myPane.CurveList[1].Points = dspBTD3;
            myPane.CurveList[2].Points = dspBTD4;
            myPane.CurveList[3].Points = dspBTD5;
            myZedGraph.AxisChange();
            myZedGraph.Refresh();

            SQL.Instance().Query_Event("BTD2", startDate, DateTime.Now);
            dgvBTD2.ReadOnly = true;
            dgvBTD2.DataSource = SQL.Instance().dtBTD2_Event;
            SetDataGridViewStyle(dgvBTD2);

            SQL.Instance().Query_Event("BTD3", startDate, DateTime.Now);
            dgvBTD3.ReadOnly = true;
            dgvBTD3.DataSource = SQL.Instance().dtBTD3_Event;
            SetDataGridViewStyle(dgvBTD3);

            SQL.Instance().Query_Event("BTD4", startDate, DateTime.Now);
            dgvBTD4.ReadOnly = true;
            dgvBTD4.DataSource = SQL.Instance().dtBTD4_Event;
            SetDataGridViewStyle(dgvBTD4);

            SQL.Instance().Query_Event("BTD5", startDate, DateTime.Now);
            dgvBTD5.ReadOnly = true;
            dgvBTD5.DataSource = SQL.Instance().dtBTD5_Event;
            SetDataGridViewStyle(dgvBTD5);
        }
    }
}
