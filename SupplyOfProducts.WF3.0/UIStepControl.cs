
#if NETCOREAPP3_0
using SupplyOfProducts.Interfaces.BusinessLogic;
#endif

using System;
using System.Windows.Forms;

namespace SupplyOfProducts.WF3._0
{
    public enum EIcons
    {
        INITIAL,
        START,
        END_OK,
        END_WARNINGS,
        END_ERRORS

    }
    public partial class UIStepControl : UserControl
    {
        private ImageList imageList1;
        private Panel panel1;
        private RichTextBox before;
        private RichTextBox after;
        private TextBox lblDesc;
        private Panel panel3;
        private Label lblFinish;
        private Panel panel2;
        private Label lblStart;
        private Panel PBack;
        private PictureBox picture;
        private Button bttDown;
        private Button bttUp;
        private System.ComponentModel.IContainer components;

        public UIStepControl()
        {
#if NETCOREAPP3_0
            HelperUI.ModifyMethod(this, () =>
            {
                InitializeComponent();
                RefreshMode();
                picture.Image = this.imageList1.Images[(int)EIcons.INITIAL];
                PBack.BackColor = System.Drawing.Color.LightGray;
            });
#endif
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void SetValueStart(string item)
        {
#if NETCOREAPP3_0
            HelperUI.ModifyMethod(this, () =>
             {
                 //this.picture.Image = this.imageList1.Images[(int)EIcons.START];
                 PBack.BackColor = System.Drawing.Color.Gray;
                 this.before.Text = item;
                 this.lblStart.Text = "Started: " + DateTime.Now;
             });
#endif
        }

        public void SetValueInitial(string desc)
        {
#if NETCOREAPP3_0
            HelperUI.ModifyMethod(this, () =>
             {
                this.lblDesc.Text = (desc);
             });
#endif
        }

        public void SetValueFinish(string item, bool isOk, bool isWarning, string message)
        {

#if NETCOREAPP3_0
            HelperUI.ModifyMethod(this, () =>
            {
                if (isOk)
                {
                    //picture.Image = this.imageList1.Images[(int)EIcons.END_OK];
                    this.after.Text = item;
                    PBack.BackColor = System.Drawing.Color.Green;
                }
                else if (isWarning)
                {
                    //this.picture.Image = this.imageList1.Images[(int)EIcons.END_WARNINGS];
                    this.after.Text = item;
                    PBack.BackColor = System.Drawing.Color.Orange;
                }
                else
                {
                    //this.picture.Image = this.imageList1.Images[(int)EIcons.END_ERRORS];
                    this.after.Text = message;
                    PBack.BackColor = System.Drawing.Color.Red;
                }
                this.lblFinish.Text = "Finished: " + DateTime.Now;
            });
#endif
        }


        public void SetValueException(string item, string desc)
        {
#if NETCOREAPP3_0
            HelperUI.ModifyMethod(this, () =>
            {
                //this.picture.Image = this.imageList1.Images[(int)EIcons.END_ERRORS];
                PBack.BackColor = System.Drawing.Color.Red;
                this.after.Text = item;
                this.lblFinish.Text = "Finished with Exceptions: " + DateTime.Now;
            });
#endif
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIStepControl));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.PBack = new System.Windows.Forms.Panel();
            this.picture = new System.Windows.Forms.PictureBox();
            this.bttDown = new System.Windows.Forms.Button();
            this.bttUp = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblFinish = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.TextBox();
            this.before = new System.Windows.Forms.RichTextBox();
            this.after = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.PBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "STEP.png");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.PBack);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblDesc);
            this.panel1.Controls.Add(this.before);
            this.panel1.Controls.Add(this.after);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 236);
            this.panel1.TabIndex = 2;
            this.panel1.Click += new System.EventHandler(this.Panel1_Click);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // PBack
            // 
            this.PBack.Controls.Add(this.picture);
            this.PBack.Controls.Add(this.bttDown);
            this.PBack.Controls.Add(this.bttUp);
            this.PBack.Location = new System.Drawing.Point(4, 4);
            this.PBack.Name = "PBack";
            this.PBack.Size = new System.Drawing.Size(60, 33);
            this.PBack.TabIndex = 13;
            // 
            // picture
            // 
            this.picture.Location = new System.Drawing.Point(2, 1);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(30, 30);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picture.TabIndex = 15;
            this.picture.TabStop = false;
            this.picture.Click += new System.EventHandler(this.Picture_Click_1);
            // 
            // bttDown
            // 
            this.bttDown.BackColor = System.Drawing.Color.Black;
            this.bttDown.Location = new System.Drawing.Point(35, 18);
            this.bttDown.Name = "bttDown";
            this.bttDown.Size = new System.Drawing.Size(20, 12);
            this.bttDown.TabIndex = 14;
            this.bttDown.UseVisualStyleBackColor = false;
            this.bttDown.Click += new System.EventHandler(this.BttDown_Click_1);
            // 
            // bttUp
            // 
            this.bttUp.BackColor = System.Drawing.Color.Black;
            this.bttUp.Location = new System.Drawing.Point(35, 3);
            this.bttUp.Name = "bttUp";
            this.bttUp.Size = new System.Drawing.Size(20, 12);
            this.bttUp.TabIndex = 13;
            this.bttUp.UseVisualStyleBackColor = false;
            this.bttUp.Click += new System.EventHandler(this.BttUp_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.SkyBlue;
            this.panel3.Controls.Add(this.lblFinish);
            this.panel3.Location = new System.Drawing.Point(6, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(358, 24);
            this.panel3.TabIndex = 10;
            // 
            // lblFinish
            // 
            this.lblFinish.AutoSize = true;
            this.lblFinish.Location = new System.Drawing.Point(3, 5);
            this.lblFinish.Name = "lblFinish";
            this.lblFinish.Size = new System.Drawing.Size(49, 13);
            this.lblFinish.TabIndex = 9;
            this.lblFinish.Text = "Finished:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Khaki;
            this.panel2.Controls.Add(this.lblStart);
            this.panel2.Location = new System.Drawing.Point(6, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(358, 24);
            this.panel2.TabIndex = 9;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(3, 5);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(44, 13);
            this.lblStart.TabIndex = 8;
            this.lblStart.Text = "Started:";
            // 
            // lblDesc
            // 
            this.lblDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.lblDesc.Location = new System.Drawing.Point(71, 10);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.ReadOnly = true;
            this.lblDesc.Size = new System.Drawing.Size(292, 20);
            this.lblDesc.TabIndex = 6;
            // 
            // before
            // 
            this.before.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.before.Location = new System.Drawing.Point(3, 95);
            this.before.Name = "before";
            this.before.ReadOnly = true;
            this.before.Size = new System.Drawing.Size(180, 129);
            this.before.TabIndex = 5;
            this.before.Text = "";
            // 
            // after
            // 
            this.after.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.after.Location = new System.Drawing.Point(188, 95);
            this.after.Name = "after";
            this.after.ReadOnly = true;
            this.after.Size = new System.Drawing.Size(177, 129);
            this.after.TabIndex = 4;
            this.after.Text = "";
            // 
            // UIStepControl
            // 
            this.Controls.Add(this.panel1);
            this.Name = "UIStepControl";
            this.Size = new System.Drawing.Size(384, 253);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PBack.ResumeLayout(false);
            this.PBack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void Panel1_Click(object sender, EventArgs e)
        {

        }

        enum EDisplayMode
        {
            JUST_ICON,
            RESUME,
            EXPANDED
        }
        EDisplayMode isMin = EDisplayMode.RESUME;

        private void RefreshMode()
        {
            if (isMin == EDisplayMode.JUST_ICON)
            {
                this.Height = 56;
                this.Width = 78;
            }
            else if (isMin == EDisplayMode.RESUME)
            {
                this.Height = 120;
                this.Width = 430;
            }
            else if (isMin == EDisplayMode.EXPANDED)
            {
                int beforeTam = before.Top + before.Height;
                int afterTam = after.Top + after.Height;

                int max = beforeTam > afterTam ? beforeTam : afterTam;
                this.Height = 430;// max + 10 ;
                this.Width = 430;
            }
        }

        private void Picture_Click(object sender, EventArgs e)
        {
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void BttDown_Click(object sender, EventArgs e)
        {
            
        }

        private void BttUp_Click(object sender, EventArgs e)
        {
            if (isMin == EDisplayMode.JUST_ICON)
            {
                isMin = EDisplayMode.RESUME;
            }
            else if (isMin == EDisplayMode.RESUME)
            {
                isMin = EDisplayMode.EXPANDED;
            }
            else
            {
                isMin = EDisplayMode.JUST_ICON;
            }
            RefreshMode();
        }

        private void BttDown_Click_1(object sender, EventArgs e)
        {
            if (isMin == EDisplayMode.JUST_ICON)
            {
                isMin = EDisplayMode.EXPANDED;
            }
            else if (isMin == EDisplayMode.RESUME)
            {
                isMin = EDisplayMode.JUST_ICON;
            }
            else
            {
                isMin = EDisplayMode.RESUME;
            }
            RefreshMode();
        }

        private void Picture_Click_1(object sender, EventArgs e)
        {
            isMin = EDisplayMode.RESUME;
            RefreshMode();
        }
    }
}
