using NUnit.Framework;
using ShoppingCart.Enumeration;
using ShoppingCart.Model;
using Cart = ShoppingCart.Model.ShoppingCart;

namespace ShoppingCartUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Category food = new Category("Food");
            Category technology = new Category("Technology");

            Product apple = new Product("Apple", 100.0, technology);
            Product samsung = new Product("Samsung", 80.0, technology);
            Product almond = new Product("Almond", 5.0, food);
            Product nut = new Product("Nut", 8.0, food);

            Cart cart = new Cart();
            cart.addItem(apple, 3);
            cart.addItem(samsung, 1);
            cart.addItem(almond, 1);
            cart.addItem(nut, 1);

            Campaign campaign1 = new Campaign(technology, 20.0, 3, DiscountType.Rate);

            Campaign campaign2 = new Campaign(food, 50.0, 5, DiscountType.Rate);

            Campaign campaign3 = new Campaign(food, 5.0, 5, DiscountType.Amount);

            cart.applyDiscount(campaign1, campaign2, campaign3);
            var printResultForCampaign = cart.print();

            //Coupon coupon = new Coupon(100, 10, DiscountType.Rate);
            //cart.applyCoupon(coupon);
            //var printResultForCoupon = cart.print();
        }
    }
}