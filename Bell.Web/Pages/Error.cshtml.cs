using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bell.Web.Pages;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel : PageModel
{
    public ushort? Code { get; set; }

    public string? ErrorMessage { get; set; }

    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    private readonly ILogger<ErrorModel> _logger;

    public ErrorModel(ILogger<ErrorModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(ushort? code)
    {
        Code = code;

        // Gets status code message and splits it (e.g. "BadRequest" becomes "Bad Request").
        var err = ((HttpStatusCode?)code)?.ToString();
        ErrorMessage = err == null ? null : String.Join(' ', Regex.Replace(err, @"([A-Z0-9])", @" $1"));

        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
    }
}

