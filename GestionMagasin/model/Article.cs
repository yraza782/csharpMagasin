using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasin.model
{
    public class Article
    {
        public string Nom { get; set; }
        public decimal Prix { get; set; }
        public int Quantite { get; set; }

        public Article(string nom, decimal prix, int quantite)
        {
            Nom = nom;
            Prix = prix;
            Quantite = quantite;
        }

        public void Afficher()
        {
            Console.WriteLine($"Nom: {Nom}, Prix: {Prix:C}, Quantité: {Quantite}");
        }

        public void Ajouter(int quantity) => Quantite += quantity;
        public void Retirer(int quantity) => Quantite -= quantity;
    }
    public enum TypeArticle
    {
        Alimentaire,
        Vêtements,
        Droguerie
    }

    public class ArticleTypé : Article
    {
        public TypeArticle TypeArticle { get; set; }

        public ArticleTypé(string nom, decimal prix, int quantite, TypeArticle typeArticle)
            : base(nom, prix, quantite)
        {
            TypeArticle = typeArticle;
        }

        public new void Afficher()
        {
            Console.WriteLine($"Nom: {Nom}, Prix: {Prix:C}, Quantité: {Quantite}, Type: {TypeArticle}");
        }
    }
}
