namespace GestionMagasin
{
    partial class FormOrder
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
            this.lblTotalOrder = new System.Windows.Forms.Label();
            this.txtPromoCode = new System.Windows.Forms.TextBox();
            this.btnApplyPromo = new System.Windows.Forms.Button();
            this.btnConfirmOrder = new System.Windows.Forms.Button();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.btnBackToProducts = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrderDetails
            // 
            this.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetails.Location = new System.Drawing.Point(30, 30);
            this.dgvOrderDetails.Name = "dgvOrderDetails";
            this.dgvOrderDetails.RowHeadersWidth = 51;
            this.dgvOrderDetails.RowTemplate.Height = 24;
            this.dgvOrderDetails.Size = new System.Drawing.Size(600, 200);
            this.dgvOrderDetails.TabIndex = 0;
            // 
            // lblTotalOrder
            // 
            this.lblTotalOrder.AutoSize = true;
            this.lblTotalOrder.Location = new System.Drawing.Point(30, 250);
            this.lblTotalOrder.Name = "lblTotalOrder";
            this.lblTotalOrder.Size = new System.Drawing.Size(50, 16);
            this.lblTotalOrder.TabIndex = 1;
            this.lblTotalOrder.Text = "Total : ";
            // 
            // txtPromoCode
            // 
            this.txtPromoCode.Location = new System.Drawing.Point(30, 280);
            this.txtPromoCode.Name = "txtPromoCode";
            this.txtPromoCode.Size = new System.Drawing.Size(150, 22);
            this.txtPromoCode.TabIndex = 2;
            // 
            // btnApplyPromo
            // 
            this.btnApplyPromo.Location = new System.Drawing.Point(200, 280);
            this.btnApplyPromo.Name = "btnApplyPromo";
            this.btnApplyPromo.Size = new System.Drawing.Size(150, 30);
            this.btnApplyPromo.TabIndex = 3;
            this.btnApplyPromo.Text = "Appliquer le code promo";
            this.btnApplyPromo.UseVisualStyleBackColor = true;
            this.btnApplyPromo.Click += new System.EventHandler(this.btnApplyPromo_Click);
            // 
            // btnConfirmOrder
            // 
            this.btnConfirmOrder.Location = new System.Drawing.Point(30, 330);
            this.btnConfirmOrder.Name = "btnConfirmOrder";
            this.btnConfirmOrder.Size = new System.Drawing.Size(150, 30);
            this.btnConfirmOrder.TabIndex = 4;
            this.btnConfirmOrder.Text = "Valider la commande";
            this.btnConfirmOrder.UseVisualStyleBackColor = true;
            this.btnConfirmOrder.Click += new System.EventHandler(this.btnConfirmOrder_Click);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Location = new System.Drawing.Point(200, 330);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(150, 30);
            this.btnCancelOrder.TabIndex = 5;
            this.btnCancelOrder.Text = "Annuler la commande";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // btnBackToProducts
            // 
            this.btnBackToProducts.Location = new System.Drawing.Point(380, 330);
            this.btnBackToProducts.Name = "btnBackToProducts";
            this.btnBackToProducts.Size = new System.Drawing.Size(150, 30);
            this.btnBackToProducts.TabIndex = 6;
            this.btnBackToProducts.Text = "Retour aux produits";
            this.btnBackToProducts.UseVisualStyleBackColor = true;
            this.btnBackToProducts.Click += new System.EventHandler(this.btnBackToProducts_Click);
            // 
            // FormOrder
            // 
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.btnBackToProducts);
            this.Controls.Add(this.btnCancelOrder);
            this.Controls.Add(this.btnConfirmOrder);
            this.Controls.Add(this.btnApplyPromo);
            this.Controls.Add(this.txtPromoCode);
            this.Controls.Add(this.lblTotalOrder);
            this.Controls.Add(this.dgvOrderDetails);
            this.Name = "FormOrder";
            this.Text = "Commande";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvOrderDetails;
        private System.Windows.Forms.Label lblTotalOrder;
        private System.Windows.Forms.TextBox txtPromoCode;
        private System.Windows.Forms.Button btnApplyPromo;
        private System.Windows.Forms.Button btnConfirmOrder;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button btnBackToProducts;
    }
}
