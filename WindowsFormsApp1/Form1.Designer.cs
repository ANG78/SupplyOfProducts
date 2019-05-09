namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.supplyOfProductsDataSet1 = new WindowsFormsApp1.SupplyOfProductsDataSet();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.supplyOfProductsDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productTableAdapter = new WindowsFormsApp1.SupplyOfProductsDataSetTableAdapters.ProductTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.supplyOfProductsDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyOfProductsDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // supplyOfProductsDataSet1
            // 
            this.supplyOfProductsDataSet1.DataSetName = "SupplyOfProductsDataSet";
            this.supplyOfProductsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.productBindingSource;
            this.comboBox1.DisplayMember = "Code";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(341, 87);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(101, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // supplyOfProductsDataSet1BindingSource
            // 
            this.supplyOfProductsDataSet1BindingSource.DataSource = this.supplyOfProductsDataSet1;
            this.supplyOfProductsDataSet1BindingSource.Position = 0;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.supplyOfProductsDataSet1BindingSource;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.supplyOfProductsDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyOfProductsDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SupplyOfProductsDataSet supplyOfProductsDataSet1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource supplyOfProductsDataSet1BindingSource;
        private System.Windows.Forms.BindingSource productBindingSource;
        private SupplyOfProductsDataSetTableAdapters.ProductTableAdapter productTableAdapter;
    }
}

