using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupplyOfProducts.WF3._0
{

    public partial class FrmMain : Form
    {

        private Panel panel1;
        private Button button1;
        private Button button2;
        public FlowLayoutPanel panelSteps;

        public FrmMain()
        {
            InitializeComponent();

        }
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelSteps = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
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
            this.panelSteps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
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
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 22);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // FrmMain
            // 
            this.ClientSize = new System.Drawing.Size(961, 413);
            this.Controls.Add(this.button2);
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

        private async void Button1_Click_1(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                var _businessLogic = HI.GetInst().Get<IStep<IManagementModelRequest<IWorker>>>();
                var worker = new Worker();
                worker.Code = "W01" + DateTime.Now.Millisecond;
                worker.Name = worker.Code;
                var request = new ManagementModelRequest<IWorker>
                {
                    Item = worker,
                    Type = Operation.NEW
                };

                var result = _businessLogic.Execute(request);
                if (result.ComputeResult().IsOk())
                {
                    Console.WriteLine(result.Message());
                }
                else
                {
                    Console.WriteLine(result.Message());
                }
            });
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }
    }







}
