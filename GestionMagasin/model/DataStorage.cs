using GestionMagasin.model;
using System.Collections.Generic;

namespace GestionMagasin.model
{
    public static class DataStorage
    {
        // Liste des produits disponibles dans le magasin
        public static List<Article> Articles { get; set; } = new List<Article>();

        // Panier en cours
        public static Panier Panier { get; set; } = new Panier();

        // Liste des commandes validées
        public static List<Commande> Commandes { get; set; } = new List<Commande>();
    }
}
