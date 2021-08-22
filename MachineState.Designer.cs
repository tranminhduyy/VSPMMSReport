
namespace VSPMMS_Chart
{
    partial class MachineState
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineState));
            this.panel6 = new System.Windows.Forms.Panel();
            this.btPrinting = new Bunifu.Framework.UI.BunifuTileButton();
            this.btBTD = new Bunifu.Framework.UI.BunifuTileButton();
            this.btGluing = new Bunifu.Framework.UI.BunifuTileButton();
            this.btGMCSCL = new Bunifu.Framework.UI.BunifuTileButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbDatetime = new System.Windows.Forms.Label();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.ucPrinting = new VSPMMS_Chart.ucPrinting();
            this.panel6.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.panel6.Controls.Add(this.btPrinting);
            this.panel6.Controls.Add(this.btBTD);
            this.panel6.Controls.Add(this.btGluing);
            this.panel6.Controls.Add(this.btGMCSCL);
            this.panel6.Location = new System.Drawing.Point(0, 94);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(99, 879);
            this.panel6.TabIndex = 3;
            // 
            // btPrinting
            // 
            this.btPrinting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btPrinting.color = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btPrinting.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btPrinting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btPrinting.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btPrinting.ForeColor = System.Drawing.Color.White;
            this.btPrinting.Image = ((System.Drawing.Image)(resources.GetObject("btPrinting.Image")));
            this.btPrinting.ImagePosition = 26;
            this.btPrinting.ImageZoom = 30;
            this.btPrinting.LabelPosition = 35;
            this.btPrinting.LabelText = "Printing";
            this.btPrinting.Location = new System.Drawing.Point(0, 0);
            this.btPrinting.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btPrinting.Name = "btPrinting";
            this.btPrinting.Size = new System.Drawing.Size(99, 98);
            this.btPrinting.TabIndex = 13;
            this.btPrinting.Click += new System.EventHandler(this.btPrinting_Click);
            // 
            // btBTD
            // 
            this.btBTD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btBTD.color = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btBTD.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btBTD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btBTD.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btBTD.ForeColor = System.Drawing.Color.White;
            this.btBTD.Image = ((System.Drawing.Image)(resources.GetObject("btBTD.Image")));
            this.btBTD.ImagePosition = 26;
            this.btBTD.ImageZoom = 30;
            this.btBTD.LabelPosition = 35;
            this.btBTD.LabelText = "BTD";
            this.btBTD.Location = new System.Drawing.Point(0, 98);
            this.btBTD.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btBTD.Name = "btBTD";
            this.btBTD.Size = new System.Drawing.Size(99, 98);
            this.btBTD.TabIndex = 10;
            this.btBTD.Click += new System.EventHandler(this.btBTD_Click);
            // 
            // btGluing
            // 
            this.btGluing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btGluing.color = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btGluing.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btGluing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btGluing.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btGluing.ForeColor = System.Drawing.Color.White;
            this.btGluing.Image = ((System.Drawing.Image)(resources.GetObject("btGluing.Image")));
            this.btGluing.ImagePosition = 26;
            this.btGluing.ImageZoom = 30;
            this.btGluing.LabelPosition = 35;
            this.btGluing.LabelText = "Gluing";
            this.btGluing.Location = new System.Drawing.Point(0, 196);
            this.btGluing.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btGluing.Name = "btGluing";
            this.btGluing.Size = new System.Drawing.Size(99, 98);
            this.btGluing.TabIndex = 12;
            this.btGluing.Click += new System.EventHandler(this.btGluing_Click);
            // 
            // btGMCSCL
            // 
            this.btGMCSCL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btGMCSCL.color = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btGMCSCL.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btGMCSCL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btGMCSCL.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btGMCSCL.ForeColor = System.Drawing.Color.White;
            this.btGMCSCL.Image = ((System.Drawing.Image)(resources.GetObject("btGMCSCL.Image")));
            this.btGMCSCL.ImagePosition = 26;
            this.btGMCSCL.ImageZoom = 30;
            this.btGMCSCL.LabelPosition = 35;
            this.btGMCSCL.LabelText = "GMC SCL";
            this.btGMCSCL.Location = new System.Drawing.Point(0, 294);
            this.btGMCSCL.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btGMCSCL.Name = "btGMCSCL";
            this.btGMCSCL.Size = new System.Drawing.Size(99, 98);
            this.btGMCSCL.TabIndex = 11;
            this.btGMCSCL.Click += new System.EventHandler(this.btGMCSCL_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 16F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(302, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Visingpack - Packaging Industries Ltd";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 28F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(299, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 46);
            this.label2.TabIndex = 0;
            this.label2.Text = "Machine State";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Controls.Add(this.pictureBox4);
            this.panelHeader.Controls.Add(this.label2);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Location = new System.Drawing.Point(0, -3);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1923, 98);
            this.panelHeader.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(284, 75);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(1599, 13);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(284, 75);
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.panel1.Controls.Add(this.lbDatetime);
            this.panel1.Location = new System.Drawing.Point(0, 971);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1923, 51);
            this.panel1.TabIndex = 11;
            // 
            // lbDatetime
            // 
            this.lbDatetime.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold);
            this.lbDatetime.ForeColor = System.Drawing.Color.White;
            this.lbDatetime.Location = new System.Drawing.Point(1442, 3);
            this.lbDatetime.Name = "lbDatetime";
            this.lbDatetime.Size = new System.Drawing.Size(459, 46);
            this.lbDatetime.TabIndex = 11;
            this.lbDatetime.Text = "15/01/2021 5:2:3 am";
            this.lbDatetime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timerMain
            // 
            this.timerMain.Interval = 1000;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // ucPrinting
            // 
            this.ucPrinting.AutoScroll = true;
            this.ucPrinting.AutoSize = true;
            this.ucPrinting.BackColor = System.Drawing.Color.White;
            this.ucPrinting.Location = new System.Drawing.Point(105, 101);
            this.ucPrinting.Name = "ucPrinting";
            this.ucPrinting.Size = new System.Drawing.Size(1793, 820);
            this.ucPrinting.TabIndex = 12;
            // 
            // MachineState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 843);
            this.Controls.Add(this.ucPrinting);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "MachineState";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MachineState";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MachineState_Load);
            this.panel6.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuTileButton btPrinting;
        private Bunifu.Framework.UI.BunifuTileButton btBTD;
        private Bunifu.Framework.UI.BunifuTileButton btGluing;
        private Bunifu.Framework.UI.BunifuTileButton btGMCSCL;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbDatetime;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ucPrinting ucPrinting;
    }
}