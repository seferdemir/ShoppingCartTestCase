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
            var validCardItems = ShoppingCartItemList.Where(x => x.getProduct().getCategory() == campaign.getCategory()).ToList();
            var validProducts = validCardItems.Select(x => x.getProduct()).ToList();

            var totalAmount = validCardItems.Select(x => new { Price = x.getProduct().getPrice(), Quantity = x.getQuantity() }).Sum(x => x.Price * x.Quantity);

            double appliedAmountForCampaign = 0;

            if (validCardItems.Sum(x => x.getQuantity()) > campaign.getMinimumItemCount())
            {
                foreach (var item in validCardItems)
                {
                    if (campaign.getDiscountType() == DiscountType.Rate)
                    {
                        appliedAmountForCampaign = totalAmount * (campaign.getDiscountRate() / 100);
                    }
                    else
                    {
                        appliedAmountForCampaign = campaign.getDiscountRate();
                    }
                }
            }

            return appliedAmountForCampaign;
        }

        public double GetDiscountAmount(Coupon coupon)
        {
            var totalAmounts = ShoppingCartItemList.Select(x => x.getProduct().getPrice() * x.getQuantity()).Sum();

            double appliedAmountForCampaign = 0;

            if (totalAmounts >= coupon.getMinimumPurchaseAmount())
            {
                foreach (var item in ShoppingCartItemList)
                {
                    if (coupon.getDiscountType() == DiscountType.Rate)
                    {
                        appliedAmountForCampaign = totalAmounts * (coupon.getDiscountRate() / 100);
                    }
                    else
                    {
                        appliedAmountForCampaign = coupon.getDiscountRate();
                    }
                }
            }

            return appliedAmountForCampaign;
        }
    }
}
