using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Application.Models;
public class Response <T>(T content, HttpStatusCode status, string? error)
{
    [Required]
    public T Content { get; set; } = content;
    [Required]
    public HttpStatusCode Status { get; set; } = status;
    public string? Error { get; set; } = error;
}