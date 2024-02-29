using System.Net.Mime;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpContext context) =>
{
    string html = @" <html> 
                        <body>
                            <h1>Hello World </h1>
                             <br/>
                                Welcome from net core system!
                        </body>
                    </html> 
                ";
    WriteHtml(context, @$"
                <!doctype html>
                 <html> 
                <head><title>miniHtml</title></head>
                        <body>
                            <h1>Simple Frmework </h1>
                             <br/>
                        <form action=""/login"" method=""post"">
                            <label for=""username"">User name:</label>
                            <input type=""text"" id=""username"" name=""username"" required>
                            <label for=""password"">Password:</label>
                            <input type=""password"" id=""password"" name=""password"" required>
                            <button type=""submit"">Login </button>
                        </Form>
                        </body>
                    </html> 
                    ");
});

app.MapPost("/login",(HttpContext context) =>
{
    var username = context.Request.Form["username"];
    var password = context.Request.Form["password"];
    if (username=="frank" && password== "password")
    {
        var html = $@"
                <!doctype html>
                 <html> 
                <head><title>miniHtml</title></head>
                        <body>
                            <h1>Simple Frmework </h1>
                             <br/>
                            Welcome to our simple framework !
                        </body>
                    </html> 
            ";
        WriteHtml(context,html);
    }
    else
    {
        var html = $@"
                <!doctype html>
                 <html> 
                <head><title>miniHtml</title></head>
                        <body>
                            <h1>Simple Frmework </h1>
                            <br/>
                           <form action=""/login"" method=""post"">
                            <label for=""username"">User name:</label>
                            <input type=""text"" id=""username"" name=""username"" required>
                            <label for=""password"">Password:</label>
                            <input type=""password"" id=""password"" name=""password"" required>
                            <button type=""submit"">Login </button>
                            <br/>
                            <label style=""color:red"">Login Fail!</label>

                        </Form>
                        </body>
                    </html> 
            ";
        WriteHtml(context, html);
    }
});

app.Run();

void WriteHtml(HttpContext context, string html)
{
    context.Response.ContentType = MediaTypeNames.Text.Html;
    context.Response.ContentLength = Encoding.UTF8.GetByteCount(html);
    context.Response.WriteAsync(html);

}