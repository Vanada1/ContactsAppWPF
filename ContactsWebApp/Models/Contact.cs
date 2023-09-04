using System.ComponentModel.DataAnnotations;

namespace ContactsWebApp.Models;

public class Contact
{
    public Guid Id { get; set; } = new ();

    [Required]
    [StringLength (50, MinimumLength = 2, ErrorMessage="First Name can contain from 2 to 50 symbols")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Last Name can contain from 2 to 50 symbols")]
    public string LastName { get; set; }

    [RegularExpression(
        @"(([^<>()\[\]\\.,;:\s@""]+(\.[^<>()\[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))",
        ErrorMessage = "Wrong e-mail format")]
    public string? Email { get; set; }

    [Required]
    [RegularExpression(
        @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$",
        ErrorMessage = "Wrong phone number format")]
    public string PhoneNumber { get; set; }

    public DateTime? Birthday { get; set; }

    public string? VkId { get; set; }
}