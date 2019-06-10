using System.Collections.Generic;
using System.Windows.Forms;

namespace SupplyOfProducts.WF3._0
{
    public partial class UIStepContainer : UserControl, IObserverEvent<SettlementSchedule>
    {
        public UIStepContainer()
        {
            InitializeComponent();
        }

        private FlowLayoutPanel panel;
        Dictionary<IProcessStep<SettlementSchedule>, UIStepControl> controls = new Dictionary<IProcessStep<SettlementSchedule>, UIStepControl>();
       

        public void Update(IRequest<SettlementSchedule> item, IProcessStep<SettlementSchedule> sender, EnumEventStepObserver eventStep)
        {
            UIStepControl control = null;
            if (!controls.ContainsKey(sender))
            {
                control = new UIStepControl();
                controls[sender] = control;
                panel.Controls.Add(control);
            }
            else
            {
                control = controls[sender];
            }

            control.SetValues(eventStep, sender.Desc + ":" +  item.IdRequest + " " + eventStep);
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
            this.panel.BackColor = System.Drawing.Color.DarkGray;
            this.panel.Location = new System.Drawing.Point(9, 7);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(814, 150);
            this.panel.TabIndex = 1;
            // 
            // UIStepContainer
            // 
            this.Controls.Add(this.panel);
            this.Name = "UIStepContainer";
            this.Size = new System.Drawing.Size(836, 166);
            this.ResumeLayout(false);

        }

     
    }
}
