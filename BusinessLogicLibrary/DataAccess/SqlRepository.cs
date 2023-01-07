using BusinessLogicLibrary.Model;
using Dapper;
using System.Data.SqlClient;

namespace BusinessLogicLibrary.DataAccess
{
    internal class SqlRepository : IDisposable
    {
        private readonly SqlConnection _connection;

        public SqlRepository(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public OrderHeaderModel GetOrderHeader(string RARefNum)
        {
            return _connection.QueryFirstOrDefault<OrderHeaderModel>(
                "SELECT * FROM dbo.T_ORDER_HEADER WHERE RARefNum = @rar",
                new { rar = RARefNum }
            );
        }

        public IEnumerable<OrderDetailModel> GetOrderDetails(string rarRefNum)
        {
            return _connection.Query<OrderDetailModel>(
                "SELECT * FROM dbo.T_ORDER_DETAIL WHERE RARefNum = @rar",
                new { rar = rarRefNum }
            );
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
