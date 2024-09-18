using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ScrapeAPI.Clients;
using ScrapeAPI.Models;
using ScrapeAPI.Util;

namespace ScrapeAPI.Controllers;

[ApiController]
[Route("api/[Controller]/[Action]")]
public class ScrapeController : ControllerBase {

    readonly static Properties props = new();
    private readonly MdbClient<Scrape1> mdbClient = new(props.GetProperties()["MONGOCONNECTION"], "ScrapedData", "Scrape1");
    private readonly SupaClient supaClient = new(props.GetProperties()["SUPACONNECTION"], props.GetProperties()["SUPASECRET"], "DuuniScrape");

    [HttpGet(Name = "GetScrapeByDate")]
    public Task<Response<List<Scrape1>>> GetByDateAsync([FromQuery(Name = "id")] string date){
        return mdbClient.GetDocumentsByDateAsync(date);
    }

     [HttpGet(Name = "GetScrapeAll")]
    public Task<Response<List<Scrape1>>> GetAllAsync(){
        return mdbClient.GetAllDocumentsAsync();
    }

    [HttpPost(Name = "InsertToSupa")]
    public async Task<Response<string>> InsertToSupa(){
        Response<List<Scrape1>> mongoDoc = await mdbClient.GetDocumentsByDateAsync("03-03-2023");
        DateTime dateTime = DateTime.ParseExact($"{mongoDoc.Content[0].RunDate} {mongoDoc.Content[0].RunTime}",
        "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        ScrapeCounts counts = mongoDoc.Content[0];
        return await supaClient.InsertRow(dateTime, counts, mongoDoc.Content[0].Id.Timestamp);
    }
}