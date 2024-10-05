
using Application.Clients;
using Application.Models;
using Application.Util;

namespace Application.Implementations;
public class MigrateToSupa {

    readonly static Properties props = new();
    private readonly MdbClient<Scrape1> mdbClient = new(props.GetProperties()["MONGOCONNECTION"], "ScrapedData", "Scrape1");
    private readonly SupaClient supaClient = new(props.GetProperties()["SUPACONNECTION"], props.GetProperties()["SUPASECRET"], "DuuniScrape");


    public async Task<Response<string>> MigrateAll(){
        Response<List<Scrape1>> mongoDocs = await mdbClient.GetAllDocumentsAsync();
        List<SupaSchema> supaList = [];
        foreach (var doc in mongoDocs.Content)
        {
            var mDateTime = DateTime.ParseExact(
                $"{doc.RunDate} {doc.RunTime}", 
                "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture
                );
            ScrapeCounts mCounts = doc;
            var mTimestamp = doc.Id.Timestamp;

            var newSupa = new SupaSchema(_mongoTimestamp: mTimestamp, _counts: mCounts, _runDateTime: mDateTime);
            supaList.Add(newSupa);
        }

        // ScrapeCounts counts = mongoDoc.Content[0];
        // DateTime dateTime = DateTime.ParseExact($"{mongoDoc.Content[0].RunDate} {mongoDoc.Content[0].RunTime}",
        // "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        return await supaClient.InsertRows(supaList);
    }

}