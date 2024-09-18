using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace ScrapeAPI.Models;
public class Response <T>{
    public Response(T content, HttpStatusCode status, string? error)
    {
        Content = content;
        Status = status;
        Error = error;
    }
    [Required]
    public T Content {get; set;}
    [Required]
    public HttpStatusCode Status {get; set;}
    public string? Error {get; set;}
}