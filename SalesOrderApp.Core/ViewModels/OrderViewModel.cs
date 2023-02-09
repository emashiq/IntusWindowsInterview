using System;
namespace SalesOrderApp.Core.ViewModels
{
	public class OrderViewModel
	{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int TotalWindows { get; set; }
    }
}

