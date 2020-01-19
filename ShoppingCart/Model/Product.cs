using System;

namespace ShoppingCart.Model
{
    public class Product
    {
        private string Title { get; set; }
        private double Price { get; set; }
        private Category Category { get; set; }

        public Product(string title, double price, Category parentCategory)
        {
            Title = title;
            Price = price;
            Category = parentCategory;
        }

        public string getTitle()
        {
            return Title;
        }

        public void setTitle(string title)
        {
            Title = title;
        }

        public double getPrice()
        {
            return Price;
        }

        public void setPrice(double price)
        {
            Price = price;
        }

        public Category getCategory()
        {
            return Category;
        }

        public void setCategory(Category category)
        {
            Category = category;
        }
    }
}
