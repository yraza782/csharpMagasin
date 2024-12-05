using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GestionMagasin.model;
using Microsoft.VisualBasic;

namespace GestionMagasin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Désactiver les colonnes automatiques
            dgvArticles.AutoGenerateColumns = false;

            // Configurer les colonnes
            dgvArticles.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nom",
                DataPropertyName = "Nom",
                Name = "Nom"
            });

            dgvArticles.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Prix (€)",
                DataPropertyName = "Prix",
                Name = "Prix"
            });

            dgvArticles.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Quantité",
                DataPropertyName = "Quantite",
                Name = "Quantite"
            });

            dgvArticles.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Add",
                Text = "Add",
                UseColumnTextForButtonValue = true,
                Name = "AddButton"
            });

            dgvArticles.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                Name = "EditButton"
            });

            dgvArticles.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Name = "DeleteButton"
            });

            // Ajouter des articles par défaut
            DataStorage.Articles.Add(new Article("Produit Test 1", 9.99m, 10));
            DataStorage.Articles.Add(new Article("Produit Test 2", 19.99m, 5));

            // Rafraîchir l'affichage
            RafraichirDataGridView();
        }

        private void btnCreateProduct_Click(object sender, EventArgs e)
        {
            string nom = Microsoft.VisualBasic.Interaction.InputBox("Nom du produit :", "Créer un produit", "Nouveau Produit");
            if (string.IsNullOrEmpty(nom))
            {
                MessageBox.Show("Le nom ne peut pas être vide.");
                return;
            }

            string prixTexte = Microsoft.VisualBasic.Interaction.InputBox("Prix du produit :", "Créer un produit", "10.00");
            if (!decimal.TryParse(prixTexte, out decimal prix))
            {
                MessageBox.Show("Le prix doit être un nombre valide.");
                return;
            }

            string quantiteTexte = Microsoft.VisualBasic.Interaction.InputBox("Quantité du produit :", "Créer un produit", "1");
            if (!int.TryParse(quantiteTexte, out int quantite))
            {
                MessageBox.Show("La quantité doit être un entier valide.");
                return;
            }

            var newArticle = new Article(nom, prix, quantite);
            DataStorage.Articles.Add(newArticle);

            RafraichirDataGridView(); // Met à jour le DataGridView
            MessageBox.Show("Produit créé avec succès !");
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Vérifiez si une ligne est sélectionnée
            if (dgvArticles.CurrentRow == null || dgvArticles.CurrentRow.Index < 0)
            {
                MessageBox.Show("Veuillez sélectionner un article à supprimer.");
                return;
            }

            // Récupérer l'article correspondant à la ligne sélectionnée
            var article = dgvArticles.CurrentRow.DataBoundItem as Article;
            if (article == null)
            {
                MessageBox.Show("Erreur : Impossible de trouver l'article sélectionné.");
                return;
            }

            // Demander confirmation avant de supprimer
            var result = MessageBox.Show($"Voulez-vous vraiment supprimer '{article.Nom}' ?",
                                         "Confirmation",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Supprimer l'article de la liste
                DataStorage.Articles.Remove(article);

                // Rafraîchir le DataGridView
                RafraichirDataGridView();

                MessageBox.Show($"Article '{article.Nom}' supprimé avec succès !");
            }
        }

        private void dgvArticles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Vérifiez si une cellule valide a été cliquée
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Récupérer l'article correspondant à la ligne cliquée
            var article = dgvArticles.Rows[e.RowIndex].DataBoundItem as Article;
            if (article == null)
            {
                MessageBox.Show("Erreur : Article introuvable.");
                return;
            }

            // Vérifiez si la colonne est "Add"
            if (e.ColumnIndex == dgvArticles.Columns["AddButton"].Index)
            {
                DataStorage.Panier.AjouterArticle(article, 1); // Ajoute une unité au panier
                MessageBox.Show($"{article.Nom} ajouté au panier !");
            }

            // Vérifiez si la colonne est "Edit"
            else if (e.ColumnIndex == dgvArticles.Columns["EditButton"].Index)
            {
                string nouveauNom = Microsoft.VisualBasic.Interaction.InputBox("Nom du produit :", "Modifier produit", article.Nom);
                if (!string.IsNullOrEmpty(nouveauNom))
                {
                    article.Nom = nouveauNom;
                }

                string nouveauPrix = Microsoft.VisualBasic.Interaction.InputBox("Prix du produit :", "Modifier produit", article.Prix.ToString());
                if (decimal.TryParse(nouveauPrix, out decimal prix))
                {
                    article.Prix = prix;
                }

                RafraichirDataGridView(); // Met à jour le DataGridView
                MessageBox.Show("Produit modifié avec succès !");
            }

            // Vérifiez si la colonne est "Delete"
            else if (e.ColumnIndex == dgvArticles.Columns["DeleteButton"].Index)
            {
                // Demander confirmation avant de supprimer
                var result = MessageBox.Show($"Voulez-vous vraiment supprimer '{article.Nom}' ?",
                                             "Confirmation",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Supprimer l'article de la liste
                    DataStorage.Articles.Remove(article);

                    // Rafraîchir le DataGridView
                    RafraichirDataGridView();

                    MessageBox.Show($"Article '{article.Nom}' supprimé avec succès !");
                }
            }
        }

        private void RafraichirDataGridView()
        {
            dgvArticles.DataSource = null; // Supprime la liaison actuelle
            dgvArticles.DataSource = DataStorage.Articles; // Recharge les articles depuis DataStorage
        }

        private void btnGoToBasket_Click(object sender, EventArgs e)
        {
            FormBasket formBasket = new FormBasket();
            formBasket.Show(); // Ouvrir le formulaire du panier
            this.Hide(); // Cacher le formulaire actuel
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // Vérifiez si une ligne est sélectionnée
            if (dgvArticles.CurrentRow == null || dgvArticles.CurrentRow.Index < 0)
            {
                MessageBox.Show("Veuillez sélectionner un article à ajouter au panier.");
                return;
            }

            // Récupérer l'article correspondant à la ligne sélectionnée
            var article = dgvArticles.CurrentRow.DataBoundItem as Article;
            if (article == null)
            {
                MessageBox.Show("Erreur : Impossible de trouver l'article sélectionné.");
                return;
            }

            // Demander la quantité à ajouter
            string quantiteTexte = Microsoft.VisualBasic.Interaction.InputBox("Quantité à ajouter :", "Ajouter au panier", "1");
            if (!int.TryParse(quantiteTexte, out int quantite) || quantite <= 0)
            {
                MessageBox.Show("Veuillez entrer une quantité valide.");
                return;
            }

            // Ajouter l'article au panier
            DataStorage.Panier.AjouterArticle(article, quantite);

            // Confirmer l'ajout
            MessageBox.Show($"{quantite} x {article.Nom} ajouté(s) au panier !");
        }


    }
}
