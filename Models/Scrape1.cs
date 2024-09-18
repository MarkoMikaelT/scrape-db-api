using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ScrapeAPI.Models;

public class Scrape1
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("python")]
    public int Python { get; set; }

    [BsonElement("javascript")]
    public int Javascript { get; set; }

    [BsonElement("java")]
    public int Java { get; set; }

    [BsonElement("cplus")]
    public int Cplus { get; set; }

    [BsonElement("sql")]
    public int Sql { get; set; }

    [BsonElement("flutter")]
    public int Flutter { get; set; }

    [BsonElement("kotlin")]
    public int Kotlin { get; set; }

    [BsonElement("php")]
    public int Php { get; set; }

    [BsonElement("csharp")]
    public int Csharp { get; set; }

    [BsonElement("html")]
    public int Html { get; set; }

    [BsonElement("css")]
    public int Css { get; set; }

    [BsonElement("typescript")]
    public int Typescript { get; set; }

    [BsonElement("rust")]
    public int Rust { get; set; }

    [BsonElement("swift")]
    public int Swift { get; set; }

    [BsonElement("nosql")]
    public int Nosql { get; set; }

    [BsonElement("checkedPages")]
    public int CheckedPages { get; set; }

    [BsonElement("runDate")]
    public string RunDate { get; set; }

    [BsonElement("runTime")]
    public string RunTime { get; set; }
}
