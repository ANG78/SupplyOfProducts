﻿using SupplyOfProducts.Interfaces.BusinessLogic;
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
        private Label lblDesc;
        private PictureBox picture;
        private System.ComponentModel.IContainer components;

        public UIStepControl()
        {
            HelperUI.ModifyMethod(this, () =>
            {
                InitializeComponent();
                this.picture.Image = this.imageList1.Images[(int)EIcons.INITIAL];
            });
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void SetValueStart(string item, string desc = null)
        {
            HelperUI.ModifyMethod(this, () =>
             {
                 this.picture.Image = this.imageList1.Images[(int)EIcons.START];
                 this.before.Text = item;
                 this.lblDesc.Text = (desc);
             });
        }

        public void SetValueFinish(string item, IResult res)
        {

            HelperUI.ModifyMethod(this, () =>
            {
                if (res.ComputeResult().IsOk())
                {
                    this.picture.Image = this.imageList1.Images[(int)EIcons.END_OK];
                    this.after.Text = item;
                }
                else if (res.ComputeResult().IsWarning())
                {
                    this.picture.Image = this.imageList1.Images[(int)EIcons.END_WARNINGS];
                    this.after.Text = item;
                }
                else
                {
                    this.picture.Image = this.imageList1.Images[(int)EIcons.END_ERRORS];
                    this.after.Text = res.Message();
                }
            });
        }

        public void SetValueException(string item, string desc)
        {
            HelperUI.ModifyMethod(this, () =>
            {
                this.picture.Image = this.imageList1.Images[(int)EIcons.END_ERRORS];
                this.after.Text = item;

                this.lblDesc.Text = (desc);
            });
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIStepControl));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.before = new System.Windows.Forms.RichTextBox();
            this.after = new System.Windows.Forms.RichTextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.picture = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "exec.bmp");
            this.imageList1.Images.SetKeyName(1, "exec VIRTUAL.bmp");
            this.imageList1.Images.SetKeyName(2, "exec SUCCESSFUL.bmp");
            this.imageList1.Images.SetKeyName(3, "exec AFTER.bmp");
            this.imageList1.Images.SetKeyName(4, "exec DURING.bmp");
            this.imageList1.Images.SetKeyName(5, "operacion exec.bmp");
            this.imageList1.Images.SetKeyName(6, "operacion no exec.bmp");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.before);
            this.panel1.Controls.Add(this.after);
            this.panel1.Controls.Add(this.lblDesc);
            this.panel1.Controls.Add(this.picture);
            this.panel1.Location = new System.Drawing.Point(3, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 100);
            this.panel1.TabIndex = 2;
            // 
            // before
            // 
            this.before.Location = new System.Drawing.Point(3, 36);
            this.before.Name = "before";
            this.before.Size = new System.Drawing.Size(180, 55);
            this.before.TabIndex = 5;
            this.before.Text = "";
            // 
            // after
            // 
            this.after.Location = new System.Drawing.Point(189, 36);
            this.after.Name = "after";
            this.after.Size = new System.Drawing.Size(177, 55);
            this.after.TabIndex = 4;
            this.after.Text = "";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(37, 13);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(41, 17);
            this.lblDesc.TabIndex = 3;
            this.lblDesc.Text = "lblDesc";
            this.lblDesc.UseCompatibleTextRendering = true;
            // 
            // picture
            // 
            this.picture.Location = new System.Drawing.Point(3, 6);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(28, 24);
            this.picture.TabIndex = 2;
            this.picture.TabStop = false;
            // 
            // UIStepControl
            // 
            this.Controls.Add(this.panel1);
            this.Name = "UIStepControl";
            this.Size = new System.Drawing.Size(396, 126);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);

        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
