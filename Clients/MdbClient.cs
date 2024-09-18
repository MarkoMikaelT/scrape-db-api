using System.Net;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using ScrapeAPI.Models;

namespace ScrapeAPI.Clients
{
    public class MdbClient<T>
    {
        private readonly IMongoCollection<T> _collection;

        public MdbClient(string connection, string database, string collection)
        {
            var client = new MongoClient(connection);
            _collection = client.GetDatabase(database).GetCollection<T>(collection);
        }

        public async Task<Response<List<T>>> GetAllDocumentsAsync()
        {
            try
            {
                var filter = Builders<T>.Filter.Empty;
                var res = await _collection.Find(filter).ToListAsync();
                Console.WriteLine($"List count -> {res.Count}");
                return new Response<List<T>>(res, HttpStatusCode.OK, null);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching documents: {ex.Message}");
                return new Response<List<T>>(new List<T>(), HttpStatusCode.InternalServerError, "Uuups failure :(");
            }
        }

        public async Task<Response<List<T>>> GetDocumentsByDateAsync(string date)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq("runDate", date);
                var res = await _collection.Find(filter).ToListAsync();
                Console.WriteLine($"List count -> {res.Count}");
                return new Response<List<T>>(res, HttpStatusCode.OK, null);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching documents: {ex.Message}");
                return new Response<List<T>>(new List<T>(), HttpStatusCode.InternalServerError, "Uuups failure :(");
            }
        }
    
    }
}