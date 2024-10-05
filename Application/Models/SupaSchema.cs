namespace Application.Models;

public class SupaSchema
{
    public SupaSchema(int _mongoTimestamp, ScrapeCounts _counts, DateTime _runDateTime)
    {
        mongoTimestamp = _mongoTimestamp;
        counts = _counts;
        runDateTime = _runDateTime;
    }

    public int mongoTimestamp { get; set; }
    public ScrapeCounts counts {get; set;}
    public DateTime runDateTime { get; set; }
}
