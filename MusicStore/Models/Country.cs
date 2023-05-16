using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Models;

public class Country
{
    [Key]
    [Required]
    public string? NameCountry { get; set; }
}