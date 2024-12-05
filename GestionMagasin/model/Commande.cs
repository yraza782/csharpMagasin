using System;

namespace GestionMagasin.model
{
    public enum EtatCommande
    {
        EnAttente,
        Validee,
        Annulee
    }

    public class Commande
    {
        public Guid IdCommande { get; private set; } = Guid.NewGuid();
        public Panier Panier { get; set; }
        public EtatCommande EtatCommande { get; private set; } = EtatCommande.EnAttente;

        public void AjouterPanier(Panier panier)
        {
            Panier = panier;
        }

        public void ValiderCommande()
        {
            EtatCommande = EtatCommande.Validee;
        }

        public void AnnulerCommande()
        {
            EtatCommande = EtatCommande.Annulee;
        }
    }
}
