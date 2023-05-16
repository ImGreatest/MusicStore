using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Models;

public class Performer
{
    [Key]
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string? Name { get; set; }
}