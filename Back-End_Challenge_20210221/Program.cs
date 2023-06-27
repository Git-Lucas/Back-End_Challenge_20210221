using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var _httpClient = new HttpClient
{
    BaseAddress = new Uri("https://ll.thespacedevs.com/2.0.0/")
    //BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
};

app.MapGet("", async () =>
{
    var response = await _httpClient.GetAsync("launch/e3df2ecd-c239-472f-95e4-2b89b4f75800");
    var jsonString = await response.Content.ReadAsStringAsync();
    var launch = JsonConvert.DeserializeObject<Launch>(jsonString);

    return Results.Ok(launch);

    //var response = await _httpClient.GetAsync("users/1");
    //var jsonString = await response.Content.ReadAsStringAsync();
    //var users = JsonConvert.DeserializeObject<User>(jsonString);

    //return Results.Ok(users);
});

app.Run();
