using ShoppingCart.Enumeration;
using ShoppingCart.Model;
using System;
using Cart = ShoppingCart.Model.ShoppingCart;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
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
            Console.WriteLine("Campaign Discount: \n{0}\n", cart.print());

            //Coupon coupon = new Coupon(100, 10, DiscountType.Rate);
            //Coupon coupon = new Coupon(100, 5, DiscountType.Amount);
            //cart.applyCoupon(coupon);
            //Console.WriteLine("Coupon Discount: \n{0}\n", cart.print());

            Console.Read();
        }
    }
}
