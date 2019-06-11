using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace SupplyOfProducts.WF3._0
{



    public partial class FrmMain : Form//, IObserverEvent<SettlementSchedule>
    {
        public static System.Threading.SynchronizationContext SynchronizationContext { get; private set; }

        private Panel panel1;
        private Button button1;
        private Button button2;
        public FlowLayoutPanel panelSteps;

        public FrmMain()
        {
            InitializeComponent();

        }


        

        private void button1_Click(object sender, EventArgs e)
        {

            //ThreadPool.QueueUserWorkItem((state) =>
            //{
            //    LateRIManager lateri = new LateRIManager();
            //    lateri.Execute();
            //});

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //ThreadPool.QueueUserWorkItem((state) =>
            //{
            //    LateRIManager lateri = new LateRIManager();
            //    var rq = new RequestLateRI(new SettlementSchedule());
            //    var res = lateri.Execute(rq);
            //    if (res.IsOk())
            //    {
            //        clear(rq);
            //    }
            //});
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

        private void Button1_Click_1(object sender, EventArgs e)
        {
            var cont = new UIStepContainer();
            panelSteps.Controls.Add ( cont);
            cont.Update(new dd(),new ff(),EnumEventStepObserver.START);
            cont.Update(new dd(), new ff(), EnumEventStepObserver.START);
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }
    }


    public class ff : IProcessStep<SettlementSchedule>
    {
        public string Desc { get { return "hola"; } }

        public IProcessStep<SettlementSchedule> Next { get; set; }
    }

    public class dd : IRequest<SettlementSchedule>
    {
        public long IdRequest { get { return 1; } }

        public SettlementSchedule Item { get { return new SettlementSchedule(); } }
    }

    public enum EnumEventStepObserver
    {
        START,
        END
    }

    public interface IRequest<T>
    {
        long IdRequest { get; }
        T Item { get; }
    }

    public interface IProcessStep<T>
    {
        string Desc { get; }
        IProcessStep<T> Next { get; set; }
        // IResult Process(IRequest<T> p);
    }

    public interface IObserverEvent<T>
    {
        void Update(IRequest<T> item, IProcessStep<T> sender, EnumEventStepObserver eventStep);
    }

    public class SettlementSchedule
    { }


    public class Observer : IObserverEvent<SettlementSchedule>
    {
        FrmMain Form ;
        public Observer(FrmMain form)
        {
            Form = form;
        }

        Dictionary<IRequest<SettlementSchedule>, UIStepContainer> containers = new Dictionary<IRequest<SettlementSchedule>, UIStepContainer>();

        public void Clear(IRequest<SettlementSchedule> rq)
        {
            try
            {
                FrmMain.SynchronizationContext.Post((state) =>
                {
                    if (!Form.IsDisposed)
                    {
                        if (containers.ContainsKey(rq))
                        {
                            var cont = containers[rq];
                            Form.panelSteps.Controls.Remove(cont);
                        }
                    }

                }, null);

            }
            catch (Exception ex)
            {
                FrmMain.SynchronizationContext.Post((state) =>
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    , null);
            }

        }


        public void Update(IRequest<SettlementSchedule> item, IProcessStep<SettlementSchedule> sender, EnumEventStepObserver eventStep)
        {

            try
            {
                FrmMain.SynchronizationContext.Post((state) =>
                {
                    if (!Form.IsDisposed)
                    {
                        UIStepContainer container = null;
                        if (!containers.ContainsKey(item))
                        {
                            container = new UIStepContainer();
                            containers[item] = container;
                            Form.panelSteps.Controls.Add(container);
                        }
                        else
                        {
                            container = containers[item];
                        }

                        container.Update(item, sender, eventStep);

                    }
                }, null);
            }
            catch (Exception ex)
            {
                FrmMain.SynchronizationContext.Post((state) =>
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    , null);
            }

        }

    }



    public interface IListenerEvents<T>
    {
        void Start(IProcessStep<T> sender, IRequest<T> item);
        void End(IProcessStep<T> sender, IRequest<T> item);

        void Register(IObserverEvent<T> o);
        void Unregister(IObserverEvent<T> o);
    }

}
