using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MusicStore.Models;

public class Label
{
    [Key]
    [Required]
    public string? NameLabel { get; set; }
}