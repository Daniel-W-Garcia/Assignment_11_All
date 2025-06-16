using System.ComponentModel.DataAnnotations;

namespace Assignment_11._1.Data;

public class Books
{
    public long? ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    
    public int? Quantity { get; set; }
}