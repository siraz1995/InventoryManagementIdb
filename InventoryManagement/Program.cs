using AutoMapper;
using Core.Applicatio;
using Core.Application.Interface.Procurment;
using Infrastructure.Data;
using Core.Domain.DBContext;
//using Infrastructure.DBContext;
using Infrastructure.DependencyInjection;
using Infrastructure.Repository;
using Infrastructure.Repository.Mapper;
using Infrastructure.Repository.Procurment;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IDataAccess, DataAccess>();
builder.Services.AddRepositoryServices();

//builder.Services.AddDbContext<InventorymanagementSyatemContext>(options =>
builder.Services.AddDbContext<InventorymanagementContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("purchaseOrder"));
});

builder.Services.AddTransient<Iinvoice, PurchaseRepository>();
var automapper = new MapperConfiguration(item => item.AddProfile(new MappingProfile()));
IMapper mapper = automapper.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddCors(Option =>
{
    Option.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
