using System;
using System.ComponentModel.DataAnnotations;
using SalesOrderApp.Persistence.Entities;

namespace SalesOrderApp.Core.ViewModels
{
	public class WindowsRequestViewModel
	{
        public int? Id { get; set; }
        public int OrderId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(0.0, int.MaxValue, ErrorMessage = "Value should be greater than 0")]
        public int QuantityOfWindows { get; set; }
        public int TotalSubElements { get; set; }
        public List<SubElementRequestViewModel> SubElements { get; set; }
    }
}

