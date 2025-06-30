
using Microsoft.EntityFrameworkCore;
using WebConcessionnaire.API.Data;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<ApiDbContext>(options =>
//    options. ("Data Source=concessionnaire.db"));

builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApiConnexionString")));



builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Concessionnaire";
    config.Version = "v1";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
