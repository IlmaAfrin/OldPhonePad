using Decoder = OldPhonePad.Core.OldPhonePad;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () =>
{
    return Results.Content("""
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>OldPhonePad REST API Demo</title>

    <style>
        body {
            font-family: "Segoe UI", Arial, Helvetica, sans-serif;
            max-width: 900px;
            margin: 40px auto;
            padding: 0 20px;
            line-height: 1.7;
            color: #333;
            background-color: #ffffff;
        }

        h1 {
            color: #005a9c;
            margin-bottom: 10px;
        }

        h2 {
            margin-top: 35px;
            color: #2d2d2d;
        }

        p {
            margin-bottom: 15px;
        }

        code {
            background: #f4f4f4;
            padding: 3px 6px;
            border-radius: 4px;
            font-family: Consolas, monospace;
        }

        .example {
            background: #f8f9fa;
            border-left: 4px solid #005a9c;
            padding: 16px;
            margin: 18px 0;
            border-radius: 4px;
        }

        a {
            color: #005a9c;
            text-decoration: none;
            font-weight: 600;
        }

        a:hover {
            text-decoration: underline;
        }

        .note {
            background: #fff8e6;
            border-left: 4px solid #f0ad4e;
            padding: 14px;
            margin-top: 20px;
            border-radius: 4px;
        }

        footer {
            margin-top: 50px;
            padding-top: 20px;
            border-top: 1px solid #ddd;
            color: #666;
            font-size: 0.95em;
        }
    </style>

</head>

<body>

<h1>OldPhonePad REST API Demo</h1>

<p>
Welcome! This demo shows how the <strong>OldPhonePad</strong> class library can be
integrated into an ASP.NET Core REST API.
</p>

<p>
This REST API is a lightweight wrapper around the
<strong>OldPhonePad</strong> library. It demonstrates how the library can
be integrated into an ASP.NET Core application while keeping the decoding
logic independent from the web layer.
</p>

<h2>Available Endpoint</h2>

<p>
<code>GET /decode?input=&lt;encoded_message&gt;</code>
</p>

<h2>Quick Start</h2>

<p>
Click any example below to try the API.
</p>

<div class="example">

<h3>Decode a single letter</h3>

<p>
Request:
<code>/decode?input=33%23</code>
</p>

<p>
<a href="/decode?input=33%23">▶ Try this example</a>
</p>

<p>
Response:
</p>

<pre>{ "result": "E" }</pre>

</div>

<div class="example">

<h3>Decode HELLO</h3>

<p>
Request:
<code>/decode?input=4433555%20555666%23</code>
</p>

<p>
<a href="/decode?input=4433555%20555666%23">▶ Try this example</a>
</p>

<p>
Response:
</p>

<pre>{ "result": "HELLO" }</pre>

</div>

<div class="example">

<h3>Backspace example</h3>

<p>
Request:
<code>/decode?input=227*%23</code>
</p>

<p>
<a href="/decode?input=227*%23">▶ Try this example</a>
</p>

<p>
Response:
</p>

<pre>{ "result": "B" }</pre>

</div>

<div class="note">

<strong>Note</strong>

<p>
The <code>#</code> character must be URL encoded when included in a query
string. Its encoded representation is <code>%23</code>.
</p>

</div>

<h2>About the Demo</h2>

<p>
This REST API is intentionally lightweight. Its purpose is to demonstrate
how the <strong>OldPhonePad</strong> library can be integrated into another
application while keeping the decoding logic completely independent from
the web layer.
</p>

<p>
Because the decoder is implemented as a reusable class library, it can
easily be used in console applications, desktop applications, web APIs,
or other .NET projects.
</p>

<footer>

<p>
Project repository:
<br>
<a href="https://github.com/IlmaAfrin/OldPhonePad" target="_blank">
https://github.com/IlmaAfrin/OldPhonePad
</a>
</p>

<p>
For additional information, please refer to the README and Customer Guide
included in the repository.
</p>

</footer>

</body>

</html>
""", "text/html");
});

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