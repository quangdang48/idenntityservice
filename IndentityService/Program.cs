using IndentityService;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Wellcome page
app.MapGet("/", () => "Hello World!");
// Test page 
app.MapGet("/test", () => "This is a test page - after add github action...");
// Login page 
app.MapPost("/login", (UserDto userDto) =>
{
    if (userDto.Username == "admin" && userDto.Password == "password")
    {
        return Results.Ok("Login successful!");
    }
    return Results.Unauthorized();
});



app.Run();
