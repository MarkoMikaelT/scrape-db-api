using Microsoft.AspNetCore.Mvc;
using Application.Clients;
using Application.Models;
using Application.Util;
using Application.Implementations;

namespace Application.Controllers;

[ApiController]
[Route("api/[Controller]/[Action]")]
public class ScrapeController : ControllerBase {

    readonly static Properties props = new();
    private readonly MdbClient<Scrape1> mdbClient = new(props.GetProperties()["MONGOCONNECTION"], "ScrapedData", "Scrape1");
    // private readonly SupaClient supaClient = new(props.GetProperties()["SUPACONNECTION"], props.GetProperties()["SUPASECRET"], "DuuniScrape");

    private readonly MigrateToSupa migrateToSupa = new();

     [HttpGet(Name = "GetAllAsync")]
    public Task<Response<List<Scrape1>>> GetAllAsync(){
        return mdbClient.GetAllDocumentsAsync();
    }

    [HttpGet(Name = "GetByQuerysync")]
    public Task<Response<List<Scrape1>>> GetByQuerysync(
        [FromQuery(Name = "key")] string key,
        [FromQuery(Name = "value")] string value
        ){
        return mdbClient.GetDocumentsBySetKeyAsync(key, value);
    }

    [HttpPost(Name = "MigrateToSupa")]
    public async Task<Response<string>> MigrateToSupa(){
        return await migrateToSupa.MigrateAll();
    }
}