using CartApi.Models;

namespace CartApi.Services
{
    public interface IShipmentService
    {
        void Ship(IAddressInfo info, IEnumerable<CartItem> items);
    }
}
