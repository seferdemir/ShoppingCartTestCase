using ShoppingCart.Constant;
using ShoppingCart.Enumeration;
using ShoppingCart.Interface;
using ShoppingCart.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Model
{
    public class ShoppingCart : IDiscount, ICoupon
    {
        private List<ShoppingCartItem> ShoppingCartItemList { get; set; } = new List<ShoppingCartItem>();
        private double TotalAmount { get; set; }
        private double TotalAmountAfterDiscount { get; set; }
        private Coupon Coupon { get; set; }
        private double CouponDiscount { get; set; }
        private Campaign Campaign { get; set; }
        private double CampaignDiscount { get; set; }

        public void addItem(Product product, int quantity)
        {
            ShoppingCartItem cartItem = new ShoppingCartItem();
            cartItem.setProduct(product);
            cartItem.setQuantity(quantity);

            ShoppingCartItemList.Add(cartItem);

            TotalAmount += product.getPrice() * quantity;
        }

        public void applyCoupon(Coupon coupon)
        {
            DiscountCalculator discountCalculator = new DiscountCalculator(ShoppingCartItemList);
            double maxCampaignAmount = discountCalculator.GetDiscountAmount(coupon);
            Coupon = coupon;
            CouponDiscount = maxCampaignAmount;
            TotalAmountAfterDiscount = TotalAmount - CouponDiscount;
        }

        public void applyDiscount(params Campaign[] campaigns)
        {
            DiscountCalculator discountCalculator = new DiscountCalculator(ShoppingCartItemList);

            double maxCampaignAmount = 0;
            Campaign selectedCampaign = campaigns[0];

            foreach (var campaign in campaigns)
            {
                var discountAmount = discountCalculator.GetDiscountAmount(campaign);
                if (discountAmount > maxCampaignAmount)
                {
                    maxCampaignAmount = discountAmount;
                    selectedCampaign = campaign;
                }
            }

            Campaign = selectedCampaign;
            CampaignDiscount = maxCampaignAmount;
            TotalAmountAfterDiscount = TotalAmount - CampaignDiscount;
        }

        public List<ShoppingCartItem> getShoppingCartItems()
        {
            return ShoppingCartItemList;
        }

        public double getTotalAmountAfterDiscount()
        {
            return TotalAmountAfterDiscount;
        }

        public double getCouponDiscount()
        {
            return CouponDiscount;
        }

        public double getCampaingDiscount()
        {
            return CampaignDiscount;
        }

        public double getDeliveryCost()
        {
            double costPerDelivery = 2;
            double costPerProduct = 1;
            double fixedCost = Constants.FixedCost;

            DeliveryCostCalculator deliveryCostCalculator = new DeliveryCostCalculator(costPerDelivery, costPerProduct, fixedCost);
            return deliveryCostCalculator.calculateFor(this);
        }

        public string print()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < ShoppingCartItemList.Count; i++)
            {
                ShoppingCartItem cartItem = ShoppingCartItemList[i];
                Product product = cartItem.getProduct();
                Category category = product.getCategory();

                stringBuilder.AppendLine(string.Format("Category Name: {0}, Product Name: {1}, Quantity: {2}, Unit Price: {3:0.00}, Total Price: {4:0.00}", category.getTitle(), product.getTitle(), cartItem.getQuantity(), product.getPrice(), (product.getPrice() * cartItem.getQuantity())));
            }

            stringBuilder.AppendLine(string.Format("\nTotal Discount: {0:0.00}", TotalAmount - TotalAmountAfterDiscount));

            stringBuilder.AppendLine(string.Format("Total Amount: {0:0.00}, Delivery Cost: {1:0.00}", TotalAmountAfterDiscount, getDeliveryCost()));
            return stringBuilder.ToString();
        }
    }
}
