using IndentityService;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Wellcome page
app.MapGet("/", () => "Hello World VietNam!");
// Test page 
app.MapGet("/test", () => "This is a test page");
// Login page 
app.MapPost("/login", (UserDto userDto) =>
{
    if (userDto.Username == "admin" && userDto.Password == "password3")
    {
        return Results.Ok("Login successful Test CICD after change pass");
    }
    return Results.Unauthorized();
});



app.Run();
