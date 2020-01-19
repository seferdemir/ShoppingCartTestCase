using ShoppingCart.Enumeration;
using ShoppingCart.Model;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Operation
{
    public class DiscountCalculator
    {
        private List<ShoppingCartItem> ShoppingCartItemList { get; set; }

        public DiscountCalculator(List<ShoppingCartItem> shoppingCartItemList)
        {
            ShoppingCartItemList = shoppingCartItemList;
        }

        public double GetDiscountAmount(Campaign campaign)
        {
            var validCardItems = ShoppingCartItemList.Where(x => x.getProduct().getCategory() == campaign.Category).ToList();
            var validProducts = validCardItems.Select(x => x.getProduct()).ToList();

            var totalAmount = validCardItems.Select(x => new { Price = x.getProduct().getPrice(), Quantity = x.getQuantity() }).Sum(x => x.Price * x.Quantity);

            double appliedAmountForCampaign = 0;

            if (validCardItems.Sum(x => x.getQuantity()) > campaign.MinimumItemCount)
            {
                foreach (var item in validCardItems)
                {
                    if (campaign.DiscountType == DiscountType.Rate)
                    {
                        appliedAmountForCampaign = totalAmount * (campaign.DiscountRate / 100);
                    }
                    else
                    {
                        appliedAmountForCampaign = campaign.DiscountRate;
                    }
                }
            }

            return appliedAmountForCampaign;
        }

        public double GetDiscountAmount(Coupon coupon)
        {
            var totalAmounts = ShoppingCartItemList.Select(x => x.getProduct().getPrice() * x.getQuantity()).Sum();

            double appliedAmountForCampaign = 0;

            if (totalAmounts >= coupon.MinimumPurchaseAmount)
            {
                foreach (var item in ShoppingCartItemList)
                {
                    if (coupon.DiscountType == DiscountType.Rate)
                    {
                        appliedAmountForCampaign = totalAmounts * (coupon.DiscountRate / 100);
                    }
                    else
                    {
                        appliedAmountForCampaign = coupon.DiscountRate;
                    }
                }
            }

            return appliedAmountForCampaign;
        }
    }
}
