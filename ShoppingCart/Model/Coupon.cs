using ShoppingCart.Enumeration;

namespace ShoppingCart.Model
{
    public class Coupon
    {
        public double MinimumPurchaseAmount { get; set; }
        public double DiscountRate { get; set; }
        public DiscountType DiscountType { get; set; }

        public Coupon(double MinimumPurchaseAmount, double DiscountRate, DiscountType DiscountType)
        {
            this.MinimumPurchaseAmount = MinimumPurchaseAmount;
            this.DiscountRate = DiscountRate;
            this.DiscountType = DiscountType;
        }
    }
}
