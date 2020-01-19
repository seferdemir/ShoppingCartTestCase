using ShoppingCart.Enumeration;

namespace ShoppingCart.Model
{
    public class Campaign
    {
        private Category Category { get; set; }
        private double DiscountRate { get; set; }
        private int MinimumItemCount { get; set; }
        private DiscountType DiscountType { get; set; }

        public Campaign(Category category, double discountRate, int minimumItemCount, DiscountType discountType)
        {
            Category = category;
            DiscountRate = discountRate;
            MinimumItemCount = minimumItemCount;
            DiscountType = discountType;
        }

        public Category getCategory()
        {
            return Category;
        }

        public void setCategory(Category category)
        {
            Category = category;
        }

        public double getDiscountRate()
        {
            return DiscountRate;
        }

        public void setDiscountRate(double discountRate)
        {
            DiscountRate = discountRate;
        }

        public int getMinimumItemCount()
        {
            return MinimumItemCount;
        }

        public void setMinimumItemCount(int minimumItemCount)
        {
            MinimumItemCount = minimumItemCount;
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
