using System.Net.Http.Headers;
using System.Text;
using E_handel.Payment.Config;
using E_handel.Payment.Interfaces;
using E_handel.Payment.Services;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.Configure<KlarnaConfig>(builder.Configuration.GetSection("Klarna"));
builder.Services.AddHttpClient<IPaymentService, KlarnaService>();
builder.Services.AddScoped<IPaymentService, KlarnaService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "E-handel.Api", Version = "v1" });
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
