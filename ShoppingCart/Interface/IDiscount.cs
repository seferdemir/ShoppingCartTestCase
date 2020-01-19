using ShoppingCart.Model;

namespace ShoppingCart.Interface
{
    public interface IDiscount
    {
        void applyDiscount(params Campaign[] campaigns);
    }
}
