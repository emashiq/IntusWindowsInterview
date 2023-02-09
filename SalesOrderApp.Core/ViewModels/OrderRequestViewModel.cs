using System;
using System.ComponentModel.DataAnnotations;
using SalesOrderApp.Persistence.Entities;

namespace SalesOrderApp.Core.ViewModels
{
	public class OrderRequestViewModel
	{
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(2, ErrorMessage = "State should be ISO-2 Code with 2 character length")]
        public string State { get; set; } = string.Empty;
        public List<WindowsRequestViewModel> Windows { get; set; }
    }
}

