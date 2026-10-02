using System.ComponentModel.DataAnnotations;

namespace MindMirror.Models;

public static class ResourceTypes
{
    public static readonly string[] All =
        { "Hotline", "Hospital", "Clinic", "Support group", "Online service", "NGO" };
}

public class Resource
{
    public int Id { get; set; }

    [Required, StringLength(120)]
    public string Name { get; set; } = "";

    [Required, StringLength(30)]
    public string Type { get; set; } = "Clinic";

    [StringLength(60)]
    public string? City { get; set; }

    [StringLength(40), RegularExpression(@"^[0-9+\-\s()]*$", ErrorMessage = "Phone can only contain digits, spaces, + - ( )")]
    public string? Phone { get; set; }

    [StringLength(200), Url]
    public string? Website { get; set; }

    [StringLength(300)]
    public string? Address { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    public bool Is24Hours { get; set; }
    public bool IsFree { get; set; }

    [DataType(DataType.Date)]
    public DateTime? VerifiedOn { get; set; }

    // Arabic versions (optional)
    [StringLength(120)]
    public string? NameAr { get; set; }

    [StringLength(300)]
    public string? AddressAr { get; set; }

    [StringLength(500)]
    public string? DescriptionAr { get; set; }

    public string NameIn(bool ar) => ar && !string.IsNullOrWhiteSpace(NameAr) ? NameAr! : Name;
    public string? AddressIn(bool ar) => ar && !string.IsNullOrWhiteSpace(AddressAr) ? AddressAr : Address;
    public string? DescriptionIn(bool ar) => ar && !string.IsNullOrWhiteSpace(DescriptionAr) ? DescriptionAr : Description;

    // Digits and + only, safe to use in a tel: link
    public string? PhoneHref =>
        Phone == null ? null : new string(Phone.Where(ch => char.IsDigit(ch) || ch == '+').ToArray());
}