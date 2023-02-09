

using System.ComponentModel.DataAnnotations;
public class SubElement
{
    public int? Id { get; set; }
    [Required, Range(1, int.MaxValue, ErrorMessage = "Value should be greater than 0")]
    public int? Element { get; set; }
    [Required, StringLength(50)]
    public string Type { get; set; } = string.Empty;
    [Required, Range(1, int.MaxValue, ErrorMessage = "Value should be greater than 0")]
    public int? Width { get; set; }
    [Required, Range(1, int.MaxValue, ErrorMessage = "Value should be greater than 0")]
    public int? Height { get; set; }
}

public class Window
{
    [ValidateComplexType]
    public List<SubElement> SubElements { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Quantity field is required"), Range(1, int.MaxValue, ErrorMessage = "Value should be greater than 0")]
    public int? QuantityOfWindows { get; set; }
    public int TotalSubElements { get; set; }
    public int? Id { get; set; }
    public Window()
    {
        SubElements = new();
    }
}


public class Order
{
    public int? Id { get; set; }
    [Required, StringLength(50)]
    public string Name { get; set; } = string.Empty;
    [Required, StringLength(maximumLength: 2, MinimumLength = 2, ErrorMessage = "State should be ISO-2 Code with 2 character length")]
    public string State { get; set; } = string.Empty;
    [ValidateComplexType]
    public List<Window> Windows { get; set; }
    public int? TotalWindows { get; set; }

    public Order()
    {
        Windows = new();
    }
}



