
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupplyOfProducts.WF3._0
{

    public delegate void NewContainerEvent();
    
    public partial class FrmMain : Form
    {

        private Panel panel1;
        private Button button1;
        private Button bttExecute;
        public FlowLayoutPanel panelSteps;
        private ComboBox cmbNumber;
        public NewContainerEvent CreateNewHandler;
        public NewContainerEvent ExecuteHandler;
        public IList<StepContainerObserver> ListObservers = new List<StepContainerObserver>();

        public FrmMain()
        {
            InitializeComponent();
            cmbNumber.Items.Add(1);
            cmbNumber.Items.Add(2);
            cmbNumber.Items.Add(3);
            cmbNumber.Items.Add(4);
            cmbNumber.SelectedIndex = 0;
        }
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelSteps = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.bttExecute = new System.Windows.Forms.Button();
            this.cmbNumber = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.panel1.Controls.Add(this.panelSteps);
            this.panel1.Location = new System.Drawing.Point(76, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 363);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // panelSteps
            // 
            this.panelSteps.AutoSize = true;
            this.panelSteps.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelSteps.BackColor = System.Drawing.Color.LightGray;
            this.panelSteps.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelSteps.Location = new System.Drawing.Point(12, 7);
            this.panelSteps.Name = "panelSteps";
            this.panelSteps.Size = new System.Drawing.Size(0, 0);
            this.panelSteps.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "New";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // bttExecute
            // 
            this.bttExecute.Location = new System.Drawing.Point(12, 103);
            this.bttExecute.Name = "bttExecute";
            this.bttExecute.Size = new System.Drawing.Size(49, 22);
            this.bttExecute.TabIndex = 4;
            this.bttExecute.Text = "Run";
            this.bttExecute.UseVisualStyleBackColor = true;
            this.bttExecute.Click += new System.EventHandler(this.Button2_Click);
            // 
            // cmbNumber
            // 
            this.cmbNumber.FormattingEnabled = true;
            this.cmbNumber.Location = new System.Drawing.Point(12, 59);
            this.cmbNumber.Name = "cmbNumber";
            this.cmbNumber.Size = new System.Drawing.Size(46, 21);
            this.cmbNumber.TabIndex = 5;
            // 
            // FrmMain
            // 
            this.ClientSize = new System.Drawing.Size(961, 413);
            this.Controls.Add(this.cmbNumber);
            this.Controls.Add(this.bttExecute);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMain";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i <= cmbNumber.SelectedIndex; i++)
            {
                CreateNewHandler?.Invoke();
            }
            
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            ExecuteHandler?.Invoke();

        }
    }







}
