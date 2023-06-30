using Back_End_Challenge_20210221.Domain.Data;
using Back_End_Challenge_20210221.Infra.Cron;
using Back_End_Challenge_20210221.Infra.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();

builder.Services.AddDbContext<EfSqlServerAdapter>();

builder.Services.AddScoped<ILaunchData, LaunchDataSqlServer>();
//builder.Services.AddScoped<ICronService, CronService>();

builder.Services.AddHostedService<CronService>();

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

app.MapGet("/", () =>
{
    return Results.Ok("REST Back-end Challenge 20201209 Running");
});

app.Run();