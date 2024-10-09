using System.ComponentModel.DataAnnotations;

namespace Chirp.Core.Entities;

public class Cheep
{
    public int CheepId { get; set; }
    public Author Author { get; set; }
    public int AuthorId { get; set; } 
    [StringLength(160)]
    public string Text { get; set; } 
    public DateTime TimeStamp { get; set; } 
}