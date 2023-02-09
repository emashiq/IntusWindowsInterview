using System;
using System.ComponentModel.DataAnnotations;

namespace SalesOrderApp.Core.ViewModels
{
	public class SubElementRequestViewModel
	{
        public int? Id { get; set; }
        public int WindowId { get; set; }
        [Required]
        public string Type { get; set; } = string.Empty;
        [Required]
        [Range(0.0, int.MaxValue, ErrorMessage = "Value should be greater than 0")]
        public int Element { get; set; }
        [Required]
        [Range(0.0, int.MaxValue, ErrorMessage = "Value should be greater than 0")]
        public int Width { get; set; }
        [Required]
        [Range(0.0, int.MaxValue, ErrorMessage = "Value should be greater than 0")]
        public int Height { get; set; }
    }
}

