using System.Collections.Generic;
using System.Linq;

namespace GestionMagasin.model
{
    public class Panier
    {
        public List<Article> Articles { get; set; } = new List<Article>();

        public void AjouterArticle(Article article, int quantity)
        {
            var existingArticle = Articles.FirstOrDefault(a => a.Nom == article.Nom);
            if (existingArticle != null)
            {
                existingArticle.Ajouter(quantity);
            }
            else
            {
                Articles.Add(new Article(article.Nom, article.Prix, quantity));
            }
        }

        public void RetirerArticle(Article article, int quantity)
        {
            var existingArticle = Articles.FirstOrDefault(a => a.Nom == article.Nom);
            if (existingArticle != null)
            {
                existingArticle.Retirer(quantity);
                if (existingArticle.Quantite <= 0)
                {
                    Articles.Remove(existingArticle);
                }
            }
        }

        public decimal CalculerTotal()
        {
            return Articles.Sum(a => a.Prix * a.Quantite);
        }
    }
}
