using Decoder = OldPhonePad.Core.OldPhonePad;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/decode", (string input) =>
{
    try
    {
        string result = Decoder.Decode(input);

        return Results.Ok(new
        {
            result
        });
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new
        {
            error = ex.Message
        });
    }
});

app.Run();