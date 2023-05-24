using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MusicStore.Models;

public class Style
{
    [Key]
    //[Required]
    public string? NameStyle { get; set; }
}