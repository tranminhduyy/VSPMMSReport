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
    public partial class ucGluing : UserControl
    {
        public ucGluing()
        {
            InitializeComponent();
        }

        private void ucGluing_Load(object sender, EventArgs e)
        {
            SetZedGraphProperty(myZedGraph);
            dtpStarttime.Visible = false;
            dtpEndtime.Visible = false;
            btSearch.Visible = false;
            //SQL.Instance().TestConnection();
            Speed(myZedGraph);
            D650_Event(dgvD650);
            D750_Event(dgvD750);
            D1000_Event(dgvD1000);
            D1100_Event(dgvD1100);

            timer1.Enabled = true;
            timer1.Start();
        }

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


            LineItem D650Curve = myPane.AddCurve("D650", dspD650, System.Drawing.ColorTranslator.FromHtml("#84D8B3"), SymbolType.None);
            D650Curve.Line.Width = 2F;
            LineItem D750Curve = myPane.AddCurve("D750", dspD750, System.Drawing.ColorTranslator.FromHtml("#FFC475"), SymbolType.None);
            D750Curve.Line.Width = 2F;
            LineItem D1000Curve = myPane.AddCurve("D1000", dspD1000, System.Drawing.ColorTranslator.FromHtml("#40D7D9"), SymbolType.None);
            D1000Curve.Line.Width = 2F;
            LineItem D1100Curve = myPane.AddCurve("D1100", dspD1100, System.Drawing.ColorTranslator.FromHtml("#7CAFD7"), SymbolType.None);
            D1100Curve.Line.Width = 2F;
            zg.AxisChange();
        }
        private void Speed(ZedGraphControl zg)
        {
            if (!cbSearchType.Checked) //Realtime
            {
                SQL.Instance().Quey_Chart_Gluing(DateTime.Now.AddDays(-3), DateTime.Now);
            }
            else //History
            {
                SQL.Instance().Quey_Chart_Gluing(dtpStarttime.Value, dtpEndtime.Value);
            }
            DataSourcePointList dspD650 = new DataSourcePointList();
            dspD650.DataSource = SQL.Instance().dt_Speed_Gluing;
            dspD650.XDataMember = "Datetime";
            dspD650.YDataMember = "D650";
            DataSourcePointList dspD750 = new DataSourcePointList();
            dspD750.DataSource = SQL.Instance().dt_Speed_Gluing;
            dspD750.XDataMember = "Datetime";
            dspD750.YDataMember = "D750";
            DataSourcePointList dspD1000 = new DataSourcePointList();
            dspD1000.DataSource = SQL.Instance().dt_Speed_Gluing;
            dspD1000.XDataMember = "Datetime";
            dspD1000.YDataMember = "D1000";
            DataSourcePointList dspD1100 = new DataSourcePointList();
            dspD1100.DataSource = SQL.Instance().dt_Speed_Gluing;
            dspD1100.XDataMember = "Datetime";
            dspD1100.YDataMember = "D1100";

            GraphPane myPane = zg.GraphPane;
            myPane.CurveList[0].Points = dspD650;
            myPane.CurveList[1].Points = dspD750;
            myPane.CurveList[2].Points = dspD1000;
            myPane.CurveList[3].Points = dspD1100;
            zg.AxisChange();
            zg.Refresh();
        }

        private void D650_Event(DataGridView dgv)
        {
            if (!cbSearchType.Checked) //Realtime
            {
                SQL.Instance().Query_Event("D650", DateTime.Now.AddDays(-2), DateTime.Now);
            }
            else //History
            {
                SQL.Instance().Query_Event("D650", dtpStarttime.Value, dtpEndtime.Value);
            }
            dgv.ReadOnly = true;
            dgv.DataSource = SQL.Instance().dtD650_Event;
            SetDataGridViewStyle(dgv); 
        }

        private void D750_Event(DataGridView dgv)
        {
            if (!cbSearchType.Checked) //Realtime
            {
                SQL.Instance().Query_Event("D750", DateTime.Now.AddDays(-2), DateTime.Now);
            }
            else //History
            {
                SQL.Instance().Query_Event("D750", dtpStarttime.Value, dtpEndtime.Value);
            }
            dgv.ReadOnly = true;
            dgv.DataSource = SQL.Instance().dtD750_Event;
            SetDataGridViewStyle(dgv);
        }

        private void D1000_Event(DataGridView dgv)
        {
            if (!cbSearchType.Checked) //Realtime
            {
                SQL.Instance().Query_Event("D1000", DateTime.Now.AddDays(-2), DateTime.Now);
            }
            else //History
            {
                SQL.Instance().Query_Event("D1000", dtpStarttime.Value, dtpEndtime.Value);
            }
            dgv.ReadOnly = true;
            dgv.DataSource = SQL.Instance().dtD1000_Event;
            SetDataGridViewStyle(dgv);
        }

        private void D1100_Event(DataGridView dgv)
        {
            if (!cbSearchType.Checked) //Realtime
            {
                SQL.Instance().Query_Event("D1100", DateTime.Now.AddDays(-2), DateTime.Now);
            }
            else //History
            {
                SQL.Instance().Query_Event("D1100", dtpStarttime.Value, dtpEndtime.Value);
            }
            dgv.ReadOnly = true;
            dgv.DataSource = SQL.Instance().dtD1100_Event;
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
            SetDataGridViewStyle(dgvD650);
            SetDataGridViewStyle(dgvD750);
            SetDataGridViewStyle(dgvD1000);
            SetDataGridViewStyle(dgvD1100);
        }
        private void bcbD650_OnChange(object sender, EventArgs e)
        {
            if (!bcbD650.Checked)
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

        private void bcbD750_OnChange(object sender, EventArgs e)
        {
            if (!bcbD750.Checked)
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
        private void bcbD1000_OnChange(object sender, EventArgs e)
        {
            if (!bcbD1000.Checked)
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
        private void bcbD1100_OnChange(object sender, EventArgs e)
        {
            if (!bcbD1100.Checked)
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
            D650_Event(dgvD650);
            D750_Event(dgvD750);
            D1000_Event(dgvD1000);
            D1100_Event(dgvD1100);
        }

        DataSourcePointList dspD650;
        DataSourcePointList dspD750;
        DataSourcePointList dspD1000;
        DataSourcePointList dspD1100;

        
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
            D650_Event(dgvD650);
            D750_Event(dgvD750);
            D1000_Event(dgvD1000);
            D1100_Event(dgvD1100);
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

            SQL.Instance().Quey_Chart_Gluing(startDate, DateTime.Now);
            dspD650 = new DataSourcePointList();
            dspD650.DataSource = SQL.Instance().dt_Speed_Gluing;
            dspD750 = new DataSourcePointList();
            dspD750.DataSource = SQL.Instance().dt_Speed_Gluing;
            dspD1000 = new DataSourcePointList();
            dspD1000.DataSource = SQL.Instance().dt_Speed_Gluing;
            dspD1100 = new DataSourcePointList();
            dspD1100.DataSource = SQL.Instance().dt_Speed_Gluing;
            dspD650.XDataMember = "Datetime";
            dspD650.YDataMember = "D650";
            dspD750.XDataMember = "Datetime";
            dspD750.YDataMember = "D750";
            dspD1000.XDataMember = "Datetime";
            dspD1000.YDataMember = "D1000";
            dspD1100.XDataMember = "Datetime";
            dspD1100.YDataMember = "D1100";
            GraphPane myPane = myZedGraph.GraphPane;
            myPane.CurveList[0].Points = dspD650;
            myPane.CurveList[1].Points = dspD750;
            myPane.CurveList[2].Points = dspD1000;
            myPane.CurveList[3].Points = dspD1100;
            myZedGraph.AxisChange();
            myZedGraph.Refresh();

            SQL.Instance().Query_Event("D650", startDate, DateTime.Now);
            dgvD650.ReadOnly = true;
            dgvD650.DataSource = SQL.Instance().dtD650_Event;
            SetDataGridViewStyle(dgvD650);

            SQL.Instance().Query_Event("D750", startDate, DateTime.Now);
            dgvD750.ReadOnly = true;
            dgvD750.DataSource = SQL.Instance().dtD750_Event;
            SetDataGridViewStyle(dgvD750);

            SQL.Instance().Query_Event("D1000", startDate, DateTime.Now);
            dgvD1000.ReadOnly = true;
            dgvD1000.DataSource = SQL.Instance().dtD1000_Event;
            SetDataGridViewStyle(dgvD1000);

            SQL.Instance().Query_Event("D1100", startDate, DateTime.Now);
            dgvD1100.ReadOnly = true;
            dgvD1100.DataSource = SQL.Instance().dtD1100_Event;
            SetDataGridViewStyle(dgvD1100);
        }

        private void btMonth_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);

            SQL.Instance().Quey_Chart_Gluing(startDate, DateTime.Now);
            dspD650 = new DataSourcePointList();
            dspD650.DataSource = SQL.Instance().dt_Speed_Gluing;
            dspD750 = new DataSourcePointList();
            dspD750.DataSource = SQL.Instance().dt_Speed_Gluing;
            dspD1000 = new DataSourcePointList();
            dspD1000.DataSource = SQL.Instance().dt_Speed_Gluing;
            dspD1100 = new DataSourcePointList();
            dspD1100.DataSource = SQL.Instance().dt_Speed_Gluing;
            dspD650.XDataMember = "Datetime";
            dspD650.YDataMember = "D650";
            dspD750.XDataMember = "Datetime";
            dspD750.YDataMember = "D750";
            dspD1000.XDataMember = "Datetime";
            dspD1000.YDataMember = "D1000";
            dspD1100.XDataMember = "Datetime";
            dspD1100.YDataMember = "D1100";
            GraphPane myPane = myZedGraph.GraphPane;
            myPane.CurveList[0].Points = dspD650;
            myPane.CurveList[1].Points = dspD750;
            myPane.CurveList[2].Points = dspD1000;
            myPane.CurveList[3].Points = dspD1100;
            myZedGraph.AxisChange();
            myZedGraph.Refresh();

            SQL.Instance().Query_Event("D650", startDate, DateTime.Now);
            dgvD650.ReadOnly = true;
            dgvD650.DataSource = SQL.Instance().dtD650_Event;
            SetDataGridViewStyle(dgvD650);

            SQL.Instance().Query_Event("D750", startDate, DateTime.Now);
            dgvD750.ReadOnly = true;
            dgvD750.DataSource = SQL.Instance().dtD750_Event;
            SetDataGridViewStyle(dgvD750);

            SQL.Instance().Query_Event("D1000", startDate, DateTime.Now);
            dgvD1000.ReadOnly = true;
            dgvD1000.DataSource = SQL.Instance().dtD1000_Event;
            SetDataGridViewStyle(dgvD1000);

            SQL.Instance().Query_Event("D1100", startDate, DateTime.Now);
            dgvD1100.ReadOnly = true;
            dgvD1100.DataSource = SQL.Instance().dtD1100_Event;
            SetDataGridViewStyle(dgvD1100);
        }

        private void btYear_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, 1, 1);

            SQL.Instance().Quey_Chart_Gluing(startDate, DateTime.Now);
            dspD650 = new DataSourcePointList();
            dspD650.DataSource = SQL.Instance().dt_Speed_Gluing;
            dspD750 = new DataSourcePointList();
            dspD750.DataSource = SQL.Instance().dt_Speed_Gluing;
            dspD1000 = new DataSourcePointList();
            dspD1000.DataSource = SQL.Instance().dt_Speed_Gluing;
            dspD1100 = new DataSourcePointList();
            dspD1100.DataSource = SQL.Instance().dt_Speed_Gluing;
            dspD650.XDataMember = "Datetime";
            dspD650.YDataMember = "D650";
            dspD750.XDataMember = "Datetime";
            dspD750.YDataMember = "D750";
            dspD1000.XDataMember = "Datetime";
            dspD1000.YDataMember = "D1000";
            dspD1100.XDataMember = "Datetime";
            dspD1100.YDataMember = "D1100";
            GraphPane myPane = myZedGraph.GraphPane;
            myPane.CurveList[0].Points = dspD650;
            myPane.CurveList[1].Points = dspD750;
            myPane.CurveList[2].Points = dspD1000;
            myPane.CurveList[3].Points = dspD1100;
            myZedGraph.AxisChange();
            myZedGraph.Refresh();

            SQL.Instance().Query_Event("D650", startDate, DateTime.Now);
            dgvD650.ReadOnly = true;
            dgvD650.DataSource = SQL.Instance().dtD650_Event;
            SetDataGridViewStyle(dgvD650);

            SQL.Instance().Query_Event("D750", startDate, DateTime.Now);
            dgvD750.ReadOnly = true;
            dgvD750.DataSource = SQL.Instance().dtD750_Event;
            SetDataGridViewStyle(dgvD750);

            SQL.Instance().Query_Event("D1000", startDate, DateTime.Now);
            dgvD1000.ReadOnly = true;
            dgvD1000.DataSource = SQL.Instance().dtD1000_Event;
            SetDataGridViewStyle(dgvD1000);

            SQL.Instance().Query_Event("D1100", startDate, DateTime.Now);
            dgvD1100.ReadOnly = true;
            dgvD1100.DataSource = SQL.Instance().dtD1100_Event;
            SetDataGridViewStyle(dgvD1100);
        }
    }
}
