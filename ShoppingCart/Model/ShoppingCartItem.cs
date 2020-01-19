namespace ShoppingCart.Model
{
    public class ShoppingCartItem
    {
        private Product Product { get; set; }
        private int Quantity { get; set; }

        public Product getProduct()
        {
            return Product;
        }

        public void setProduct(Product product)
        {
            Product = product;
        }

        public int getQuantity()
        {
            return Quantity;
        }

        public void setQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}
