using Basket.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddApplicationInfra(builder.Configuration);

builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(v =>
{
    v.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
    v.AssumeDefaultVersionWhenUnspecified = true;
    v.ReportApiVersions = true;

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(option =>
    {
        option.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.MapControllers();


app.Run();
 