using System;
#if NETCOREAPP3_0 
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using SupplyOfProducts.Api.Controllers.ViewModels;
#endif
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;


namespace SupplyOfProducts.WF3._0
{


    public partial class UIStepGenerator : UserControl
    {
        private Button bttGenerate;
        private Panel panel2;
        private Panel panel1;
        private ComboBox cmbType;
        private RichTextBox richTextBox1;
        private Splitter splitter1;
        private Panel panelRight;
        private UIStepContainer uiStepContainer1;
        private Button bttExecute;
        private ImageList imageList1;
        private IContainer components;
        private Panel panel3;
        private PictureBox pictureBox1;
        private CheckBox chkJustIcons;
        private Button bttDelete;

#if NETCOREAPP3_0
        public StepContainerObserver StepObserver { get; set; }
        public HelperRun Executor { get; set; }
#endif
        public UIStepGenerator()
        {
            InitializeComponent();
#if NETCOREAPP3_0
            Refresh(EStatus.Initial);
            var values = Enum.GetValues(typeof(EType));
            foreach( var x in values)
            {
                cmbType.Items.Add(x);
            }
            
            
#endif
        }


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bttGenerate = new System.Windows.Forms.Button();
            this.bttDelete = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkJustIcons = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bttExecute = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelRight = new System.Windows.Forms.Panel();
            this.uiStepContainer1 = new SupplyOfProducts.WF3._0.UIStepContainer();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // bttGenerate
            // 
            this.bttGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttGenerate.Location = new System.Drawing.Point(208, 15);
            this.bttGenerate.Name = "bttGenerate";
            this.bttGenerate.Size = new System.Drawing.Size(59, 21);
            this.bttGenerate.TabIndex = 0;
            this.bttGenerate.Text = "Generate";
            this.bttGenerate.UseVisualStyleBackColor = true;
            this.bttGenerate.Click += new System.EventHandler(this.BttGenerate_Click);
            // 
            // bttDelete
            // 
            this.bttDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttDelete.Location = new System.Drawing.Point(208, 60);
            this.bttDelete.Name = "bttDelete";
            this.bttDelete.Size = new System.Drawing.Size(59, 22);
            this.bttDelete.TabIndex = 1;
            this.bttDelete.Text = "Delete";
            this.bttDelete.UseVisualStyleBackColor = true;
            this.bttDelete.Click += new System.EventHandler(this.BttDelete_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.bttExecute);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.bttDelete);
            this.panel2.Controls.Add(this.bttGenerate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 174);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.chkJustIcons);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(206, 88);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(60, 70);
            this.panel3.TabIndex = 8;
            // 
            // chkJustIcons
            // 
            this.chkJustIcons.AutoSize = true;
            this.chkJustIcons.Checked = true;
            this.chkJustIcons.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkJustIcons.Location = new System.Drawing.Point(8, 38);
            this.chkJustIcons.Name = "chkJustIcons";
            this.chkJustIcons.Size = new System.Drawing.Size(52, 17);
            this.chkJustIcons.TabIndex = 9;
            this.chkJustIcons.Text = "Icons";
            this.chkJustIcons.UseVisualStyleBackColor = true;
            this.chkJustIcons.CheckedChanged += new System.EventHandler(this.ChkJustIcons_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(21, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 22);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // bttExecute
            // 
            this.bttExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttExecute.Location = new System.Drawing.Point(208, 36);
            this.bttExecute.Name = "bttExecute";
            this.bttExecute.Size = new System.Drawing.Size(59, 21);
            this.bttExecute.TabIndex = 6;
            this.bttExecute.Text = "Execute";
            this.bttExecute.UseVisualStyleBackColor = true;
            this.bttExecute.Click += new System.EventHandler(this.BttExecute_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cmbType);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Location = new System.Drawing.Point(15, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 148);
            this.panel1.TabIndex = 5;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cmbType.Location = new System.Drawing.Point(8, 6);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(148, 21);
            this.cmbType.TabIndex = 4;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.CmbType_SelectedIndexChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(8, 34);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(166, 107);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitter1.Location = new System.Drawing.Point(270, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 174);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // panelRight
            // 
            this.panelRight.AutoSize = true;
            this.panelRight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelRight.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panelRight.Controls.Add(this.uiStepContainer1);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(280, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(620, 174);
            this.panelRight.TabIndex = 8;
            this.panelRight.ClientSizeChanged += new System.EventHandler(this.PanelRight_ClientSizeChanged);
            // 
            // uiStepContainer1
            // 
            this.uiStepContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiStepContainer1.AutoSize = true;
            this.uiStepContainer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uiStepContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uiStepContainer1.Location = new System.Drawing.Point(10, 11);
            this.uiStepContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.uiStepContainer1.MinimumSize = new System.Drawing.Size(600, 150);
            this.uiStepContainer1.Name = "uiStepContainer1";
            this.uiStepContainer1.Size = new System.Drawing.Size(600, 150);
            this.uiStepContainer1.TabIndex = 8;
            this.uiStepContainer1.AutoSizeChanged += new System.EventHandler(this.UiStepContainer1_AutoSizeChanged);
            this.uiStepContainer1.SizeChanged += new System.EventHandler(this.UiStepContainer1_SizeChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // UIStepGenerator
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Name = "UIStepGenerator";
            this.Size = new System.Drawing.Size(900, 174);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void BttDelete_Click(object sender, EventArgs e)
        {
            this.Refresh(EStatus.Initial);
            Parent.Controls.Remove(this);
        }


        public void Add(UIStepControl stp)
        {
#if NETCOREAPP3_0
            HelperUI.ModifyMethod(this, () =>
            {
                uiStepContainer1.Add(stp);
            });
#endif
        }

        public enum EStatus
        {
            Initial,
            Generating,
            Running,
            Finishing
        }

        EStatus CurrentStatus = EStatus.Generating;

        public void Refresh(EStatus param1)
        {

            CurrentStatus = param1;
#if NETCOREAPP3_0
            HelperUI.ModifyMethod(bttGenerate, () =>
            {

                    this.bttGenerate.Enabled = CurrentStatus == EStatus.Initial || 
                                                CurrentStatus == EStatus.Generating;
                    this.bttExecute.Enabled = CurrentStatus == EStatus.Generating && Executor != null;
                    this.bttDelete.Enabled = CurrentStatus == EStatus.Initial || 
                                                CurrentStatus == EStatus.Generating ||
                                                CurrentStatus == EStatus.Finishing;
                    this.cmbType.Enabled = (CurrentStatus == EStatus.Initial || 
                                            CurrentStatus == EStatus.Generating);
            });
#endif
        }

        private async void BttGenerate_Click(object sender, EventArgs e)
        {
#if NETCOREAPP3_0

            this.Refresh(EStatus.Generating);
            
            string jsonInTextbox = HelperUI.GetMethod<string>(richTextBox1, () =>
            {
                return richTextBox1.Text;
            });


            if ( Executor != null )
              return;

            object type = HelperUI.GetMethod(cmbType, () =>
            {

                if (cmbType.SelectedItem is EType)
                {
                    return cmbType.SelectedItem;
                }
                return null;
            });

            if (string.IsNullOrWhiteSpace(jsonInTextbox) || type == null)
            {
                HelperUI.ModifyMethod(bttGenerate, () =>
                {
                    bttGenerate.Enabled = Executor != null;
                });

                return;
            }

#endif
            await Task.Run(() =>
            {

#if NETCOREAPP3_0

                EType typeEnum = (EType)type;
                if (typeEnum == EType.ConfigSupplyViewModel)
                {
                    GenerateAux<IConfigSupply, ConfigSupplyViewModel>(jsonInTextbox);
                }
                else if (typeEnum == EType.WorkerViewModel)
                {
                    GenerateAux<IWorker, WorkerViewModel>(jsonInTextbox);
                }
                else if (typeEnum == EType.ProductViewModel)
                {
                    GenerateAux<IProduct, ProductViewModel>(jsonInTextbox);
                }
                else if (typeEnum == EType.ProductComplexViewModel)
                {
                    GenerateAux<IProduct, ProductComplexViewModel>(jsonInTextbox);
                }

#endif
            });

        }

        private bool GenerateAux<TIModel, TViewModel>(string jsonInTextbox)
        {
#if NETCOREAPP3_0
            FactoryHelperRun factory = new FactoryHelperRun();
            var pExecutor = factory.GetExecutor<TIModel, TViewModel>(EType.ConfigSupplyViewModel, jsonInTextbox, Operation.NEW);
            if (pExecutor == null)
            {
                return false;
            }
            StepObserver.RegisterSteps(pExecutor.BusinessLogic, pExecutor.Request);
            Executor = pExecutor;
#endif
            return true;
        }

        private void UiStepContainer1_AutoSizeChanged(object sender, EventArgs e)
        {

        }

        private void PanelRight_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void UiStepContainer1_SizeChanged(object sender, EventArgs e)
        {
            this.Height = this.uiStepContainer1.Height + this.uiStepContainer1.Top + 10;
        }

        private async void BttExecute_Click(object sender, EventArgs e)
        {
            this.Refresh(EStatus.Running);
            //StepObserver.RegisterSteps

            await Task.Run(() =>
            {
#if NETCOREAPP3_0
                var result =  Executor?.Run();
                this.Refresh(EStatus.Finishing);
                if (result == null)
                    return;

                HelperUI.ModifyMethod(cmbType, () => {
                    
                    if  ( result.ComputeResult().IsOk() )
                    {
                         pictureBox1.BackColor = Color.Green;
                  
                    }
                    else if  ( result.ComputeResult().IsWarning() )
                    {
                         pictureBox1.BackColor = Color.Orange;
                  
                    }
                    else if  ( result.ComputeResult().IsError() )
                    {
                        pictureBox1.BackColor = Color.Red;
                  
                    }
                });
#endif
            });


        }

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {

#if NETCOREAPP3_0
            object var = cmbType.SelectedItem;
            if (var is EType)
            {
                string aux = ((EType)var).GetTemplateString();
                richTextBox1.Text = aux;
            }
#endif
        }

        private void ChkJustIcons_CheckedChanged(object sender, EventArgs e)
        {
#if NETCOREAPP3_0
            StepObserver.ResizeToJustIcon();
#endif
        }
    }
}
