namespace Application.Models;

public class SupaResponse
{
    public SupaResponse(string _code, string _details, string _hint, string _message)
    {
        code = _code;
        details = _details;
        hint = _hint;
        message = _message;
    }

    public string code { get; set; }
    public string details { get; set; }
    public string hint { get; set; }
    public string message { get; set; }
}
