using Back_End_Challenge_20210221.Domain.Data;
using Back_End_Challenge_20210221.Infra.Cron;
using Back_End_Challenge_20210221.Infra.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Prometheus;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var startTime = Stopwatch.GetTimestamp();

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);

var chave = Encoding.ASCII.GetBytes("4f7b17c4b5afe5d9527c74c49002c4d8a268f7e31d9b16357887b7556fbf199a");
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(chave),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true
    };
});

builder.Services.UseHttpClientMetrics();

builder.Services.AddControllers();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<EfSqlServerAdapter>(options =>
        options.UseInMemoryDatabase("BackEndChallengeDb"));
}
else
{
    builder.Services.AddDbContext<EfSqlServerAdapter>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}

builder.Services.AddScoped<ILaunchData, LaunchDataSqlServer>();
builder.Services.AddHostedService<CronService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    x.AddSecurityRequirement(new OpenApiSecurityRequirement {
   {
     new OpenApiSecurityScheme
     {
       Reference = new OpenApiReference
       {
         Type = ReferenceType.SecurityScheme,
         Id = "Bearer"
       }
      },
      Array.Empty<string>()
    }
  });
});

var app = builder.Build();

var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();
lifetime.ApplicationStarted.Register(() =>
{
    Console.WriteLine($"Time (ms) to Startup Application: {Stopwatch.GetElapsedTime(startTime).TotalMilliseconds}");
});

using IServiceScope scope = app.Services.CreateScope();
EfSqlServerAdapter context = scope.ServiceProvider.GetRequiredService<EfSqlServerAdapter>();
if (context.Database.IsRelational())
{
    await context.Database.MigrateAsync();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.UseMetricServer();
app.UseHttpMetrics();

app.MapControllers();

app.MapGet("/", () =>
{
    return Results.Ok("REST Back-end Challenge 20201209 Running");
});
app.MapGet("validToken/", () =>
{
    JwtSecurityTokenHandler tokenHandler = new();
    byte[] chave = Encoding.ASCII.GetBytes("4f7b17c4b5afe5d9527c74c49002c4d8a268f7e31d9b16357887b7556fbf199a");
    SecurityTokenDescriptor tokenDescriptor = new()
    {
        Expires = DateTime.UtcNow.AddHours(2),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha256Signature)
    };
    SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
    string strToken = tokenHandler.WriteToken(token);

    return Results.Ok($"Bearer {strToken}");
});

await app.RunAsync();