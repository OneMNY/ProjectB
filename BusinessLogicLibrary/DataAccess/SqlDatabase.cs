using BusinessLogicLibrary.Model;

namespace BusinessLogicLibrary.DataAccess
{
    public class SqlDatabase : IDatabase
    {
        private readonly SqlRepository _repository;

        public SqlDatabase(string connectionString)
        {
            _repository = new SqlRepository(connectionString);
        }

        public OrderHeaderModel GetOrderHeader(string orderId)
        {
            return _repository.GetOrderHeader(orderId);
        }

        public IEnumerable<OrderDetailModel> GetOrderDetails(string orderId)
        {
            return _repository.GetOrderDetails(orderId);
        }

        public OrderModel GetOrder(string orderId)
        {
            return new OrderModel 
            { 
                Header = GetOrderHeader(orderId),
                Details = GetOrderDetails(orderId).ToList(),
            };
        }
    }
}
