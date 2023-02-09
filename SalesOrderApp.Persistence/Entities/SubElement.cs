using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderApp.Persistence.Entities
{
    public class SubElement
    {
        public int Id { get; set; }
        public int WindowId { get; set; }
        public string Type { get; set; } = string.Empty;
        public int Element { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Window Window { get; set; }
    }
}
