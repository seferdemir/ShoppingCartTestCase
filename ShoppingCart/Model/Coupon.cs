using ShoppingCart.Enumeration;

namespace ShoppingCart.Model
{
    public class Coupon
    {
        private double MinimumPurchaseAmount { get; set; }
        private double DiscountRate { get; set; }
        private DiscountType DiscountType { get; set; }

        public Coupon(double minimumPurchaseAmount, double discountRate, DiscountType discountType)
        {
            MinimumPurchaseAmount = minimumPurchaseAmount;
            DiscountRate = discountRate;
            DiscountType = discountType;
        }

        public double getMinimumPurchaseAmount()
        {
            return MinimumPurchaseAmount;
        }

        public void setMinimumPurchaseAmount(double minimumPurchaseAmount)
        {
            MinimumPurchaseAmount = minimumPurchaseAmount;
        }

        public double getDiscountRate()
        {
            return DiscountRate;
        }

        public void setDiscountRate(double discountRate)
        {
            DiscountRate = discountRate;
        }

        public DiscountType getDiscountType()
        {
            return DiscountType;
        }

        public void setDiscountType(DiscountType discountType)
        {
            DiscountType = discountType;
        }
    }
}
