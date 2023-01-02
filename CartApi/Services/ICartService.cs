using CartApi.Models;

namespace CartApi.Services
{
    public interface ICartService
    {
        double Total();
        IEnumerable<CartItem> Items();
    }
}