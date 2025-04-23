using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PieShop.Models;

public class Order
{
    [BindNever]
    public int OrderId { get; set; }
    public List<OrderDetail>? OrderDetails { get; set; }
    
    [Required(ErrorMessage = "Please enter your first name")]
    [Display(Name = "First Name")]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Please enter your Last name")]
    [Display(Name = "Last Name")]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Please enter your address")]
    [Display(Name = "Address Line 1")]
    [StringLength(100)]
    public string AddressLine1 { get; set; } = string.Empty;

    [StringLength(100)]
    public string? AddressLine2 { get; set; }

    [StringLength(50)]
    [Required]
    [DataType(DataType.PostalCode)]
    public string ZipCode { get; set; } = string.Empty;

    [StringLength(100)]
    public string City { get; set; } = string.Empty;

    [StringLength(100)]
    public string? State { get; set; }

    [StringLength(100)]
    public string Country { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Phone number")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$", ErrorMessage="Invalid email address")]
    public string Email { get; set; } = string.Empty;

    public decimal OrderTotal { get; set; }

    public DateTime OrderPlaced { get; set; }
}