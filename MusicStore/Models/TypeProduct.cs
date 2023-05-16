using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Models;

public class TypeProduct
{
    [Key]
    [Required]
    public string? TypeName { get; set; }
}