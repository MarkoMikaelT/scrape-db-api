namespace ScrapeAPI.Models;

public class ScrapeCounts
{
    public int Python { get; set; }
    public int Javascript { get; set; }
    public int Java { get; set; }
    public int Cplus { get; set; }
    public int Sql { get; set; }
    public int Flutter { get; set; }
    public int Kotlin { get; set; }
    public int Php { get; set; }
    public int Csharp { get; set; }
    public int Html { get; set; }
    public int Css { get; set; }
    public int Typescript { get; set; }
    public int Rust { get; set; }
    public int Swift { get; set; }
    public int Nosql { get; set; }

    public static implicit operator ScrapeCounts(Scrape1 scrape){
        return new ScrapeCounts{
            Python = scrape.Python,
            Javascript = scrape.Javascript,
            Java = scrape.Java,
            Cplus = scrape.Cplus,
            Sql = scrape.Sql,
            Flutter = scrape.Flutter,
            Kotlin = scrape.Kotlin,
            Php = scrape.Php,
            Csharp = scrape.Csharp,
            Html = scrape.Html,
            Css = scrape.Css,
            Typescript = scrape.Typescript,
            Rust = scrape.Rust,
            Nosql = scrape.Nosql,
            Swift = scrape.Swift
        };
    }
}
