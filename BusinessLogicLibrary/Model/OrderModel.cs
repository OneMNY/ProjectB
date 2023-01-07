using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary.Model
{
    public class OrderModel
    {
        public OrderHeaderModel Header { get; set; }
        public List<OrderDetailModel> Details { get; set; }
    }
}
