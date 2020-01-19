using System.Linq;
using Cart = ShoppingCart.Model.ShoppingCart;

namespace ShoppingCart.Operation
{
    public class DeliveryCostCalculator
    {
        public double CostPerDelivery { get; set; }
        public double CostPerProduct { get; set; }
        public double FixedCost { get; set; }

        public DeliveryCostCalculator(double costPerDelivery, double costPerProduct, double fixedCost)
        {
            CostPerDelivery = costPerDelivery;
            CostPerProduct = costPerProduct;
            FixedCost = fixedCost;
        }

        public double calculateFor(Cart shoppingCart)
        {
            var cartItems = shoppingCart.getShoppingCartItems();
            var products = cartItems.Select(x => x.getProduct()).ToList();

            double numberOfDeliveries = products.GroupBy(x => x.getCategory(), (key, group) => group.ToList()).Count();
            double numberOfProducts = products.Count;

            return (CostPerDelivery * numberOfDeliveries) + (CostPerProduct * numberOfProducts) + FixedCost;
        }
    }
}
