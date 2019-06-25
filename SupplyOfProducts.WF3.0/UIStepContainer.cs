using System.Windows.Forms;

namespace SupplyOfProducts.WF3._0
{
    public partial class UIStepContainer : UserControl
    {
        private Panel Background;
        private FlowLayoutPanel panel;

        public UIStepContainer()
        {
#if NETCOREAPP3_0
            HelperUI.ModifyMethod(this, () =>
            {
                InitializeComponent();
            });
#endif
        }

        public void Add(UIStepControl stp)
        {
#if NETCOREAPP3_0
            HelperUI.ModifyMethod(this, () =>
            {
                panel.Controls.Add(stp);
            });
#endif
        }

        private void InitializeComponent()
        {
            this.Background = new System.Windows.Forms.Panel();
            this.panel = new System.Windows.Forms.FlowLayoutPanel();
            this.Background.SuspendLayout();
            this.SuspendLayout();
            // 
            // Background
            // 
            this.Background.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Background.AutoSize = true;
            this.Background.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Background.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Background.Controls.Add(this.panel);
            this.Background.Location = new System.Drawing.Point(0, 0);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(500, 100);
            this.Background.TabIndex = 2;
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.AutoScrollMargin = new System.Drawing.Size(400, 100);
            this.panel.AutoSize = true;
            this.panel.BackColor = System.Drawing.SystemColors.Control;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.MaximumSize = new System.Drawing.Size(500, 0);
            this.panel.MinimumSize = new System.Drawing.Size(500, 100);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(500, 100);
            this.panel.TabIndex = 2;
            this.panel.SizeChanged += new System.EventHandler(this.Panel_SizeChanged);
            // 
            // UIStepContainer
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.Background);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UIStepContainer";
            this.Size = new System.Drawing.Size(500, 102);
            this.Background.ResumeLayout(false);
            this.Background.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            
        }

        private void Panel_SizeChanged(object sender, System.EventArgs e)
        {
            //this.Height = this.panel.Height + this.panel.Top + 10;
            //System.Console.WriteLine(this.Height);
        }
    }
}
