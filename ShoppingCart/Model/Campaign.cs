using ShoppingCart.Enumeration;

namespace ShoppingCart.Model
{
    public class Campaign
    {
        public Category Category { get; set; }
        public double DiscountRate { get; set; }
        public int MinimumItemCount { get; set; }
        public DiscountType DiscountType { get; set; }

        public Campaign(Category Category, double DiscountRate, int MinimumItemCount, DiscountType DiscountType)
        {
            this.Category = Category;
            this.DiscountRate = DiscountRate;
            this.MinimumItemCount = MinimumItemCount;
            this.DiscountType = DiscountType;
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
