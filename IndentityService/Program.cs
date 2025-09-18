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
    if (userDto.Username == "admin" && userDto.Password == "password")
    {
        return Results.Ok("Login successful Quang!");
    }
    return Results.Unauthorized();
});



app.Run();
