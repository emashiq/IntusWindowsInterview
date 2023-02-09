using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderApp.Persistence.Entities
{
    public class Window
    {
        public Window()
        {
            SubElements = new();
        }
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int QuantityOfWindows { get; set; }
        public int TotalSubElements { get; set; }
        public Order Order { get; set; }
        public List<SubElement> SubElements { get; set; }
    }
}
