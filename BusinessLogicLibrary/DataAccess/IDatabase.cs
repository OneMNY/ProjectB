using BusinessLogicLibrary.Model;

namespace BusinessLogicLibrary.DataAccess
{
    public interface IDatabase
    {
        IEnumerable<OrderDetailModel> GetOrderDetails(string orderId);
        OrderHeaderModel GetOrderHeader(string orderId);
        OrderModel GetOrder(string orderId);
    }
}