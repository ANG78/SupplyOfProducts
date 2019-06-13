using System.Windows.Forms;

namespace SupplyOfProducts.WF3._0
{
    public partial class UIStepContainer : UserControl
    {
        public UIStepContainer()
        {
            HelperUI.ModifyMethod(this, () =>
            {
                InitializeComponent();
            });
        }

        private FlowLayoutPanel panel;

        public void Add(UIStepControl stp)
        {
            HelperUI.ModifyMethod(this, () =>
            {
                panel.Controls.Add(stp);
            });
        }

        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.AutoScroll = true;
            this.panel.AutoSize = true;
            this.panel.BackColor = System.Drawing.Color.DarkGray;
            this.panel.Location = new System.Drawing.Point(9, 7);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(814, 24);
            this.panel.TabIndex = 1;
            // 
            // UIStepContainer
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.panel);
            this.Name = "UIStepContainer";
            this.Size = new System.Drawing.Size(836, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}
