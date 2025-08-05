using MVP.Data.Models.Enums;

namespace MVP.Data.Models;

public class Media
{
    public int Id { get; set; }
    public Title Title { get; set; }
    public int? AverageScore { get; set; }
    public List<string> Genres { get; set; }
    
}