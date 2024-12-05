using GestionMagasin.model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GestionMagasin
{
    public partial class FormOrder : Form
    {
        private Commande _commande;
        private decimal _reduction = 0; // Réduction appliquée

        public FormOrder(Commande commande)
        {
            InitializeComponent();
            _commande = commande;
            this.Load += FormOrder_Load; // Liaison de l'événement Load
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            // Désactiver la génération automatique des colonnes
            dgvOrderDetails.AutoGenerateColumns = false;

            // Configurer les colonnes
            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nom", DataPropertyName = "Nom", Name = "Nom" });
            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Prix (€)", DataPropertyName = "Prix", Name = "Prix" });
            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Quantité", DataPropertyName = "Quantite", Name = "Quantite" });
            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Total (€)", Name = "Total", ReadOnly = true });

            RafraichirCommande();
        }

        private void RafraichirCommande()
        {
            dgvOrderDetails.DataSource = null;
            dgvOrderDetails.DataSource = _commande.Panier.Articles;

            foreach (DataGridViewRow row in dgvOrderDetails.Rows)
            {
                var article = row.DataBoundItem as Article;
                if (article != null)
                {
                    row.Cells["Total"].Value = (article.Prix * article.Quantite).ToString("F2");
                }
            }

            decimal total = _commande.Panier.Articles.Sum(a => a.Prix * a.Quantite) - _reduction;
            lblTotalOrder.Text = $"Total : {total:F2} €";
        }

        private void btnApplyPromo_Click(object sender, EventArgs e)
        {
            string promoCode = txtPromoCode.Text.Trim();

            if (promoCode == "PROMO10")
            {
                _reduction = _commande.Panier.Articles.Sum(a => a.Prix * a.Quantite) * 0.10m; // Réduction de 10%
                MessageBox.Show("Promotion de 10% appliquée !");
            }
            else if (promoCode == "MAGIGABITE20")
            {
                _reduction = _commande.Panier.Articles.Sum(a => a.Prix * a.Quantite) * 0.20m; // Réduction de 20%
                MessageBox.Show("Promotion de 20% appliquée !");
            }
            else
            {
                MessageBox.Show("Code promo invalide !");
                return;
            }

            RafraichirCommande();
        }

        private void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            _commande.ValiderCommande();
            MessageBox.Show("Commande validée avec succès !");
            this.Close();
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            _commande.AnnulerCommande();
            MessageBox.Show("Commande annulée.");
            this.Close();
        }

        private void btnBackToProducts_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
