namespace GestionMagasin
{
    partial class FormBasket
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvBasket = new System.Windows.Forms.DataGridView();
            this.btnBackToProducts = new System.Windows.Forms.Button();
            this.btnValidateOrder = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBasket
            // 
            this.dgvBasket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBasket.Location = new System.Drawing.Point(37, 70);
            this.dgvBasket.Name = "dgvBasket";
            this.dgvBasket.RowHeadersWidth = 51;
            this.dgvBasket.RowTemplate.Height = 24;
            this.dgvBasket.Size = new System.Drawing.Size(481, 194);
            this.dgvBasket.TabIndex = 0;
            this.dgvBasket.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBasket_CellContentClick);
            // 
            // btnBackToProducts
            // 
            this.btnBackToProducts.Location = new System.Drawing.Point(46, 41);
            this.btnBackToProducts.Name = "btnBackToProducts";
            this.btnBackToProducts.Size = new System.Drawing.Size(107, 23);
            this.btnBackToProducts.TabIndex = 1;
            this.btnBackToProducts.Text = "Continuer achat";
            this.btnBackToProducts.UseVisualStyleBackColor = true;
            this.btnBackToProducts.Click += new System.EventHandler(this.btnBackToProducts_Click);
            // 
            // btnValidateOrder
            // 
            this.btnValidateOrder.Location = new System.Drawing.Point(363, 41);
            this.btnValidateOrder.Name = "btnValidateOrder";
            this.btnValidateOrder.Size = new System.Drawing.Size(155, 23);
            this.btnValidateOrder.TabIndex = 2;
            this.btnValidateOrder.Text = "Valider le panier";
            this.btnValidateOrder.UseVisualStyleBackColor = true;
            this.btnValidateOrder.Click += new System.EventHandler(this.btnValidateOrder_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(46, 271);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 16);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Total : ";
            // 
            // FormBasket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnValidateOrder);
            this.Controls.Add(this.btnBackToProducts);
            this.Controls.Add(this.dgvBasket);
            this.Name = "FormBasket";
            this.Text = "Panier";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBasket;
        private System.Windows.Forms.Button btnBackToProducts;
        private System.Windows.Forms.Button btnValidateOrder;
        private System.Windows.Forms.Label lblTotal;
    }
}
