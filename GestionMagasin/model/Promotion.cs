using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasin.model
{
    public enum TypePromotion
    {
        Pourcentage,
        MontantFixe
    }

    public class Promotion
    {
        public TypePromotion TypePromotion { get; set; }
        public decimal ValeurPromotion { get; set; }

        public decimal AppliquerPromotion(decimal total)
        {
            return TypePromotion == TypePromotion.Pourcentage
                ? total - (total * ValeurPromotion / 100)
                : total - ValeurPromotion;
        }
    }
}
