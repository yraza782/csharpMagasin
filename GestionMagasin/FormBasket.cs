using GestionMagasin.model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GestionMagasin
{
    public partial class FormBasket : Form
    {
        public FormBasket()
        {
            InitializeComponent();
            this.Load += FormBasket_Load; // S'assurer que l'événement Load est correctement lié
        }

        // Méthode appelée lors du chargement du formulaire
        private void FormBasket_Load(object sender, EventArgs e)
        {
            // Désactiver la génération automatique des colonnes
            dgvBasket.AutoGenerateColumns = false;

            // Configurer les colonnes
            dgvBasket.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nom", DataPropertyName = "Nom", Name = "Nom" });
            dgvBasket.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Prix (€)", DataPropertyName = "Prix", Name = "Prix" });
            dgvBasket.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Quantité", DataPropertyName = "Quantite", Name = "Quantite" });
            dgvBasket.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Total (€)", Name = "Total", ReadOnly = true });
            dgvBasket.Columns.Add(new DataGridViewButtonColumn { HeaderText = "Supprimer", Text = "Supprimer", UseColumnTextForButtonValue = true, Name = "DeleteButton" });

            // Charger les articles du panier
            RafraichirPanier();
        }

        // Méthode pour rafraîchir l'affichage du panier
        private void RafraichirPanier()
        {
            dgvBasket.DataSource = null; // Supprime la liaison actuelle
            dgvBasket.DataSource = DataStorage.Panier.Articles; // Recharge les articles depuis le panier

            // Mettre à jour la colonne Total
            foreach (DataGridViewRow row in dgvBasket.Rows)
            {
                var article = row.DataBoundItem as Article;
                if (article != null)
                {
                    row.Cells["Total"].Value = (article.Prix * article.Quantite).ToString("F2");
                }
            }

            // Calculer le total global
            decimal total = DataStorage.Panier.Articles.Sum(a => a.Prix * a.Quantite);
            lblTotal.Text = $"Total : {total:F2} €";
        }

        // Retourne au formulaire des produits
        private void btnBackToProducts_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show(); // Ouvrir le formulaire des produits
            this.Close(); // Fermer le formulaire actuel
        }

        // Valide le panier et crée une commande
        private void btnValidateOrder_Click(object sender, EventArgs e)
        {
            if (!DataStorage.Panier.Articles.Any())
            {
                MessageBox.Show("Le panier est vide !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Créer une nouvelle commande
            var nouvelleCommande = new Commande();
            nouvelleCommande.AjouterPanier(DataStorage.Panier);

            // Ajouter la commande à la liste des commandes
            DataStorage.Commandes.Add(nouvelleCommande);

            // Réinitialiser le panier
            DataStorage.Panier = new Panier();

            MessageBox.Show($"Commande validée avec succès !\nID Commande : {nouvelleCommande.IdCommande}",
                "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Ouvrir FormOrder pour voir les détails de la commande
            FormOrder formOrder = new FormOrder(nouvelleCommande);
            formOrder.Show();

            // Fermer le formulaire actuel
            this.Close();
        }



        // Gestion des événements pour les colonnes "Supprimer"
        private void dgvBasket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Vérifiez si une cellule valide a été cliquée
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Vérifiez si la colonne est "DeleteButton"
            if (e.ColumnIndex == dgvBasket.Columns["DeleteButton"].Index)
            {
                var article = dgvBasket.Rows[e.RowIndex].DataBoundItem as Article;
                if (article != null)
                {
                    DataStorage.Panier.Articles.Remove(article); // Supprimer l'article du panier
                    RafraichirPanier(); // Rafraîchir l'affichage
                    MessageBox.Show($"L'article '{article.Nom}' a été supprimé.");
                }
            }
        }
    }
}
