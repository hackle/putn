namespace Putn
{
    public static class PromoCodeDiscount
    {
        public static int GetInPercentage(string promoCode)
        {        
            if (promoCode == "akaramba")
            {
                return 8;
            }
            else if (promoCode == "excellent")
            {
                return 6;
            }

            return 0;
        }
    }
}