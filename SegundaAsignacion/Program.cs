using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SegundaAsignacion.BL.Mappings;
using SegundaAsignacion.Model.Context;
using SegundaAsignacion.Model.Repository;
using SegundaAsignacion.Services.GenericServices;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string myAppDbContextConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SegundaAsignacionDbContext>(op => op.UseSqlServer(myAppDbContextConnection),
    ServiceLifetime.Transient);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<ICrudEstudiantes, CrudEstudiantes>();
builder.Services.AddTransient<ICrudNotas, CrudNotas>();


builder.Services.AddFluentValidation(c => c.RegisterValidatorsFromAssembly
(Assembly.GetExecutingAssembly()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapperConfig = new MapperConfiguration(m =>
{
    m.AddProfile(new EstudiantesProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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

app.Run();
