using MongoDB.Bson;

namespace ScrapeAPI.Models;

public class SupaPost
{
    public int Timestamp { get; set; }
    public ScrapeCounts Counts {get; set;}
    public DateTime RunDateTime { get; set; }
}
