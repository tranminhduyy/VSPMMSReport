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
    public partial class MachineState : Form
    {
        public MachineState()
        {
            InitializeComponent();
        }

        private void MachineState_Load(object sender, EventArgs e)
        {
            ucPrinting.BringToFront();
            timerMain.Enabled = true;
            timerMain.Start();
        }

        private void btPrinting_Click(object sender, EventArgs e)
        {
            btPrinting.BackColor = Color.Black;
            btPrinting.color = Color.Black;
            btPrinting.colorActive = Color.FromArgb(33,33,33);

            btBTD.BackColor = Color.FromArgb(69, 69, 69);
            btBTD.color = Color.FromArgb(69, 69, 69);
            btBTD.colorActive = Color.FromArgb(33, 33, 33);

            btGluing.BackColor = Color.FromArgb(69, 69, 69);
            btGluing.color = Color.FromArgb(69, 69, 69);
            btGluing.colorActive = Color.FromArgb(33, 33, 33);

            btGMCSCL.BackColor = Color.FromArgb(69, 69, 69);
            btGMCSCL.color = Color.FromArgb(69, 69, 69);
            btGMCSCL.colorActive = Color.FromArgb(33, 33, 33);

            ucPrinting.BringToFront();
        }

        private void btBTD_Click(object sender, EventArgs e)
        {
            btPrinting.BackColor = Color.FromArgb(69, 69, 69);
            btPrinting.color = Color.FromArgb(69, 69, 69);
            btPrinting.colorActive = Color.FromArgb(33, 33, 33);

            btBTD.BackColor = Color.Black;
            btBTD.color = Color.Black;
            btBTD.colorActive = Color.FromArgb(33, 33, 33);

            btGluing.BackColor = Color.FromArgb(69, 69, 69);
            btGluing.color = Color.FromArgb(69, 69, 69);
            btGluing.colorActive = Color.FromArgb(33, 33, 33);

            btGMCSCL.BackColor = Color.FromArgb(69, 69, 69);
            btGMCSCL.color = Color.FromArgb(69, 69, 69);
            btGMCSCL.colorActive = Color.FromArgb(33, 33, 33);

            //ucBTD.BringToFront();
        }

        private void btGluing_Click(object sender, EventArgs e)
        {
            btPrinting.BackColor = Color.FromArgb(69, 69, 69);
            btPrinting.color = Color.FromArgb(69, 69, 69);
            btPrinting.colorActive = Color.FromArgb(33, 33, 33);

            btBTD.BackColor = Color.FromArgb(69, 69, 69);
            btBTD.color = Color.FromArgb(69, 69, 69);
            btBTD.colorActive = Color.FromArgb(33, 33, 33);

            btGluing.BackColor = Color.Black;
            btGluing.color = Color.Black;
            btGluing.colorActive = Color.FromArgb(33, 33, 33);

            btGMCSCL.BackColor = Color.FromArgb(69, 69, 69);
            btGMCSCL.color = Color.FromArgb(69, 69, 69);
            btGMCSCL.colorActive = Color.FromArgb(33, 33, 33);

            //ucGluing.BringToFront();
        }

        private void btGMCSCL_Click(object sender, EventArgs e)
        {
            btPrinting.BackColor = Color.FromArgb(69, 69, 69);
            btPrinting.color = Color.FromArgb(69, 69, 69);
            btPrinting.colorActive = Color.FromArgb(33, 33, 33);

            btBTD.BackColor = Color.FromArgb(69, 69, 69);
            btBTD.color = Color.FromArgb(69, 69, 69);
            btBTD.colorActive = Color.FromArgb(33, 33, 33);

            btGluing.BackColor = Color.FromArgb(69, 69, 69);
            btGluing.color = Color.FromArgb(69, 69, 69);
            btGluing.colorActive = Color.FromArgb(33, 33, 33);

            btGMCSCL.BackColor = Color.Black;
            btGMCSCL.color = Color.Black;
            btGMCSCL.colorActive = Color.FromArgb(33, 33, 33);

            //ucGMC_SCL.BringToFront();
        }

        DateTime dt;
        private void timerMain_Tick(object sender, EventArgs e)
        {
            dt = DateTime.Now;
            lbDatetime.Text = dt.ToString();
        }
    }
}
