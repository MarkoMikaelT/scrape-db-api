using System.Net;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http.Headers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Application.Models;
using Application.Util;
using ZstdSharp.Unsafe;

namespace Application.Clients
{
    public class SupaClient
    {
        readonly static Properties props = new();
        private static string _table = "";
        private static readonly HttpClient _supaClient = new();
        public SupaClient(string connection, string apikey, string table)
        {
            _table = table;
            _supaClient.BaseAddress = new Uri($"{connection}");
            _supaClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apikey);
            _supaClient.DefaultRequestHeaders.Add("apikey", apikey);
            _supaClient.DefaultRequestHeaders.Add("Prefer", "return=minimal");
        }


        public async Task<Response<string>> InsertRows(List<SupaSchema> supaPosts)
        {
            try
            {
                using StringContent jsonContent = new(
                    JsonSerializer.Serialize(supaPosts),
                    Encoding.UTF8,
                    "application/json");
                using HttpResponseMessage res = await _supaClient.PostAsync(_table, jsonContent);
                Console.WriteLine(await res.Content.ReadAsStringAsync());
                return new Response<string>(await res.Content.ReadAsStringAsync(), res.StatusCode, null);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching documents: {ex.Message}");
                return new Response<string>("", HttpStatusCode.InternalServerError, "Uuups failure :( ");
            }
        }

    
    }
}