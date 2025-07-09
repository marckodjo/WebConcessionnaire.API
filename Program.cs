
using WebConcessionnaire.API.Data;
using WebConcessionnaire.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddTransient<ApiDbContext>();

builder.Services.AddOpenApi();
builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Concessionnaire";
    config.Version = "v1";
});

builder.Services.AddScoped<IConcessionnaireRepository, ConcessionnaireRepository>();

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
