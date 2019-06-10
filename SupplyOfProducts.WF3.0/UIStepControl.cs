using System;
using System.Windows.Forms;

namespace SupplyOfProducts.WF3._0
{
    public partial class UIStepControl : UserControl
    {
        private Label label1;
        private FlowLayoutPanel panel;

        public UIStepControl()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        public void SetValues(EnumEventStepObserver state, string desc = null)
        {
            //if (state == EnumEventStepObserver.START)
            //{
            //    this.picture.Image = this.picture.Image = global::Job.Properties.Resources.red;
            //}
            //else if (state == EnumEventStepObserver.END)
            //{
            //    this.picture.Image = this.picture.Image = global::Job.Properties.Resources.green;
            //}
           
            //this.lblDesc.Text = (desc);
        }

        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BackColor = System.Drawing.Color.LightGray;
            this.panel.Controls.Add(this.label1);
            this.panel.Location = new System.Drawing.Point(14, 17);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(283, 140);
            this.panel.TabIndex = 1;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // UIStepControl
            // 
            this.Controls.Add(this.panel);
            this.Name = "UIStepControl";
            this.Size = new System.Drawing.Size(333, 173);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
