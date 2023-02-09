using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderApp.Persistence.Entities
{
    public class Order
    {
        public Order()
        {
            Windows = new();
        }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public List<Window> Windows { get; set; }
    }
}
