using AutoMapper;
using Discount.Api.Services;
using Discount.Application.CQRS.Handler.Query;
using Discount.Application.Mapper;
using Discount.Core.Interfaces;
using Discount.Infrastructure.Extensions;
using Discount.Infrastructure.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
 

 
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<DiscountMapper>();
});

IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);//Register Mediator
var assemblies = new Assembly[]
{
    Assembly.GetExecutingAssembly(),
    typeof(GetDiscountByNameQueryHandler).Assembly
};
//DI
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
//GRPC
builder.Services.AddGrpc();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

var app = builder.Build();
app.MigrateDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseRouting();
app.MapGrpcService<DiscountService>();
app.Map("/", async context =>
{
    await context.Response.WriteAsync("communication with GRPC");
});

app.Run();

 