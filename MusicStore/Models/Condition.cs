using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Models;

public class Condition
{
    [Key]
    [Required]
    public string? Id { get; set; }
}